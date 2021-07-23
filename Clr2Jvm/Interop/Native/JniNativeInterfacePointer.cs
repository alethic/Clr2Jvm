using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of JniNativeInterface memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JniNativeInterfacePointer
    {

        public static implicit operator JniNativeInterface**(JniNativeInterfacePointer o) => o.Pointer;
        public static implicit operator JniNativeInterfacePointer(JniNativeInterface** h) => new(h);

        readonly JniNativeInterface** pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JniNativeInterfacePointer(JniNativeInterface** pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'JniNativeInterface*'.
        /// </summary>
        public JniNativeInterface** Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

    }

}
