using System;
using System.Buffers;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Represents a marshalled string.
    /// </summary>
    unsafe struct JavaUtf8String : IDisposable
    {

        public static implicit operator ReadOnlySpan<byte>(JavaUtf8String s) => s.buffer.Span;

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
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            owner.Dispose();
        }

    }

}