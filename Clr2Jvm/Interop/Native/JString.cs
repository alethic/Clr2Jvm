using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jstring'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JString
    {

        public static implicit operator IntPtr(JString o) => o.reference;
        public static implicit operator JString(IntPtr h) => new(h);

        public static implicit operator JObject(JString h) => new(h);
        public static explicit operator JString(JObject h) => new(h);

        public static readonly JString Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JString(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;
    }

}
