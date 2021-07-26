using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jthrowable'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JThrowable
    {

        public static implicit operator IntPtr(JThrowable o) => o.reference;
        public static implicit operator JThrowable(IntPtr h) => new(h);

        public static implicit operator JObject(JThrowable o) => o.reference;
        public static explicit operator JThrowable(JObject o) => new(o);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JThrowable(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}
