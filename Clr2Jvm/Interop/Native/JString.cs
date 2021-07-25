using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jstring'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JString
    {

        public static implicit operator IntPtr(JString o) => o.Handle;
        public static implicit operator JString(IntPtr h) => new JString(h);

        public static implicit operator JObject(JString h) => new JObject(h);
        public static explicit operator JString(JObject h) => new JString(h);

        public static readonly JString Null = new JString(IntPtr.Zero);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JString(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jstring' handle.
        /// </summary>
        public IntPtr Handle => handle;

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => handle == IntPtr.Zero;
    }

}
