using System;
using System.Threading;

using Clr2Jvm.Interop;
using Clr2Jvm.Interop.Native;

namespace Clr2Jvm
{

    /// <summary>
    /// Represents an instance of the Java Virtual Machine.
    /// </summary>
    public class JavaRuntime
    {

        internal const JniVersion MinJniVersion = JniVersion.V1_6;

        static readonly AsyncLocal<JavaRuntime> current = new();

        /// <summary>
        /// Establishes the specified runtime as the default runtime for the execution context.
        /// </summary>
        /// <param name="runtime"></param>
        /// <returns></returns>
        public static IDisposable BeginScope(JavaRuntime runtime)
        {
            // replace current with new runtime, give disposable back to revert
            var prev = current.Value;
            current.Value = runtime;
            return new JavaRuntimeScope(() => current.Value = prev);
        }

        /// <summary>
        /// Gets the current <see cref="JavaRuntime"/> in scope, or the default if none available.
        /// </summary>
        public static JavaRuntime Current => current.Value ?? JavaInstall.Default.Runtime;

        readonly JavaInstall install;
        readonly JavaOptions options;
        readonly JavaVM jvm;
        readonly ThreadLocal<JavaEnvironment> env;
        readonly JavaObjectManager proxies;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="install"></param>
        /// <param name="options"></param>
        /// <param name="jvm"></param>
        internal JavaRuntime(JavaInstall install, JavaOptions options, JavaVM jvm)
        {
            this.install = install ?? throw new ArgumentNullException(nameof(install));
            this.options = options;
            this.jvm = jvm ?? throw new ArgumentNullException(nameof(jvm));
            this.env = new ThreadLocal<JavaEnvironment>(GetOrCreateEnvironment);
        }

        /// <summary>
        /// Gets the <see cref="JavaOptions"/> which were used to initialize this runtime. Returns <c>null</c> if the
        /// runtime was initialized through other means.
        /// </summary>
        public JavaOptions Options => options;

        /// <summary>
        /// Gets a reference to the underlying native structures.
        /// </summary>
        internal JavaVM VM => jvm;

        /// <summary>
        /// Gets the current <see cref="JavaEnvironment"/>. The <see cref="JavaEnvironment"/> instance is attached to
        /// the JVM and only valid for the current thread.
        /// </summary>
        internal JavaEnvironment Environment => env.Value;

        /// <summary>
        /// Gets or creates a Java Environment for the current thread.
        /// </summary>
        /// <returns></returns>
        JavaEnvironment GetOrCreateEnvironment()
        {
            return GetEnvironment() ?? CreateEnvironment();
        }

        /// <summary>
        /// Gets the existing Java Environment for the currnet thread.
        /// </summary>
        /// <returns></returns>
        unsafe JavaEnvironment GetEnvironment()
        {
            // attempt to attach current thread
            // should return properly for existing attached thread
            var args = new JavaVMAttachArgs();
            args.Version = MinJniVersion;
            jvm.AttachCurrentThread(out var env, ref args);
            if (env.IsNull)
                throw new JavaException("Unable to attach current thread to JVM.");

            // wrap returned interface table
            return new JavaEnvironment(this, new JniEnv(env));
        }

        /// <summary>
        /// Creates a new Java Environment for the current thread.
        /// </summary>
        /// <returns></returns>
        unsafe JavaEnvironment CreateEnvironment()
        {
            // attempt to attach current thread
            // should return properly for existing attached thread
            var args = new JavaVMAttachArgs();
            args.Version = MinJniVersion;
            jvm.AttachCurrentThread(out var env, ref args);
            if (env.IsNull)
                throw new JavaException("Unable to attach current thread to JVM.");

            // wrap returned interface table
            return new JavaEnvironment(this, new JniEnv(env));
        }

    }

}
