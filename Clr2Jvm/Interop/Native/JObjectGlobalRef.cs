using System;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents a global reference to a <see cref="JObject"/>.
    /// </summary>
    class JObjectGlobalRef : IDisposable
    {

        public static implicit operator JObject(JObjectGlobalRef r) => r.handle;

        readonly JavaRuntime runtime;
        JObject handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="handle"></param>
        public JObjectGlobalRef(JavaRuntime runtime, JObject handle)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            this.handle = runtime.Environment.NewGlobalRef(handle);
        }

        /// <summary>
        /// Gets the underlying <see cref="JavaRuntime"/>.
        /// </summary>
        public JavaRuntime Runtime => runtime;

        /// <summary>
        /// Gets the underlying global reference.
        /// </summary>
        public JObject Handle => handle;

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            runtime.Environment.SafeDeleteGlobalRef(handle);
            handle = JObject.Null;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the instance.
        /// </summary>
        ~JObjectGlobalRef()
        {
            Dispose();
        }

    }

}
