using System;

namespace Clr2Jvm.Interop
{

    [Serializable]
    public class JavaException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public JavaException()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        public JavaException(string message) :
            base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public JavaException(string message, Exception innerException) :
            base(message, innerException)
        {

        }

    }

}