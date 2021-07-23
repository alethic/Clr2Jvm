using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jbyte'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JByte
    {

        public static implicit operator sbyte(JByte o) => o.Value;
        public static implicit operator JByte(sbyte value) => new JByte(value);

        readonly sbyte value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JByte(JByte value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jbyte' value.
        /// </summary>
        public sbyte Value => value;

    }

}
