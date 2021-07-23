using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of jshort memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JShortPointer
    {

        public static implicit operator IntPtr(JShortPointer o) => o.Pointer;
        public static implicit operator short*(JShortPointer o) => (short*)o.Pointer;
        public static implicit operator JShortPointer(IntPtr h) => new JShortPointer(h);
        public static implicit operator JShortPointer(short* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JShortPointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jshort*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
