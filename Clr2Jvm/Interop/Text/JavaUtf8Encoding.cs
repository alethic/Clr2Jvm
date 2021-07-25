using System.Text;

namespace Clr2Jvm.Interop.Text
{

    /// <summary>
    /// Implements the Java modified-UTF8 encoding format.
    /// TODO: just calls standard UTF8 for now
    /// </summary>
    class JavaUtf8Encoding : Encoding
    {

        /// <summary>
        /// Gets the default <see cref="JavaUtf8Encoding"/> instance.
        /// </summary>
        public new static JavaUtf8Encoding Default { get; } = new JavaUtf8Encoding();

        readonly Encoding parent = Encoding.UTF8;

        public override int GetByteCount(char[] chars, int index, int count)
        {
            return parent.GetByteCount(chars, index, count);
        }

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return parent.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
        }

        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return parent.GetCharCount(bytes, index, count);
        }

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            return parent.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
        }

        public override int GetMaxByteCount(int charCount)
        {
            return parent.GetMaxByteCount(charCount);
        }

        public override int GetMaxCharCount(int byteCount)
        {
            return parent.GetMaxCharCount(byteCount);
        }

    }

}
