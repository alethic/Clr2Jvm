using System;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a Java string.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class StringMarshalBuilder : MarshalBuilder
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public StringMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshal(JavaParameterDescriptor descriptor)
        {
            return descriptor.Type == JavaDescriptorType.Object && descriptor.ArrayRank == 0 && descriptor.Class == "java.lang.String";
        }

        public override TypeInfo GetManagedType(JavaParameterDescriptor descriptor)
        {
            return typeof(string).GetTypeInfo();
        }

        public override TypeInfo GetMarshalType(JavaParameterDescriptor descriptor)
        {
            return typeof(JString).GetTypeInfo();
        }

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument)
        {
            // allocated string will be a JString variable; passed to call converted to JObject
            var arg = argument;
            var tmp = Expression.Variable(typeof(JString), "tmp");
            argument = Expression.Convert(tmp, typeof(JObject));

            return body => MarshalBody(arg, tmp, body);
        }

        /// <summary>
        /// Returns an expression that implements the body required to marshal the string.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="tmp"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Expression MarshalBody(Expression arg, ParameterExpression tmp, Expression body)
        {
            var env = Expression.Variable(typeof(JavaEnvironment), "env");

            // try/finally block, call NewString, assign result to tmp
            // on finally, call SafeDeleteLocalRef
            return Expression.Block(
                new[] { env, tmp },
                Expression.Assign(env, EnvironmentExpression),
                Expression.TryFinally(
                    Expression.Block(
                        Expression.Assign(tmp, Expression.Call(env, nameof(JavaEnvironment.NewString), null, arg)),
                        body),
                    Expression.Block(
                        Expression.Call(env, nameof(JavaEnvironment.SafeDeleteLocalRef), null, Expression.Convert(tmp, typeof(JObject))))));
        }

        /// <summary>
        /// Returns an expression that converts the method call result into a <see cref="string"/>.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public override Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression expression)
        {
            var env = Expression.Variable(typeof(JavaEnvironment), "env");
            var tmp = Expression.Variable(typeof(JString), "tmp");
            var rsl = Expression.Variable(typeof(string), "result");

            // try/finally block, assign result to temp variable
            // finally block ensures tmp is disposed
            // end with new string result
            return Expression.Block(
                new[] { env, tmp, rsl },
                Expression.Assign(env, EnvironmentExpression),
                Expression.TryFinally(
                    Expression.Block(
                        Expression.Assign(tmp, Expression.Convert(expression, typeof(JString))),
                        Expression.Assign(rsl, Expression.Call(env, nameof(JavaEnvironment.GetString), null, tmp))),
                    Expression.Block(
                        Expression.Call(env, nameof(JavaEnvironment.SafeDeleteLocalRef), null, Expression.Convert(tmp, typeof(JObject))))),
                rsl);
        }

    }

}
