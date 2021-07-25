using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a JNI type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JPointer
    {

        public static implicit operator void*(JPointer o) => (void*)o.Pointer;
        public static implicit operator JPointer(void* h) => new JPointer(h);

        public static JPointer Empty => new JPointer((void*)IntPtr.Zero);

        readonly void* pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JPointer(void* pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'void*' pointer.
        /// </summary>
        public void* Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

    }

    /// <summary>
    /// Represents a pointer to a JNI type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JPointer<T>
        where T : unmanaged
    {

        public static implicit operator T*(JPointer<T> o) => (T*)o.Pointer;
        public static implicit operator JPointer<T>(T* h) => new JPointer<T>(h);

        public static JPointer<T> Empty => new JPointer<T>((T*)IntPtr.Zero);

        readonly T* pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JPointer(T* pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jchar*' pointer.
        /// </summary>
        public T* Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

    }

}
