using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'char'.
    /// </summary>
    readonly ref struct CharSpan
    {

        public static implicit operator Span<byte>(CharSpan o) => o.Span;
        public static implicit operator CharSpan(Span<byte> h) => new CharSpan(h);

        readonly Span<byte> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public CharSpan(Span<byte> span)
        {
            var b = new JBoolean[12];
            b[3] = 123;

            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'char'.
        /// </summary>
        public Span<byte> Span => span;

    }

}
