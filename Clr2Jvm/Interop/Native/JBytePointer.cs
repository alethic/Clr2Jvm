using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of jbyte memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct JBytePointer
    {

        public static implicit operator IntPtr(JBytePointer o) => o.Pointer;
        public static implicit operator sbyte*(JBytePointer o) => (sbyte*)o.Pointer;
        public static implicit operator JBytePointer(IntPtr h) => new JBytePointer(h);
        public static implicit operator JBytePointer(sbyte* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JBytePointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jbyte*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
