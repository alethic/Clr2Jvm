using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jchar'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JChar
    {

        public static implicit operator char(JChar o) => o.Value;
        public static implicit operator JChar(char value) => new JChar(value);

        readonly char value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JChar(char value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jchar' value.
        /// </summary>
        public char Value => value;

    }

}
