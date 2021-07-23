using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jcharArray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JCharArray
    {

        public static implicit operator IntPtr(JCharArray o) => o.Handle;
        public static implicit operator JCharArray(IntPtr h) => new JCharArray(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JCharArray(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Invalid IntPtr.");

            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying 'jcharArray' handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
