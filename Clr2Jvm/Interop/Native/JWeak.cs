using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jweak'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JWeak
    {

        public static implicit operator JWeak(IntPtr h) => new(h);
        public static implicit operator IntPtr(JWeak o) => o.reference;

        public static implicit operator JObject(JWeak w) => new(w.reference);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JWeak(IntPtr reference)
        {
            this.reference = reference;
        }

    }

}
