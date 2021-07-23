using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jfloat'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JFloat
    {

        public static implicit operator float(JFloat o) => o.Value;
        public static implicit operator JFloat(float value) => new JFloat(value);

        readonly float value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JFloat(float value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jfloat' value.
        /// </summary>
        public float Value => value;

    }

}
