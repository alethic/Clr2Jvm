﻿using System;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the default marshal build logic for a Java object.
    /// </summary>
    [MarshalBuilder(int.MaxValue)]
    class ObjectMarshalBuilder : MarshalBuilder
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public ObjectMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshal(JavaParameterDescriptor descriptor)
        {
            return false;
        }

        public override TypeInfo GetMarshalType(JavaParameterDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo GetManagedType(JavaParameterDescriptor parameter)
        {
            return parameter.Type == JavaDescriptorType.Object && parameter.ArrayRank == 0 ? typeof(object).GetTypeInfo() : null;
        }

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument)
        {
            throw new NotImplementedException();
        }

        public override Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression expression)
        {
            throw new NotImplementedException();
        }

    }

}
