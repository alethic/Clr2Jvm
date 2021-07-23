using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jlongArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JLongArray
    {

        public static implicit operator IntPtr(JLongArray o) => o.Handle;
        public static implicit operator JLongArray(IntPtr h) => new JLongArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JLongArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jlongArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
