using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jarray'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JArray
    {

        public static implicit operator IntPtr(JArray o) => o.reference;
        public static implicit operator JArray(IntPtr h) => new(h);

        public static implicit operator JObject(JArray o) => o.reference;
        public static explicit operator JArray(JObject o) => new(o);

        public static readonly JArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}
