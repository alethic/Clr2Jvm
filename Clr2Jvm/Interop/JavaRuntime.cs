using Clr2Jvm.Interop.Native;

using System;
using System.Threading;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Represents an instance of the Java Virtual Machine.
    /// </summary>
    public class JavaRuntime
    {

        internal const Native.JniVersion MinJniVersion = Native.JniVersion.V1_2;

        readonly JavaInstall install;
        readonly JavaOptions options;
        readonly Native.JavaVM vm;
        readonly ThreadLocal<JavaEnvironment> env;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="install"></param>
        /// <param name="options"></param>
        /// <param name="vm"></param>
        internal JavaRuntime(JavaInstall install, JavaOptions options, Native.JavaVM vm)
        {
            this.install = install ?? throw new ArgumentNullException(nameof(install));
            this.options = options;
            this.vm = vm ?? throw new ArgumentNullException(nameof(vm));
            this.env = new ThreadLocal<JavaEnvironment>(GetOrCreateEnvironment);
        }

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
            vm.AttachCurrentThread(out var env, ref args);
            if (env.IsNull)
                throw new JavaException("Unable to attach current thread to JVM.");

            // wrap returned interface table
            return new JavaEnvironment(new JniEnv(env));
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
            vm.AttachCurrentThread(out var env, ref args);
            if (env.IsNull)
                throw new JavaException("Unable to attach current thread to JVM.");

            // wrap returned interface table
            return new JavaEnvironment(new JniEnv(env));
        }

        /// <summary>
        /// Gets a reference to the underlying native structures.
        /// </summary>
        internal Native.JavaVM VM => vm;

        /// <summary>
        /// Gets the <see cref="JavaOptions"/> which were used to initialize this runtime. Returns <c>null</c> if the
        /// runtime was initialized through other means.
        /// </summary>
        public JavaOptions Options => options;

        /// <summary>
        /// Gets the current <see cref="JavaEnvironment"/>. The <see cref="JavaEnvironment"/> instance is attached to
        /// the JVM and only valid for the current thread.
        /// </summary>
        public JavaEnvironment Environment => env.Value;

    }

}
