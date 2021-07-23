using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of JNINativeMethod* memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JniNativeMethodPointer
    {

        public static implicit operator JniNativeMethod*(JniNativeMethodPointer o) => o.Pointer;
        public static implicit operator JniNativeMethodPointer(JniNativeMethod* h) => new JniNativeMethodPointer(h);

        readonly JniNativeMethod* pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JniNativeMethodPointer(JniNativeMethod* pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'JNINativeMethod*' pointer.
        /// </summary>
        public JniNativeMethod* Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == null;

    }

}
