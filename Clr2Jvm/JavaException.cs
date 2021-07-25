using Clr2Jvm.Interop.Native;

using System;

namespace Clr2Jvm
{

    public class JavaException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal JavaException()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        internal JavaException(string message) :
            base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        internal JavaException(string message, Exception innerException) :
            base(message, innerException)
        {

        }

    }

}