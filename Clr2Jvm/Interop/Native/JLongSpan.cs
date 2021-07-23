using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jlong'.
    /// </summary>
    readonly ref struct JLongSpan
    {

        public static implicit operator Span<long>(JLongSpan o) => o.Span;
        public static implicit operator JLongSpan(Span<long> h) => new JLongSpan(h);

        readonly Span<long> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JLongSpan(Span<long> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jlong'.
        /// </summary>
        public Span<long> Span => span;

    }

}
