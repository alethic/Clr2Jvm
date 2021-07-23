using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of 'jchar' memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JCharPointer
    {

        public static implicit operator IntPtr(JCharPointer o) => o.Pointer;
        public static implicit operator char*(JCharPointer o) => (char*)o.Pointer;
        public static implicit operator JCharPointer(IntPtr h) => new JCharPointer(h);
        public static implicit operator JCharPointer(char* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JCharPointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jchar*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
