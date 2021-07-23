using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a 'jdouble'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JDouble
    {

        public static implicit operator double(JDouble o) => o.Value;
        public static implicit operator JDouble(double value) => new JDouble(value);

        readonly double value;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public JDouble(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the underlying 'jdouble' value.
        /// </summary>
        public double Value => value;

    }

}
