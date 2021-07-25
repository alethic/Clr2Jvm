using System;
using System.Buffers;

namespace Clr2Jvm.Interop.Text
{

    /// <summary>
    /// Supports converting a .NET string into a Java modified UTF-8 string reference.
    /// </summary>
    class JavaUtf8StringReader
    {

        /// <summary>
        /// Gets the default instance.
        /// </summary>
        public static JavaUtf8StringReader Default { get; } = new JavaUtf8StringReader();

        /// <summary>
        /// Marshals the given .NET string into a disposable reference.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public JavaUtf8String Read(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // allocate empty memory for the string output, +1 for null byte
            var enc = JavaUtf8Encoding.Default;
            var len = enc.GetByteCount(value) + 1;
            var mem = MemoryPool<byte>.Shared.Rent(len);
            mem.Memory.Span.Clear();

            // decode the string into the buffer
            var str = mem.Memory.Slice(0, len);
            enc.GetBytes(value, str.Span);

            // return a disposable reference that holds the memory
            return new JavaUtf8String(mem, str);
        }

    }

}
