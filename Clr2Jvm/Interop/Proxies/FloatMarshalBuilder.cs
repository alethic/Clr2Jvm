using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java float.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class FloatMarshalBuilder : ConvertableTypeMarshalBuilder<float, JFloat>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public FloatMarshalBuilder(JavaRuntime runtime) :
            base(runtime, JavaDescriptorType.Float)
        {

        }

    }

}
