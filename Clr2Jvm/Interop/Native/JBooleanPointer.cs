using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a pointer to a region of jboolean memory.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    unsafe readonly struct JBooleanPointer
    {

        public static implicit operator IntPtr(JBooleanPointer o) => o.Pointer;
        public static implicit operator byte*(JBooleanPointer o) => (byte*)o.Pointer;
        public static implicit operator JBooleanPointer(IntPtr h) => new JBooleanPointer(h);
        public static implicit operator JBooleanPointer(byte* h) => (IntPtr)h;

        readonly IntPtr pointer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="pointer"></param>
        public JBooleanPointer(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        /// <summary>
        /// Gets the underlying 'jboolean*' pointer.
        /// </summary>
        public IntPtr Pointer => pointer;

        /// <summary>
        /// Gets whether or not the pointer is null.
        /// </summary>
        public bool IsNull => pointer == IntPtr.Zero;

    }

}
