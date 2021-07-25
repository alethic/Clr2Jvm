using Clr2Jvm.Interop.Reflection;

using System;
using System.Linq.Expressions;
using System.Reflection;

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

        public override TypeInfo GetManagedType(JavaParameterDescriptor parameter)
        {
            return parameter.Type == JavaDescriptorType.Object && parameter.ArrayRank == 0 && parameter.Class == "java.lang.String" ? typeof(string).GetTypeInfo() : null;
        }

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument)
        {
            throw new NotImplementedException();
        }

        public override Func<Expression, Expression> MarshalReturn(JavaParameterDescriptor descriptor, ref Expression value)
        {
            throw new NotImplementedException();
        }

    }

}
