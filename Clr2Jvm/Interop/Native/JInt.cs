using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jint'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JInt
    {

        public static implicit operator int(JInt o) => o.Value;
        public static implicit operator JInt(int value) => new JInt(value);

        readonly int value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JInt(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jint' value.
        /// </summary>
        public int Value => value;

    }

}
