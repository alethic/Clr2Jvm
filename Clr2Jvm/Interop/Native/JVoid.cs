using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'void'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JVoid
    {

        public static implicit operator byte(JVoid o) => o.Value;
        public static implicit operator JVoid(byte value) => new JVoid(value);

        readonly byte value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JVoid(byte value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying value.
        /// </summary>
        public byte Value => value;

    }

}
