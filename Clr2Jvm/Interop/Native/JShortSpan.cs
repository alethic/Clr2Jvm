using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jshort'.
    /// </summary>
    readonly ref struct JShortSpan
    {

        public static implicit operator Span<short>(JShortSpan o) => o.Span;
        public static implicit operator JShortSpan(Span<short> h) => new JShortSpan(h);

        readonly Span<short> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JShortSpan(Span<short> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jshort'.
        /// </summary>
        public Span<short> Span => span;

    }

}
