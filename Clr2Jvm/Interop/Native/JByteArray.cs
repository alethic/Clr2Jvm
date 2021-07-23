using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jbyteArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JByteArray
    {

        public static implicit operator IntPtr(JByteArray o) => o.Handle;
        public static implicit operator JByteArray(IntPtr h) => new JByteArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JByteArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jbyteArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
