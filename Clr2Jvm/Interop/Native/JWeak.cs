using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jweak'.
    /// </summary>
    readonly struct JWeak
    {

        public static implicit operator IntPtr(JWeak o) => o.Handle;
        public static implicit operator JWeak(IntPtr h) => new JWeak(h);
        public static implicit operator JObject(JWeak w) => new JObject(w.Handle);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JWeak(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jweak handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
