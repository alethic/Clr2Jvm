using Clr2Jvm.Interop.Native;

using System;

namespace Clr2Jvm.Interop
{

    class JavaThrowableException : JavaException, IDisposable
    {

        /// <summary>
        /// Gets the message for the exception.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="throwable"></param>
        /// <returns></returns>
        static string GetMessage(JavaRuntime runtime, JThrowable throwable)
        {
            var jstring = (JString)runtime.Environment.CallObjectMethod(throwable, "getMessage", "()Ljava/lang/String;");
            if (jstring.IsNull)
                return null;

            var message = runtime.Environment.GetString(jstring);
            return message;
        }

        JavaRuntime runtime;
        JThrowable throwable;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="throwable"></param>
        internal JavaThrowableException(JavaRuntime runtime, JThrowable throwable) :
            base(GetMessage(runtime, throwable))
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (throwable == IntPtr.Zero)
                throw new ArgumentNullException(nameof(throwable));

            this.runtime = runtime;
            this.throwable = (JThrowable)runtime.Environment.NewGlobalRef(throwable);
        }

        /// <summary>
        /// Gets the associated <see cref="JavaRuntime"/>.
        /// </summary>
        internal JavaRuntime Runtime => runtime;

        /// <summary>
        /// Gets the associated <see cref="JObject"/>.
        /// </summary>
        internal JThrowable Handle => throwable;

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                runtime.Environment.SafeDeleteGlobalRef(throwable);
                throwable = IntPtr.Zero;
                runtime = null;

                disposed = true;
            }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~JavaThrowableException()
        {
            Dispose(false);
        }

    }

}
