using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of 'void' memory.
    /// </summary>
    public unsafe struct JVoidPointer
    {

        public static implicit operator IntPtr(JVoidPointer o) => o.Pointer;
        public static implicit operator void*(JVoidPointer o) => (void*)o.Pointer;
        public static implicit operator JVoidPointer(IntPtr h) => new JVoidPointer(h);
        public static implicit operator JVoidPointer(void* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JVoidPointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'void*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
