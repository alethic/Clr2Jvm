using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java byte.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class ByteMarshalBuilder : ConvertableTypeMarshalBuilder<byte, JByte>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public ByteMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshalType(JavaDescriptorType type)
        {
            return type == JavaDescriptorType.Byte;
        }

    }

}
