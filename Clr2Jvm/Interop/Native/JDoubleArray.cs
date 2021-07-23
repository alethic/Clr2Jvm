using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jdoubleArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JDoubleArray
    {

        public static implicit operator IntPtr(JDoubleArray o) => o.Handle;
        public static implicit operator JDoubleArray(IntPtr h) => new JDoubleArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JDoubleArray(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jdoubleArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
