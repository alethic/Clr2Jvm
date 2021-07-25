using System;
using System.Buffers;

namespace Clr2Jvm.Interop.Text
{

    /// <summary>
    /// Represents a marshalled string.
    /// </summary>
    unsafe readonly struct JavaUtf8String : IDisposable
    {

        readonly IMemoryOwner<byte> owner;
        readonly Memory<byte> buffer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="buffer"></param>
        public JavaUtf8String(IMemoryOwner<byte> owner, Memory<byte> buffer)
        {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            this.buffer = buffer;
        }

        /// <summary>
        /// Gets the underlying data of the UTF8 string.
        /// </summary>
        public ReadOnlySpan<byte> Span => buffer.Span;

        /// <summary>
        /// Pins the string in place for use in unmanaged code.
        /// </summary>
        /// <returns></returns>
        public MemoryHandle Pin() => buffer.Pin();

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            owner.Dispose();
        }

    }

}