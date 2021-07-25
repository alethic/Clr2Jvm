using System;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java type.
    /// </summary>
    abstract class ConvertableTypeMarshalBuilder<TManaged, TMarshal> : MarshalBuilder
    {

        readonly JavaDescriptorType type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        protected ConvertableTypeMarshalBuilder(JavaRuntime runtime, JavaDescriptorType type) :
            base(runtime)
        {
            this.type = type;
        }

        /// <summary>
        /// Returns <c>true</c> if the given type can be handled by this marshaler.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool CanMarshalType(JavaDescriptorType type)
        {
            return type == this.type;
        }

        public override bool CanMarshal(JavaParameterDescriptor descriptor)
        {
            return descriptor.Type != JavaDescriptorType.Void && CanMarshalType(descriptor.Type) && descriptor.ArrayRank == 0;
        }

        public override TypeInfo GetMarshalType(JavaParameterDescriptor descriptor)
        {
            return typeof(TMarshal).GetTypeInfo();
        }

        public override TypeInfo GetManagedType(JavaParameterDescriptor descriptor)
        {
            return typeof(TManaged).GetTypeInfo();
        }

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument)
        {
            argument = Expression.Convert(argument, typeof(TMarshal));
            return body => body;
        }

        public override Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression expression)
        {
            return Expression.Convert(expression, typeof(TManaged));
        }

    }

}
