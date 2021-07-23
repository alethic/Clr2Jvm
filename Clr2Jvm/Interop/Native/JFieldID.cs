using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a 'jfieldID'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JFieldID
    {

        public static implicit operator IntPtr(JFieldID o) => o.Handle;
        public static implicit operator JFieldID(IntPtr h) => new JFieldID(h);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JFieldID(IntPtr handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets the underlying jfieldID handle.
        /// </summary>
        public IntPtr Handle => handle;

    }

}
