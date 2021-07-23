using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of jlong memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JLongPointer
    {

        public static implicit operator IntPtr(JLongPointer o) => o.Pointer;
        public static implicit operator long*(JLongPointer o) => (long*)o.Pointer;
        public static implicit operator JLongPointer(IntPtr h) => new JLongPointer(h);
        public static implicit operator JLongPointer(long* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JLongPointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jlong*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
