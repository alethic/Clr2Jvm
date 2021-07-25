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

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        protected ConvertableTypeMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public abstract bool CanMarshalType(JavaDescriptorType type);

        public override TypeInfo GetManagedType(JavaParameterDescriptor parameter)
        {
            return parameter.Type != JavaDescriptorType.Void && CanMarshalType(parameter.Type) && parameter.ArrayRank == 0 ? typeof(TManaged).GetTypeInfo() : null;
        }

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor parameter, ref Expression expression)
        {
            expression = Expression.Convert(expression, typeof(TMarshal));
            return body => body;
        }

        public override Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression call, out ParameterExpression result)
        {
            result = Expression.Variable(typeof(TManaged), "@result");
            return Expression.Assign(result, Expression.Convert(call, typeof(TManaged)));
        }

    }

}
