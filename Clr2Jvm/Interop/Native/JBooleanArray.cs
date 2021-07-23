using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jbooleanArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JBooleanArray
    {

        public static implicit operator IntPtr(JBooleanArray o) => o.Handle;
        public static implicit operator JBooleanArray(IntPtr h) => new JBooleanArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JBooleanArray(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Invalid IntPtr.");

            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jbooleanArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
