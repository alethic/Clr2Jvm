using System;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Provides the capability to generate marshaling code for a type.
    /// </summary>
    abstract class MarshalBuilder
    {

        readonly JavaRuntime runtime;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        protected MarshalBuilder(JavaRuntime runtime)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
        }

        /// <summary>
        /// Gets the associated runtime.
        /// </summary>
        public JavaRuntime Runtime => runtime;

        /// <summary>
        /// Returns <c>true</c> if this marshaller can marshal for the specified Java parameter descriptor.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public abstract bool CanMarshal(JavaParameterDescriptor descriptor);

        /// <summary>
        /// Returns the marshal type for the given Java parameter descriptor, or <c>null</c> if this builder does not
        /// suppor the given parameter.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public abstract TypeInfo GetMarshalType(JavaParameterDescriptor descriptor);

        /// <summary>
        /// Returns the managed type for the given Java parameter descriptor, or <c>null</c> if this builder does not
        /// support the given parameter.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public abstract TypeInfo GetManagedType(JavaParameterDescriptor descriptor);

        /// <summary>
        /// Accepts an original parameter expression, and replaces it with a new parameter expression to be used in the
        /// eventual native method invocation. Returns a function that applies any wrapping material to the call.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="argument"></param>
        /// <returns></returns>
        public abstract Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument);

        /// <summary>
        /// Returns an expression that marshals the given expression into the given result.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public abstract Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression expression);

        /// <summary>
        /// Gets an expression that accesses the current Java environment.
        /// </summary>
        protected Expression EnvironmentExpression => Expression.Property(Expression.Constant(runtime), nameof(JavaRuntime.Environment));

    }

}
