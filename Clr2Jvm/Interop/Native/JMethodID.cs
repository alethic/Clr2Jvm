using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jmethodID'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JMethodID
    {

        public static implicit operator IntPtr(JMethodID o) => o.Handle;
        public static implicit operator JMethodID(IntPtr h) => new JMethodID(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JMethodID(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying handle.
        /// </summary>
        public IntPtr Handle => handle;

        /// <summary>
        /// Returns <c>true</c> if the method is null.
        /// </summary>
        public bool IsNull => handle == IntPtr.Zero;

    }

}
