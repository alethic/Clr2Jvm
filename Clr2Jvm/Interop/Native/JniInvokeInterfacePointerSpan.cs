using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'JniInvokeInterfacePointer'.
    /// </summary>
    readonly ref struct JniInvokeInterfacePointerSpan
    {

        public static implicit operator Span<JniInvokeInterfacePointer>(JniInvokeInterfacePointerSpan o) => o.Span;
        public static implicit operator JniInvokeInterfacePointerSpan(Span<JniInvokeInterfacePointer> h) => new JniInvokeInterfacePointerSpan(h);

        readonly Span<JniInvokeInterfacePointer> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JniInvokeInterfacePointerSpan(Span<JniInvokeInterfacePointer> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'JniInvokeInterfacePointer'.
        /// </summary>
        public Span<JniInvokeInterfacePointer> Span => span;

    }

}
