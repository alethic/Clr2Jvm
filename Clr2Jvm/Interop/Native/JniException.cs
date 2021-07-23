using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents an error that occurred interacting with JNI.
    /// </summary>
    public class JniException : Exception
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="message"></param>
        internal JniException(string message) :
            base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="function"></param>
        internal JniException(int errorCode, string function) :
            base($"Error ({errorCode}) returned from {function}.")
        {

        }

    }

}
