using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jfloat'.
    /// </summary>
    readonly ref struct JFloatSpan
    {

        public static implicit operator Span<float>(JFloatSpan o) => o.Span;
        public static implicit operator JFloatSpan(Span<float> h) => new JFloatSpan(h);

        readonly Span<float> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JFloatSpan(Span<float> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jfloat'.
        /// </summary>
        public Span<float> Span => span;

    }

}
