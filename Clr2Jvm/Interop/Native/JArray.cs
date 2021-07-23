using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jarray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JArray
    {

        public static implicit operator IntPtr(JArray o) => o.Handle;
        public static implicit operator JArray(IntPtr h) => new JArray(h);

        public static implicit operator JObject(JArray o) => o.Handle;
        public static explicit operator JArray(JObject o) => new JArray(o.Handle);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JArray(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Invalid IntPtr.");

            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jarray handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
