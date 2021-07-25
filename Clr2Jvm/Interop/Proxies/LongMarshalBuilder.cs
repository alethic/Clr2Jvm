using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java long.
    /// </summary>
    [MarshalBuilder(int.MinValue)]
    class LongMarshalBuilder : ConvertableTypeMarshalBuilder<long, JLong>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public LongMarshalBuilder(JavaRuntime runtime) :
            base(runtime, JavaDescriptorType.Long)
        {

        }

    }

}
