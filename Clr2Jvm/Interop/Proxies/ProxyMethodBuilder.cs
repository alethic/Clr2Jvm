using System;
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
            var ink = BuildCallStaticMethodExpression(descriptor);
            var prm = ink.Parameters.Skip(2).Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();
            var arg = new Expression[] { Expression.Constant(clazz), Expression.Constant(method) }.Concat(prm);

            return Expression.Lambda(Expression.Invoke(ink, arg), prm);
        }

        /// <summary>
        /// Builds a delegate that invokes a Java static method with the given signature. The returned expression requires the JClass and JMethodID parameters.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallStaticVoidMethodExpression(JavaMethodDescriptor descriptor)
        {
            // lambda begins with parameters that specify what to call
            var c = Expression.Parameter(typeof(JClass), "__class");
            var m = Expression.Parameter(typeof(JMethodID), "__method");

            // obtain marshalling information for each parameter and add to lambda parameters
            var marshaling = descriptor.Parameters.Select(i => BuildMarshalParameter(i)).ToArray();
            var parameters = new[] { c, m }.Concat(marshaling.Select(i => i.Parameter)).ToArray();
            var arguments = marshaling.Select(i => i.Argument).ToArray();

            // packs a JValue[] with each item
            var args = Expression.Variable(typeof(JValue[]));
            var body = (Expression)Expression.Block(
                new[] { args },
                Expression.Assign(args, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(args, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                BuildCallStaticMethod(descriptor.Return.Type, c, m, args));

            // apply each body function to the call
            foreach (var (_, _, f) in marshaling)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, parameters);
        }

        /// <summary>
        /// Builds a delegate that invokes a Java static method with the given signature. The returned expression requires the JClass and JMethodID parameters.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallStaticValueMethodExpression(JavaMethodDescriptor descriptor)
        {
            // lambda begins with parameters that specify what to call
            var c = Expression.Parameter(typeof(JClass), "__class");
            var m = Expression.Parameter(typeof(JMethodID), "__method");

            // obtain marshalling information for each parameter and add to lambda parameters
            var marshaling = descriptor.Parameters.Select(i => BuildMarshalParameter(i)).ToArray();
            var parameters = new[] { c, m }.Concat(marshaling.Select(i => i.Parameter)).ToArray();
            var arguments = marshaling.Select(i => i.Argument).ToArray();
            var returning = BuildMarshalReturn(descriptor.Return);

            // packs a JValue[] with each item
            var rslt = Expression.Variable(returning.Result.Type);
            var args = Expression.Variable(typeof(JValue[]));
            var body = (Expression)Expression.Block(
                new[] { args },
                Expression.Assign(args, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(args, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                Expression.Assign(rslt, BuildCallStaticMethod(descriptor.Return.Type, c, m, args)));

            // apply each body function to the call
            foreach (var (_, _, f) in marshaling)
                body = f(body);

            // apply marshaling for return
            body = returning.BodyFunc(body);

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
        Expression BuildCallStaticMethod(JavaDescriptorType returnType, Expression clazz, Expression method, Expression args) => Expression.Call(
            Expression.Property(Expression.Constant(runtime), nameof(JavaRuntime.Environment)),
            GetCallStaticMethodInfo(returnType),
            clazz,
            method,
            Expression.Convert(args, typeof(ReadOnlySpan<JValue>)));

        readonly static Type[] CallStaticMethodArgTypes = new[] { typeof(JClass), typeof(JMethodID), typeof(ReadOnlySpan<JValue>) };
        readonly static MethodInfo CallStaticVoidMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticVoidMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticBooleanMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticBooleanMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticByteMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticByteMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticCharMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticCharMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticShortMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticShortMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticIntMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticIntMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticLongMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticLongMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticFloatMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticFloatMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticDoubleMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticDoubleMethod), CallStaticMethodArgTypes);
        readonly static MethodInfo CallStaticObjectMethodMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticObjectMethod), CallStaticMethodArgTypes);

        static MethodInfo GetCallStaticMethodInfo(JavaDescriptorType type) => type switch
        {
            JavaDescriptorType.Void => CallStaticVoidMethodMethodInfo,
            JavaDescriptorType.Boolean => CallStaticBooleanMethodMethodInfo,
            JavaDescriptorType.Byte => CallStaticByteMethodMethodInfo,
            JavaDescriptorType.Char => CallStaticCharMethodMethodInfo,
            JavaDescriptorType.Short => CallStaticShortMethodMethodInfo,
            JavaDescriptorType.Int => CallStaticIntMethodMethodInfo,
            JavaDescriptorType.Long => CallStaticLongMethodMethodInfo,
            JavaDescriptorType.Float => CallStaticFloatMethodMethodInfo,
            JavaDescriptorType.Double => CallStaticDoubleMethodMethodInfo,
            JavaDescriptorType.Object => CallStaticObjectMethodMethodInfo,
            _ => throw new NotImplementedException(),
        };

        #endregion

        /// <summary>
        /// Scans the set of marshal builders for the one matching the specified parameter, and generates the 
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        (ParameterExpression Parameter, Expression Argument, Func<Expression, Expression> BodyFunc) BuildMarshalParameter(JavaParameterDescriptor descriptor)
        {
            var found = builders.Select(i => new { Builder = i, ManagedType = i.GetManagedType(descriptor) }).FirstOrDefault(i => i.ManagedType != null);
            if (found == null)
                throw new JavaException($"Could not find marshal builder for '{descriptor}'.");

            var par = Expression.Parameter(found.ManagedType);
            var arg = (Expression)par;
            var fun = found.Builder.MarshalParameter(descriptor, ref arg);

            return (par, arg, fun);
        }

        /// <summary>
        /// Scans the set of marshal builders for the one matching the specified return parameter and generates the set of information required to generate marshalling.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        (ParameterExpression Return, Expression Result, Func<Expression, Expression> BodyFunc) BuildMarshalReturn(JavaParameterDescriptor descriptor)
        {
            var found = builders.Select(i => new { Builder = i, ManagedType = i.GetManagedType(descriptor) }).FirstOrDefault(i => i.ManagedType != null);
            if (found == null)
                throw new JavaException($"Could not find marshal builder for '{descriptor}'.");

            var par = Expression.Parameter(found.ManagedType);
            var val = (Expression)par;
            var fun = found.Builder.MarshalReturn(descriptor, ref val);

            return (par, val, fun);
        }

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
