using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java double.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class DoubleMarshalBuilder : ConvertableTypeMarshalBuilder<double, JDouble>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public DoubleMarshalBuilder(JavaRuntime runtime) :
            base(runtime)
        {

        }

        public override bool CanMarshalType(JavaDescriptorType type)
        {
            return type == JavaDescriptorType.Double;
        }

    }

}
