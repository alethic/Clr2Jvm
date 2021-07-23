using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of char memory.
    /// </summary>
    public unsafe struct CharPointer
    {

        public static implicit operator byte*(CharPointer o) => o.Pointer;
        public static implicit operator CharPointer(byte* h) => new(h);

        readonly byte* pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public CharPointer(byte* pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'char*' pointer.
        /// </summary>
        public byte* Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

    }

}
