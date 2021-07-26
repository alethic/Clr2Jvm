using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jshort'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JShort
    {

        public static implicit operator short(JShort o) => o.value;
        public static implicit operator JShort(short value) => new (value);

        readonly short value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JShort(short value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jshort' value.
        /// </summary>
        public short Value => value;

    }

}
