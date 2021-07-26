using System;
using System.Collections.Concurrent;
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
        readonly ConcurrentDictionary<JavaParameterDescriptor, MarshalBuilder> buildersCache = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public ProxyMethodBuilder(JavaRuntime runtime)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));

            // load builders
            builders = typeof(ProxyMethodBuilder).Assembly.GetTypes()
                .Select(i => new { Type = i, Attribute = i.GetCustomAttribute<MarshalBuilderAttribute>() }).Where(i => i.Attribute != null).OrderBy(i => i.Attribute.Order)
                .Select(i => (MarshalBuilder)Activator.CreateInstance(i.Type, runtime))
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
        /// Builds a delegate that invokes a static method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallStaticMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            // lambda begins with parameters that specify what to call
            var innerClass = Expression.Parameter(typeof(JClass), "__class");
            var innerMethod = Expression.Parameter(typeof(JMethodID), "__method");

            // build inner call
            var inner = BuildCallStaticMethodExpression(descriptor, innerClass, innerMethod, out var innerParameters);

            // new parameters to be accepted by our delegate
            var parameters = innerParameters.Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();

            // arguments to be passed to implementation, including constants
            var innerArgs = new Expression[] { Expression.Convert(Expression.Constant(new JObjectGlobalRef(runtime, clazz)), typeof(JClass)), Expression.Constant(method) }.Concat(parameters);

            // our delegate calls implementation
            return Expression.Lambda(Expression.Invoke(inner, innerArgs), parameters);
        }

        /// <summary>
        /// Builds a lambda that invokes a static method with no return value with the given signature. The returned expression requires the JClass and JMethodID parameters.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        LambdaExpression BuildCallStaticMethodExpression(JavaMethodDescriptor descriptor, ParameterExpression clazz, ParameterExpression method, out ParameterExpression[] parameters)
        {
            // obtain marshalling information for each parameter and add to lambda parameters
            var parameterBuilders = descriptor.Parameters.Select((i, j) => BuildMarshalParameter(i, $"arg{j}")).ToArray();

            // managed parameters and marshaled arguments
            parameters = parameterBuilders.Select(i => i.Parameter).ToArray();
            var arguments = parameterBuilders.Select(i => i.Argument).ToArray();
            var argumentsVar = Expression.Variable(typeof(JValue[]), "args");

            var call = BuildCallStaticMethod(descriptor.Return.Type, clazz, method, argumentsVar);
            if (descriptor.Return.Type != JavaDescriptorType.Void)
                call = GetMarshalBuilder(descriptor.Return).MarshalReturn(descriptor.Return, call);

            // define method body
            var body = (Expression)Expression.Block(
                new[] { argumentsVar },
                Expression.Assign(argumentsVar, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(argumentsVar, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                call);

            // apply each body function to the call
            foreach (var (_, _, f) in parameterBuilders)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, new[] { clazz, method }.Concat(parameterBuilders.Select(i => i.Parameter)));
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

        #region CallMethod

        /// <summary>
        /// Builds a delegate that invokes an instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public Delegate BuildCallMethodDelegate(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            return BuildCallMethodExpression(clazz, method, descriptor).Compile();
        }

        /// <summary>
        /// Builds a delegate that invokes an instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            // first parameter accepted by our delegate
            var instance = Expression.Parameter(typeof(JObject), "_instance");

            // lambda begins with parameters that specify what to call
            var innerInstance = Expression.Parameter(typeof(JObject), "__instance");
            var innerClass = Expression.Parameter(typeof(JClass), "__class");
            var innerMethod = Expression.Parameter(typeof(JMethodID), "__method");

            // build inner call
            var inner = BuildCallMethodExpression(descriptor, innerInstance, innerClass, innerMethod, out var innerParameters);

            // new parameters to be accepted by our delegate
            var parameters = innerParameters.Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();

            // arguments to be passed to implementation, including constants
            var innerArgs = new Expression[] { instance, Expression.Convert(Expression.Constant(new JObjectGlobalRef(runtime, clazz)), typeof(JClass)), Expression.Constant(method) }.Concat(parameters);

            // our delegate calls implementation
            return Expression.Lambda(
                Expression.Invoke(inner, innerArgs),
                new[] { instance }.Concat(parameters));
        }

        /// <summary>
        /// Builds a lambda expression for an instance method that accepts an instance, class and method. Returns the parameters representing the managed types.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        LambdaExpression BuildCallMethodExpression(JavaMethodDescriptor descriptor, ParameterExpression instance, ParameterExpression clazz, ParameterExpression method, out ParameterExpression[] parameters)
        {
            // obtain marshalling information for each parameter and add to lambda parameters
            var parameterBuilders = descriptor.Parameters.Select((i, j) => BuildMarshalParameter(i, $"arg{j}")).ToArray();

            // managed parameters and marshaled arguments
            parameters = parameterBuilders.Select(i => i.Parameter).ToArray();
            var arguments = parameterBuilders.Select(i => i.Argument).ToArray();
            var argumentsVar = Expression.Variable(typeof(JValue[]), "args");

            var call = BuildCallMethod(descriptor.Return.Type, instance, method, argumentsVar);
            if (descriptor.Return.Type != JavaDescriptorType.Void)
                call = GetMarshalBuilder(descriptor.Return).MarshalReturn(descriptor.Return, call);

            // define method body
            var body = (Expression)Expression.Block(
                new[] { argumentsVar },
                Expression.Assign(argumentsVar, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(argumentsVar, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                call);

            // apply each body function to the call
            foreach (var (_, _, f) in parameterBuilders)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, new[] { instance, clazz, method }.Concat(parameterBuilders.Select(i => i.Parameter)));
        }

        /// <summary>
        /// Generates an expression that will invoke the appropriate Call*Method based on the return type.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Expression BuildCallMethod(JavaDescriptorType returnType, Expression instance, Expression method, Expression args) =>
            Expression.Call(
                Expression.Property(Expression.Constant(runtime), nameof(JavaRuntime.Environment)),
                GetCallMethodInfo(returnType),
                instance,
                method,
                Expression.Convert(args, typeof(ReadOnlySpan<JValue>)));

        /// <summary>
        /// Gets the environmental method to be invoked.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static MethodInfo GetCallMethodInfo(JavaDescriptorType type) => type switch
        {
            JavaDescriptorType.Void => JavaEnvironment.CallVoidMethodInfo,
            JavaDescriptorType.Boolean => JavaEnvironment.CallBooleanMethodInfo,
            JavaDescriptorType.Byte => JavaEnvironment.CallByteMethodInfo,
            JavaDescriptorType.Char => JavaEnvironment.CallCharMethodInfo,
            JavaDescriptorType.Short => JavaEnvironment.CallShortMethodInfo,
            JavaDescriptorType.Int => JavaEnvironment.CallIntMethodInfo,
            JavaDescriptorType.Long => JavaEnvironment.CallLongMethodInfo,
            JavaDescriptorType.Float => JavaEnvironment.CallFloatMethodInfo,
            JavaDescriptorType.Double => JavaEnvironment.CallDoubleMethodInfo,
            JavaDescriptorType.Object => JavaEnvironment.CallObjectMethodInfo,
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region CallNonvirtualMethod

        /// <summary>
        /// Builds a delegate that invokes a non-virtual instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public Delegate BuildCallNonvirtualMethodDelegate(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            return BuildCallNonvirtualMethodExpression(clazz, method, descriptor).Compile();
        }

        /// <summary>
        /// Builds a delegate that invokes a specified non-virtual instance method with the given signature.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public LambdaExpression BuildCallNonvirtualMethodExpression(JClass clazz, JMethodID method, JavaMethodDescriptor descriptor)
        {
            // first parameter accepted by our delegate
            var instance = Expression.Parameter(typeof(JObject), "_instance");

            // lambda begins with parameters that specify what to call
            var innerInstance = Expression.Parameter(typeof(JObject), "__instance");
            var innerClass = Expression.Parameter(typeof(JClass), "__class");
            var innerMethod = Expression.Parameter(typeof(JMethodID), "__method");

            // build inner call
            var inner = BuildCallNonvirtualMethodExpression(descriptor, innerInstance, innerClass, innerMethod, out var innerParameters);

            // new parameters to be accepted by our delegate
            var parameters = innerParameters.Select(i => Expression.Parameter(i.Type, i.Name)).ToArray();

            // arguments to be passed to implementation, including constants
            var innerArgs = new Expression[] { instance, Expression.Convert(Expression.Constant(new JObjectGlobalRef(runtime, clazz)), typeof(JClass)), Expression.Constant(method) }.Concat(parameters);

            // our delegate calls implementation
            return Expression.Lambda(
                Expression.Invoke(inner, innerArgs),
                new[] { instance }.Concat(parameters));
        }

        /// <summary>
        /// Builds a lambda expression for a non-virtual instance method that accepts an instance, class and method. Returns the parameters representing the managed types.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        LambdaExpression BuildCallNonvirtualMethodExpression(JavaMethodDescriptor descriptor, ParameterExpression instance, ParameterExpression clazz, ParameterExpression method, out ParameterExpression[] parameters)
        {
            // obtain marshalling information for each parameter and add to lambda parameters
            var parameterBuilders = descriptor.Parameters.Select((i, j) => BuildMarshalParameter(i, $"arg{j}")).ToArray();

            // managed parameters and marshaled arguments
            parameters = parameterBuilders.Select(i => i.Parameter).ToArray();
            var arguments = parameterBuilders.Select(i => i.Argument).ToArray();
            var argumentsVar = Expression.Variable(typeof(JValue[]), "args");

            var call = BuildCallNonvirtualMethod(descriptor.Return.Type, instance, clazz, method, argumentsVar);
            if (descriptor.Return.Type != JavaDescriptorType.Void)
                call = GetMarshalBuilder(descriptor.Return).MarshalReturn(descriptor.Return, call);

            // define method body
            var body = (Expression)Expression.Block(
                new[] { argumentsVar },
                Expression.Assign(argumentsVar, Expression.NewArrayBounds(typeof(JValue), Expression.Constant(arguments.Length))),
                Expression.Block(arguments.Select((i, j) => Expression.Assign(Expression.MakeIndex(argumentsVar, null, new[] { Expression.Constant(j) }), Expression.Convert(i, typeof(JValue))))),
                call);

            // apply each body function to the call
            foreach (var (_, _, f) in parameterBuilders)
                body = f(body);

            // generate callable expression
            return Expression.Lambda(body, new[] { instance, clazz, method }.Concat(parameterBuilders.Select(i => i.Parameter)));
        }

        /// <summary>
        /// Generates an expression that will invoke the appropriate CallNonvirtual*Method based on the return type.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Expression BuildCallNonvirtualMethod(JavaDescriptorType returnType, Expression instance, Expression clazz, Expression method, Expression args) =>
            Expression.Call(
                Expression.Property(Expression.Constant(runtime), nameof(JavaRuntime.Environment)),
                GetCallNonvirtualMethodInfo(returnType),
                instance,
                clazz,
                method,
                Expression.Convert(args, typeof(ReadOnlySpan<JValue>)));

        /// <summary>
        /// Gets the environmental method to be invoked.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static MethodInfo GetCallNonvirtualMethodInfo(JavaDescriptorType type) => type switch
        {
            JavaDescriptorType.Void => JavaEnvironment.CallNonvirtualVoidMethodInfo,
            JavaDescriptorType.Boolean => JavaEnvironment.CallNonvirtualBooleanMethodInfo,
            JavaDescriptorType.Byte => JavaEnvironment.CallNonvirtualByteMethodInfo,
            JavaDescriptorType.Char => JavaEnvironment.CallNonvirtualCharMethodInfo,
            JavaDescriptorType.Short => JavaEnvironment.CallNonvirtualShortMethodInfo,
            JavaDescriptorType.Int => JavaEnvironment.CallNonvirtualIntMethodInfo,
            JavaDescriptorType.Long => JavaEnvironment.CallNonvirtualLongMethodInfo,
            JavaDescriptorType.Float => JavaEnvironment.CallNonvirtualFloatMethodInfo,
            JavaDescriptorType.Double => JavaEnvironment.CallNonvirtualDoubleMethodInfo,
            JavaDescriptorType.Object => JavaEnvironment.CallNonvirtualObjectMethodInfo,
            _ => throw new NotImplementedException(),
        };

        #endregion

        /// <summary>
        /// Obtains the parameter expression, argument expression, and function to modify the body for marshalling a parameter from managed to native.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="name"></param>
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
        /// <returns></returns>s
        MarshalBuilder GetMarshalBuilder(JavaParameterDescriptor descriptor) =>
            buildersCache.GetOrAdd(descriptor, d => builders.FirstOrDefault(i => i.CanMarshal(descriptor))) ??
                throw new JavaException($"Could not find marshal builder for '{descriptor}'.");

    }

}
