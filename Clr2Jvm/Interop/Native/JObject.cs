using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jobject'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JObject
    {

        public static implicit operator IntPtr(JObject o) => o.Handle;
        public static implicit operator JObject(IntPtr h) => new(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JObject(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying handle.
        /// </summary>
        public IntPtr Handle => handle;

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => handle == IntPtr.Zero;

    }

}
