using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jshortArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JShortArray
    {

        public static implicit operator IntPtr(JShortArray o) => o.Handle;
        public static implicit operator JShortArray(IntPtr h) => new JShortArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JShortArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jshortArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
