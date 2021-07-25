using Clr2Jvm.Interop.Native;

using System;
using System.Buffers;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Provides the capability to marshal .NET strings into pinned references.
    /// </summary>
    class JavaUtf8Marshaller
    {

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static JavaUtf8Marshaller Default { get; } = new JavaUtf8Marshaller();

        /// <summary>
        /// Marshals the given .NET string into a disposable pinned references.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public JavaUtf8String Marshal(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var len = JavaUtf8Encoding.Default.GetByteCount(value) + 2;
            using var mem = MemoryPool<byte>.Shared.Rent(len);
            mem.Memory.Span.Fill(0);
            var str = mem.Memory.Slice(0, len);
            JavaUtf8Encoding.Default.GetBytes(value, str.Span);
            return new JavaUtf8String(mem, str);
        }

    }

}
