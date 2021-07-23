using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jboolean'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JBoolean
    {

        public static implicit operator byte(JBoolean o) => o.Value;
        public static implicit operator JBoolean(byte value) => new JBoolean(value);

        public static implicit operator bool(JBoolean o) => o.Value != 0;
        public static implicit operator JBoolean(bool value) => new JBoolean(value ? (byte)1 : (byte)0);

        readonly byte value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JBoolean(byte value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jboolean' value.
        /// </summary>
        public byte Value => value;

    }

}
