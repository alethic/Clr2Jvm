using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jclass'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JClass
    {

        public static implicit operator IntPtr(JClass o) => o.reference;
        public static implicit operator JClass(IntPtr h) => new(h);

        public static implicit operator JObject(JClass c) => c.reference;
        public static explicit operator JClass(JObject o) => new(o);

        public static readonly JClass Null = new(IntPtr.Zero);

        internal readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JClass(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}
