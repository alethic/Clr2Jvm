using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jlong'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JLong
    {

        public static implicit operator long(JLong o) => o.Value;
        public static implicit operator JLong(long value) => new JLong(value);

        readonly long value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JLong(long value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jlong' value.
        /// </summary>
        public long Value => value;

    }

}
