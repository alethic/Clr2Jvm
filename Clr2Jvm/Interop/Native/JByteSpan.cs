using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jbyte'.
    /// </summary>
    readonly ref struct JByteSpan
    {

        public static implicit operator Span<sbyte>(JByteSpan o) => o.Span;
        public static implicit operator JByteSpan(Span<sbyte> h) => new JByteSpan(h);

        readonly Span<sbyte> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JByteSpan(Span<sbyte> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jboolean'.
        /// </summary>
        public Span<sbyte> Span => span;

    }

}
