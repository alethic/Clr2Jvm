using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jobjectArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JObjectArray
    {

        public static implicit operator IntPtr(JObjectArray o) => o.Handle;
        public static implicit operator JObjectArray(IntPtr h) => new JObjectArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JObjectArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jobjectArray handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
