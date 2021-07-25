using System;
using System.Collections.Generic;
using System.Text;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java method signature.
    /// </summary>
    readonly struct JavaMethodDescriptor
    {

        public static JavaMethodDescriptor Create(JavaParameterDescriptor returnType, params JavaParameterDescriptor[] parameters) => new(returnType, parameters);

        public static implicit operator JavaMethodDescriptor(string s) => Parse(s);
        public static implicit operator string(JavaMethodDescriptor s) => s.ToString();

        /// <summary>
        /// Parses the given method signature.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static JavaMethodDescriptor Parse(ReadOnlySpan<char> signature)
        {
            var i = 0;

            // advance to parameter opening
            while (i < signature.Length && signature[i] != '(')
                i++;

            // advance to first character of first parameter
            i++;
            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            // parse parameter
            var p = new List<JavaParameterDescriptor>();
            while (i < signature.Length && signature[i] != ')')
            {
                // parse individual parameter
                p.Add(JavaParameterDescriptor.Parse(signature[i..], out var j));
                i += j;
            }

            // advance to return value
            i++;
            if (i >= signature.Length)
                throw new FormatException("Unexpected end of string.");

            // parse return value
            var r = JavaParameterDescriptor.Parse(signature[i..], out var k);
            i += k;

            // should have reached the end
            if (i != signature.Length)
                throw new FormatException("Expected end of string.");

            // build final signature
            return new JavaMethodDescriptor(r, p.ToArray());
        }

        readonly JavaParameterDescriptor @return;
        readonly JavaParameterDescriptor[] parameters;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="return"></param>
        /// <param name="parameters"></param>
        public JavaMethodDescriptor(JavaParameterDescriptor @return, params JavaParameterDescriptor[] parameters)
        {
            this.@return = @return;
            this.parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        /// <summary>
        /// Gets the return type of the signature.
        /// </summary>
        public JavaParameterDescriptor Return => @return;

        /// <summary>
        /// Gets the parameter types of the signature.
        /// </summary>
        public IReadOnlyList<JavaParameterDescriptor> Parameters => parameters;

        public override string ToString()
        {
            var b = new StringBuilder(64);
            b.Append('(');
            foreach (var p in parameters)
                b.Append(p);
            b.Append(')');
            b.Append(Return);

            return b.ToString();
        }

    }

}
