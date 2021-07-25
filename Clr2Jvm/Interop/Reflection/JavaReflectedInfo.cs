using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    abstract class JavaReflectedInfo : IDisposable
    {

        JavaRuntime runtime;
        JObject handle;
        bool disposed;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="handle"></param>
        internal JavaReflectedInfo(JavaRuntime runtime, JObject handle)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (handle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(handle));

            this.runtime = runtime;
            this.handle = runtime.Environment.NewGlobalRef(handle);
        }

        /// <summary>
        /// Gets the associated <see cref="JavaRuntime"/>.
        /// </summary>
        internal JavaRuntime Runtime => runtime;

        /// <summary>
        /// Gets the associated <see cref="JObject"/>.
        /// </summary>
        internal JObject Handle => handle;

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

                runtime.Environment.SafeDeleteGlobalRef(handle);
                handle = IntPtr.Zero;
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
        ~JavaReflectedInfo()
        {
            Dispose(false);
        }

    }

}