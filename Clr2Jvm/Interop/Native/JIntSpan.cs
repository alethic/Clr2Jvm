using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jint'.
    /// </summary>
    readonly ref struct JIntSpan
    {

        public static implicit operator Span<int>(JIntSpan o) => o.Span;
        public static implicit operator JIntSpan(Span<int> h) => new JIntSpan(h);

        readonly Span<int> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JIntSpan(Span<int> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jint'.
        /// </summary>
        public Span<int> Span => span;

    }

}
