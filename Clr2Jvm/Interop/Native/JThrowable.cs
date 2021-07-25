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

        public static implicit operator IntPtr(JThrowable o) => o.Handle;
        public static implicit operator JThrowable(IntPtr h) => new JThrowable(h);

        public static implicit operator JObject(JThrowable o) => o.Handle;
        public static explicit operator JThrowable(JObject o) => new JThrowable(o.Handle);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JThrowable(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jarray handle.
        /// </summary>
        public IntPtr Handle => handle;

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => handle == IntPtr.Zero;

    }

}
