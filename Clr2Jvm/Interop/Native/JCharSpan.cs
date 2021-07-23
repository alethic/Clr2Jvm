using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jchar'.
    /// </summary>
    readonly ref struct JCharSpan
    {

        public static implicit operator Span<char>(JCharSpan o) => o.Span;
        public static implicit operator JCharSpan(Span<char> h) => new JCharSpan(h);

        readonly Span<char> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JCharSpan(Span<char> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jchar'.
        /// </summary>
        public Span<char> Span => span;

    }

}
