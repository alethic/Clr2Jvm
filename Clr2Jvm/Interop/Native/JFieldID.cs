using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jfieldID'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JFieldID
    {

        public static implicit operator IntPtr(JFieldID o) => o.reference;
        public static implicit operator JFieldID(IntPtr h) => new(h);

        internal readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JFieldID(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the method is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}
