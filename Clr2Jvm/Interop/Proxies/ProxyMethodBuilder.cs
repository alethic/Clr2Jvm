using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Provides methods to build delegates capable of marshalling CLR calls into Java calls.
    /// </summary>
    class ProxyMethodBuilder
    {

        readonly JavaRuntime runtime;
        readonly MarshalBuilder[] builders;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public ProxyMethodBuilder(JavaRuntime runtime)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));

            // load builders
            builders = typeof(ProxyMethodBuilder).Assembly.GetTypes()
                .Select(i => new { Type = i, Attribute = i.GetCustomAttribute<MarshalBuilderAttribute>() })
                .Where(i => i.Attribute != null)
                .OrderBy(i => i.Attribute.Order)
                .Select(i => i.Type)
                .Select(i => (MarshalBuilder)Activator.CreateInstance(i, runtime))
                .ToArray();
        }

        #region CallStaticMethod

        /// <summary>
        /// Builds a delegate that invokes a Java static method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public Delegate BuildCallStaticMethodDelegate(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            return BuildCallStaticMethodExpression(clazz, method, descriptor).Compile();
        }

        /// <summary>
        /// Builds a delegate that invokes a specified Java static method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallStaticMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            // dispatch to generic implementation with class and method as constants
            var ink = descriptor.Return.Type == JavaDescriptorType.Void ? BuildCallStaticVoidMethodExpression(descriptor.Parameters) : BuildCallStaticValueMethodExpression(descriptor.Return, descriptor.Parameters);
            var prm = ink.Parameters.Skip(2).Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();
            var arg = new Expression[] { Expression.Constant(clazz), Expression.Constant(method) }.Concat(prm);
            return Expression.Lambda(Expression.Invoke(ink, arg), prm);
        }

        /// <summary>
        /// Builds a lambda that invokes a Java static method with no return value with the given signature. The returned expression requires the JClass and JMethodID parameters.
        /// </summary>
        /// <param name="parameterDescriptors"></param>
        /// <returns></returns>
        LambdaExpression BuildCallStaticVoidMethodExpression(IEnumerable<JavaParameterDescriptor> parameterDescriptors)
        {
            // lambda begins with parameters that specify what to call
            var c = Expression.Parameter(typeof(JClass), "__class");
            var m = Expression.Parameter(typeof(JMethodID), "__method");

            // obtain marshalling information for each parameter and add to lambda parameters
            var parameterBuilders = parameterDescriptors.Select((i, j) => BuildMarshalParameter(i, $"arg{j}")).ToArray();

            // managed parameters and marshaled arguments
            var parameters = new[] { c, m }.Concat(parameterBuilders.Select(i => i.Parameter)).ToArray();
            var arguments = parameterBuilders.Select(i => i.Argument).ToArray();

            // argument list to pass to call method
            var argumentsVar = Expression.Variable(typeof(JValue[]), "args");

            // define method body
            var body = (Expression)Expression.Block(
                new[] { argumentsVar },
                Expression.Assign(argumentsVar, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(argumentsVar, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                BuildCallStaticMethod(JavaDescriptorType.Void, c, m, argumentsVar));

            // apply each body function to the call
            foreach (var (_, _, f) in parameterBuilders)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, parameters);
        }

        /// <summary>
        /// Builds a delegate that invokes a Java static method with the given signature. The returned expression requires the JClass and JMethodID parameters.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        LambdaExpression BuildCallStaticValueMethodExpression(JavaParameterDescriptor returnDescriptor, IEnumerable<JavaParameterDescriptor> parameterDescriptors)
        {
            // lambda begins with parameters that specify what to call
            var c = Expression.Parameter(typeof(JClass), "__class");
            var m = Expression.Parameter(typeof(JMethodID), "__method");

            // obtain marshalling information for each parameter and add to lambda parameters
            var parameterBuilders = parameterDescriptors.Select((i, j) => BuildMarshalParameter(i, $"arg{j}")).ToArray();
            var returnBuilder = GetMarshalBuilder(returnDescriptor);

            // managed parameters and marshaled arguments
            var parameters = new[] { c, m }.Concat(parameterBuilders.Select(i => i.Parameter)).ToArray();
            var arguments = parameterBuilders.Select(i => i.Argument).ToArray();

            // argument list to pass to call method
            var argumentsVar = Expression.Variable(typeof(JValue[]), "args");

            // results are assigned to return var which is then returned
            var returnType = returnBuilder.GetManagedType(returnDescriptor);
            var resultVar = Expression.Variable(returnType, "result");
            var returnLabel = Expression.Label(returnType);

            // define method body
            var body = (Expression)Expression.Block(
                new[] { argumentsVar, resultVar },
                Expression.Assign(argumentsVar, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(argumentsVar, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                Expression.Assign(resultVar, returnBuilder.MarshalReturn(returnDescriptor, BuildCallStaticMethod(returnDescriptor.Type, c, m, argumentsVar))),
                resultVar);

            // apply each body function to the call
            foreach (var (_, _, f) in parameterBuilders)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, parameters);
        }

        /// <summary>
        /// Generates an expression that will invoke the appropriate CallStatic*Method based on the return type.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Expression BuildCallStaticMethod(JavaDescriptorType returnType, Expression clazz, Expression method, Expression args) =>
            Expression.Call(
                Expression.Property(Expression.Constant(runtime), nameof(JavaRuntime.Environment)),
                GetCallStaticMethodInfo(returnType),
                clazz,
                method,
                Expression.Convert(args, typeof(ReadOnlySpan<JValue>)));

        /// <summary>
        /// Gets the environmental method to be invoked.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static MethodInfo GetCallStaticMethodInfo(JavaDescriptorType type) => type switch
        {
            JavaDescriptorType.Void => JavaEnvironment.CallStaticVoidMethodInfo,
            JavaDescriptorType.Boolean => JavaEnvironment.CallStaticBooleanMethodInfo,
            JavaDescriptorType.Byte => JavaEnvironment.CallStaticByteMethodInfo,
            JavaDescriptorType.Char => JavaEnvironment.CallStaticCharMethodInfo,
            JavaDescriptorType.Short => JavaEnvironment.CallStaticShortMethodInfo,
            JavaDescriptorType.Int => JavaEnvironment.CallStaticIntMethodInfo,
            JavaDescriptorType.Long => JavaEnvironment.CallStaticLongMethodInfo,
            JavaDescriptorType.Float => JavaEnvironment.CallStaticFloatMethodInfo,
            JavaDescriptorType.Double => JavaEnvironment.CallStaticDoubleMethodInfo,
            JavaDescriptorType.Object => JavaEnvironment.CallStaticObjectMethodInfo,
            _ => throw new NotImplementedException(),
        };

        #endregion

        /// <summary>
        /// Obtains the parameter expression, argument expression, and function to modify the body for marshalling a parameter from managed to native.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        (ParameterExpression Parameter, Expression Argument, Func<Expression, Expression> BodyFunc) BuildMarshalParameter(JavaParameterDescriptor descriptor, string name)
        {
            var builder = GetMarshalBuilder(descriptor);

            var par = Expression.Parameter(builder.GetManagedType(descriptor), name);
            var arg = (Expression)par;
            var fun = builder.MarshalParameter(descriptor, ref arg);

            return (par, arg, fun);
        }

        /// <summary>
        /// Gets the <see cref="MarshalBuilder"/> capable of handling the specified descriptor.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        MarshalBuilder GetMarshalBuilder(JavaParameterDescriptor descriptor)
        {
            var builder = builders.FirstOrDefault(i => i.CanMarshal(descriptor));
            if (builder == null)
                throw new JavaException($"Could not find marshal builder for '{descriptor}'.");

            return builder;
        }

        /// <summary>
        /// Gets the Java marshal type for the given parameter descriptor.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        Type GetMarshalType(JavaParameterDescriptor descriptor) => descriptor.ArrayRank switch
        {
            0 => descriptor.Type switch
            {
                JavaDescriptorType.Boolean => typeof(JBoolean),
                JavaDescriptorType.Byte => typeof(JByte),
                JavaDescriptorType.Char => typeof(JChar),
                JavaDescriptorType.Short => typeof(JShort),
                JavaDescriptorType.Int => typeof(JInt),
                JavaDescriptorType.Long => typeof(JLong),
                JavaDescriptorType.Float => typeof(JFloat),
                JavaDescriptorType.Double => typeof(JDouble),
                JavaDescriptorType.Object => typeof(JObject),
                _ => throw new NotImplementedException(),
            },
            1 => descriptor.Type switch
            {
                JavaDescriptorType.Boolean => typeof(JBooleanArray),
                JavaDescriptorType.Byte => typeof(JByteArray),
                JavaDescriptorType.Char => typeof(JCharArray),
                JavaDescriptorType.Short => typeof(JShortArray),
                JavaDescriptorType.Int => typeof(JIntArray),
                JavaDescriptorType.Long => typeof(JLongArray),
                JavaDescriptorType.Float => typeof(JFloatArray),
                JavaDescriptorType.Double => typeof(JDoubleArray),
                JavaDescriptorType.Object => typeof(JObjectArray),
                _ => throw new NotImplementedException(),
            },
            _ => typeof(JObject)
        };

        /// <summary>
        /// Builds a delegate that invokes a Java instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public Delegate BuildCallMethodDelegate(JClass clazz, JMethodID method, JavaMethodDescriptor signature)
        {
            return BuildCallMethodExpression(clazz, method, signature).Compile();
        }

        /// <summary>
        /// Builds a delegate that invokes a specified Java instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor signature)
        {
            var env = runtime.Environment;
            clazz = runtime.Environment.NewGlobalRef(clazz);

            var ink = BuildCallMethodExpression(signature);
            var prm = ink.Parameters.Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();
            var arg = new Expression[] { Expression.Constant(clazz), Expression.Constant(method) }.Concat(prm);

            return Expression.Lambda(Expression.Invoke(ink, arg), prm);
        }

        /// <summary>
        /// Builds a delegate that invokes a Java instance method with the given signature. The returned expression requires the JClass, JMethodID and JObject parameters.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallMethodExpression(JavaMethodDescriptor signature)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a delegate that invokes a Java non-virtual method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public Delegate BuildCallNonvirtualMethodDelegate(JClass clazz, JMethodID method, JavaMethodDescriptor signature)
        {
            return BuildCallNonvirtualMethodExpression(clazz, method, signature).Compile();
        }

        /// <summary>
        /// Builds a delegate that invokes a Java non-virtual method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallNonvirtualMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor signature)
        {
            var env = runtime.Environment;
            clazz = runtime.Environment.NewGlobalRef(clazz);

            var ink = BuildCallNonvirtualMethodExpression(signature);
            var prm = ink.Parameters.Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();
            var arg = new Expression[] { Expression.Constant(clazz), Expression.Constant(method) }.Concat(prm);

            return Expression.Lambda(Expression.Invoke(ink, arg), prm);
        }

        /// <summary>
        /// Builds a delegate that invokes a Java non-virtual method with the given signature. The returned expression requires the JClass, JMethodID and JObject parameters.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallNonvirtualMethodExpression(JavaMethodDescriptor signature)
        {
            throw new NotImplementedException();
        }

    }

}
