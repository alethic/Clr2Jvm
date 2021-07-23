using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jboolean'.
    /// </summary>
    readonly ref struct JBooleanSpan
    {

        public static implicit operator Span<byte>(JBooleanSpan o) => o.Span;
        public static implicit operator JBooleanSpan(Span<byte> h) => new JBooleanSpan(h);

        readonly Span<byte> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JBooleanSpan(Span<byte> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jboolean'.
        /// </summary>
        public Span<byte> Span => span;

    }

}
