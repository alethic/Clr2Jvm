using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of JniInvokeInterface memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JniInvokeInterfacePointer
    {

        public static implicit operator JniInvokeInterface**(JniInvokeInterfacePointer o) => o.Pointer;
        public static implicit operator JniInvokeInterfacePointer(JniInvokeInterface** h) => new(h);

        public static bool operator ==(JniInvokeInterfacePointer a, JniInvokeInterfacePointer b) => a.Equals(b);
        public static bool operator !=(JniInvokeInterfacePointer a, JniInvokeInterfacePointer b) => a.Equals(b) == false;

        readonly JniInvokeInterface** pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JniInvokeInterfacePointer(JniInvokeInterface** pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'JniInvokeInterface*' pointer.
        /// </summary>
        public JniInvokeInterface** Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

        /// <summary>
        /// Returns <c>true</c> if the specified instance is equal to this instance.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is JniInvokeInterfacePointer other && Equals(other);
        }

        /// <summary>
        /// Returns <c>true</c> if the specified instance is equal to this instance.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(JniInvokeInterfacePointer other)
        {
            return pointer == other.pointer;
        }

        /// <summary>
        /// Returns <c>true</c> if the specif
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine((IntPtr)pointer);
        }
    }

}
