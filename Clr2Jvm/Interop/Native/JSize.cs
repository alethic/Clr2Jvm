using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jsize'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JSize
    {

        public static implicit operator int(JSize o) => o.value;
        public static implicit operator JSize(int value) => new(value);

        readonly int value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JSize(int value)
        {
            this.value = value;
        }

    }

}
