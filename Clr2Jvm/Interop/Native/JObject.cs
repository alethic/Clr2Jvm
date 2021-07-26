using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jobject'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JObject
    {

        public static implicit operator IntPtr(JObject o) => o.reference;
        public static implicit operator JObject(IntPtr h) => new(h);

        public static readonly JObject Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JObject(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}
