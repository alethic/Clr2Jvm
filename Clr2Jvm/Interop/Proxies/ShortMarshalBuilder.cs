using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java short.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class ShortMarshalBuilder : ConvertableTypeMarshalBuilder<short, JShort>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public ShortMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshalType(JavaDescriptorType type)
        {
            return type == JavaDescriptorType.Short;
        }

    }

}
