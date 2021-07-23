using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a reference to a span of 'jdouble'.
    /// </summary>
    readonly ref struct JDoubleSpan
    {

        public static implicit operator Span<double>(JDoubleSpan o) => o.Span;
        public static implicit operator JDoubleSpan(Span<double> h) => new JDoubleSpan(h);

        readonly Span<double> span;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JDoubleSpan(Span<double> span)
        {
            this.span = span;
        }

        /// <summary>
        /// Gets the underlying span of 'jdouble'.
        /// </summary>
        public Span<double> Span => span;

    }

}
