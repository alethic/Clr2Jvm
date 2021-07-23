using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jclass'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JClass
    {

        public static implicit operator IntPtr(JClass o) => o.Handle;
        public static implicit operator JClass(IntPtr h) => new JClass(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JClass(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jclass handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
