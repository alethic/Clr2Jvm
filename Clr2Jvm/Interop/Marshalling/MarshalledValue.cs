using System;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop.Marshalling
{

    /// <summary>
    /// Describes a marshalled value that can be released after the marshalled value is used.
    /// </summary>
    struct MarshalledValue : IDisposable
    {

        readonly JavaDescriptorType type;
        readonly JValue value;
        readonly Action<JValue> release;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public MarshalledValue(JavaDescriptorType type, JValue value, Action<JValue> release)
        {
            this.type = type;
            this.value = value;
            this.release = release;
        }

        /// <summary>
        /// Disposes of the isntance
        /// </summary>
        public void Dispose()
        {
            release?.Invoke(value);
        }

    }

}
