using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java char.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class CharMarshalBuilder : ConvertableTypeMarshalBuilder<char, JChar>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public CharMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshalType(JavaDescriptorType type)
        {
            return type == JavaDescriptorType.Char;
        }

    }

}
