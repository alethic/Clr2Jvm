using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jintArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JIntArray
    {

        public static implicit operator IntPtr(JIntArray o) => o.Handle;
        public static implicit operator JIntArray(IntPtr h) => new JIntArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JIntArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jintArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
