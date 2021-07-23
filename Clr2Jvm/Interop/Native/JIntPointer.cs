using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of jshort memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
     unsafe readonly struct JIntPointer
    {

        public static implicit operator IntPtr(JIntPointer o) => o.Pointer;
        public static implicit operator int*(JIntPointer o) => (int*)o.Pointer;
        public static implicit operator JIntPointer(IntPtr h) => new JIntPointer(h);
        public static implicit operator JIntPointer(int* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JIntPointer(IntPtr pointer)
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
