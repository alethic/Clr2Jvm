using System;
using System.Text;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java type signature.
    /// </summary>
    readonly struct JavaClassDescriptor
    {

        public static implicit operator JavaClassDescriptor(string s) => Parse(s);
        public static implicit operator string(JavaClassDescriptor s) => s.ToString();

        /// <summary>
        /// Parses the given type signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static JavaClassDescriptor Parse(ReadOnlySpan<char> signature)
        {
            return Parse(signature, out _);
        }

        /// <summary>
        /// Parses the given type signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static JavaClassDescriptor Parse(ReadOnlySpan<char> signature, out int i)
        {
            // start at beginning
            i = 0;
            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            // accept each rank
            var r = 0;
            while (i < signature.Length && signature[i] == '[')
            {
                r++;
                i++;
            }

            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            // check type indicator
            if (r > 0)
            {
                if (signature[i] != 'L')
                    throw new FormatException("Unexpected type specification.");

                i++;
            }

            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            var s = i;

            // advance until we're at the end
            while (i < signature.Length && signature[i] != ';')
                i++;

            // create new type name with / replaced with .
            var m = (Span<char>)new char[i - s];
            for (var j = s; j < i; j++)
                m[j - s] = signature[j] != '/' ? signature[j] : '.';

            var t = new string(m);

            return new JavaClassDescriptor(t, r);
        }

        readonly string name;
        readonly int arrayRank;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arrayRank"></param>
        /// <param name="name"></param>
        public JavaClassDescriptor(string name, int arrayRank)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.arrayRank = arrayRank;
        }

        /// <summary>
        /// Optionally gets the fully qualified type name if specifying an object.
        /// </summary>
        public string TypeName => name;

        /// <summary>
        /// Gets the rank of the type if it is an array.
        /// </summary>
        public int ArrayRank => arrayRank;

        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var b = new StringBuilder((name?.Length ?? 0) + 4);

            for (int i = 0; i < arrayRank; i++)
                b.Append('[');
            if (arrayRank > 0)
                b.Append('L');

            b.Append(name.Replace('.', '/'));

            if (arrayRank > 0)
                b.Append(';');

            return b.ToString();
        }

    }

}
