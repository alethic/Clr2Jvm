using System;
using System.Text;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java type signature.
    /// </summary>
    readonly struct JavaParameterDescriptor
    {

        public static JavaParameterDescriptor Void() => new(JavaDescriptorType.Void, null, 0);
        public static JavaParameterDescriptor Boolean() => new(JavaDescriptorType.Boolean, null, 0);
        public static JavaParameterDescriptor Byte() => new(JavaDescriptorType.Byte, null, 0);
        public static JavaParameterDescriptor Char() => new(JavaDescriptorType.Char, null, 0);
        public static JavaParameterDescriptor Short() => new(JavaDescriptorType.Short, null, 0);
        public static JavaParameterDescriptor Int() => new(JavaDescriptorType.Int, null, 0);
        public static JavaParameterDescriptor Long() => new(JavaDescriptorType.Long, null, 0);
        public static JavaParameterDescriptor Float() => new(JavaDescriptorType.Float, null, 0);
        public static JavaParameterDescriptor Double() => new(JavaDescriptorType.Double, null, 0);
        public static JavaParameterDescriptor Object(string clazz) => new(JavaDescriptorType.Object, clazz, 0);

        public static implicit operator JavaParameterDescriptor(string s) => Parse(s);
        public static implicit operator string(JavaParameterDescriptor s) => s.ToString();

        /// <summary>
        /// Parses the given type signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static JavaParameterDescriptor Parse(ReadOnlySpan<char> signature)
        {
            return Parse(signature, out _);
        }

        /// <summary>
        /// Parses the given type signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static JavaParameterDescriptor Parse(ReadOnlySpan<char> signature, out int i)
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
            var p = signature[i] switch
            {
                'V' => JavaDescriptorType.Void,
                'Z' => JavaDescriptorType.Boolean,
                'B' => JavaDescriptorType.Byte,
                'C' => JavaDescriptorType.Char,
                'S' => JavaDescriptorType.Short,
                'I' => JavaDescriptorType.Int,
                'J' => JavaDescriptorType.Long,
                'F' => JavaDescriptorType.Float,
                'D' => JavaDescriptorType.Double,
                'L' => JavaDescriptorType.Object,
                _ => throw new FormatException($"Unexpected type character '{signature[i]}' at index {i}."),
            };

            i++;

            var t = (string)null;
            if (p == JavaDescriptorType.Object)
            {
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

                // advance past ';'
                i++;

                t = new string(m);
            }

            return new JavaParameterDescriptor(p, t, r);
        }

        readonly JavaDescriptorType type;
        readonly string clazz;
        readonly int arrayRank;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="clazz"></param>
        /// <param name="arrayRank"></param>
        public JavaParameterDescriptor(JavaDescriptorType type, string clazz, int arrayRank)
        {
            if (arrayRank < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayRank));
            if (clazz != null && string.IsNullOrWhiteSpace(clazz))
                throw new ArgumentException("Class name must be null or non-empty.", nameof(clazz));

            this.type = type;
            this.clazz = clazz;
            this.arrayRank = arrayRank;
        }

        /// <summary>
        /// Gets the primitive type.
        /// </summary>
        public JavaDescriptorType Type => type;

        /// <summary>
        /// Optionally gets the fully qualified type name if specifying an object.
        /// </summary>
        public string Class => clazz;

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
            var b = new StringBuilder((clazz?.Length ?? 0) + 4);

            for (int i = 0; i < arrayRank; i++)
                b.Append('[');

            b.Append(type switch
            {
                JavaDescriptorType.Void => "V",
                JavaDescriptorType.Boolean => "Z",
                JavaDescriptorType.Byte => "B",
                JavaDescriptorType.Char => "C",
                JavaDescriptorType.Short => "S",
                JavaDescriptorType.Int => "I",
                JavaDescriptorType.Long => "J",
                JavaDescriptorType.Float => "F",
                JavaDescriptorType.Double => "D",
                JavaDescriptorType.Object => "L" + clazz.Replace('.', '/') + ";",
                _ => throw new NotImplementedException(),
            });

            return b.ToString();
        }

    }

}
