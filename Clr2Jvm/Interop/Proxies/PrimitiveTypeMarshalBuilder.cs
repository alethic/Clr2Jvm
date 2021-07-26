using System;
using System.Linq.Expressions;
using System.Reflection;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java type.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class PrimitiveTypeMarshalBuilder : MarshalBuilder
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public PrimitiveTypeMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        /// <summary>
        /// Returns <c>true</c> if the given type can be handled by this marshaler.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CanMarshalType(JavaDescriptorType type) => type switch
        {
            JavaDescriptorType.Boolean => true,
            JavaDescriptorType.Byte => true,
            JavaDescriptorType.Char => true,
            JavaDescriptorType.Short => true,
            JavaDescriptorType.Int => true,
            JavaDescriptorType.Long => true,
            JavaDescriptorType.Float => true,
            JavaDescriptorType.Double => true,
            _ => false,
        };

        public override bool CanMarshal(JavaParameterDescriptor descriptor)
        {
            return CanMarshalType(descriptor.Type) && descriptor.ArrayRank == 0;
        }

        public override TypeInfo GetMarshalType(JavaParameterDescriptor descriptor) => descriptor.Type switch
        {
            JavaDescriptorType.Boolean => typeof(JBoolean).GetTypeInfo(),
            JavaDescriptorType.Byte => typeof(JByte).GetTypeInfo(),
            JavaDescriptorType.Char => typeof(JChar).GetTypeInfo(),
            JavaDescriptorType.Short => typeof(JShort).GetTypeInfo(),
            JavaDescriptorType.Int => typeof(JInt).GetTypeInfo(),
            JavaDescriptorType.Long => typeof(JLong).GetTypeInfo(),
            JavaDescriptorType.Float => typeof(JFloat).GetTypeInfo(),
            JavaDescriptorType.Double => typeof(JDouble).GetTypeInfo(),
            _ => throw new NotImplementedException(),
        };

        public override TypeInfo GetManagedType(JavaParameterDescriptor descriptor) => descriptor.Type switch
        {
            JavaDescriptorType.Boolean => typeof(bool).GetTypeInfo(),
            JavaDescriptorType.Byte => typeof(sbyte).GetTypeInfo(),
            JavaDescriptorType.Char => typeof(char).GetTypeInfo(),
            JavaDescriptorType.Short => typeof(short).GetTypeInfo(),
            JavaDescriptorType.Int => typeof(int).GetTypeInfo(),
            JavaDescriptorType.Long => typeof(long).GetTypeInfo(),
            JavaDescriptorType.Float => typeof(float).GetTypeInfo(),
            JavaDescriptorType.Double => typeof(double).GetTypeInfo(),
            _ => throw new NotImplementedException(),
        };

        public override Func<Expression, Expression> MarshalParameter(JavaParameterDescriptor descriptor, ref Expression argument)
        {
            argument = Expression.Convert(argument, GetMarshalType(descriptor));
            return body => body;
        }

        public override Expression MarshalReturn(JavaParameterDescriptor descriptor, Expression expression)
        {
            return Expression.Convert(expression, GetManagedType(descriptor));
        }

    }

}
