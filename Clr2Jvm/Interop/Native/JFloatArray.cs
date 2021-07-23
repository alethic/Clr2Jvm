using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jfloatArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JFloatArray
    {

        public static implicit operator IntPtr(JFloatArray o) => o.Handle;
        public static implicit operator JFloatArray(IntPtr h) => new JFloatArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JFloatArray(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Invalid IntPtr.");

            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jfloatArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
