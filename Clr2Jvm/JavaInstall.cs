using Clr2Jvm.Interop.Native;

using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Clr2Jvm
{

    /// <summary>
    /// Represents a JRE installation.
    /// </summary>
    public class JavaInstall
    {

        static readonly Lazy<JavaInstall> @default = new(() => new JavaInstall(DefaultOptions, DefaultJvmLibName));

        /// <summary>
        /// Gets or sets the default JVM library name or path.
        /// </summary>
        public static string DefaultJvmLibName { get; set; } = "jvm";

        /// <summary>
        /// Gets the default Java Runtime Options. Ensure this variable is configured before accessing the <see cref="Default"/> property.
        /// </summary>
        public static JavaOptions DefaultOptions { get; set; } = new JavaOptions();

        /// <summary>
        /// Gets the default Java Runtime.
        /// </summary>
        public static JavaInstall Default => @default.Value;

        readonly Jni jni;
        readonly object syncRoot = new();
        readonly JavaOptions defaultOptions;
        readonly Lazy<JavaRuntime> runtime;
        readonly ConcurrentDictionary<JniInvokeInterfacePointer, JavaRuntime> runtimes = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public JavaInstall(JavaOptions defaultOptions = null, string jvmLibName = "jvm")
        {
            this.defaultOptions = defaultOptions ?? DefaultOptions ?? new JavaOptions();
            this.runtime = new Lazy<JavaRuntime>(() => GetOrCreateRuntime(DefaultOptions));
            this.jni = new Jni(Path.HasExtension(jvmLibName) ? NativeLibrary.Load(jvmLibName) : NativeLibrary.Load(jvmLibName, typeof(JavaInstall).Assembly, DllImportSearchPath.SafeDirectories));
        }

        /// <summary>
        /// Gets a reference to the default Java runtime instance.
        /// </summary>
        public JavaRuntime Runtime => runtime.Value;

        /// <summary>
        /// Refreshes the list of known runtimes.
        /// </summary>
        unsafe void LoadInstances()
        {
            lock (syncRoot)
            {
                var vms = (Span<JniInvokeInterfacePointer>)stackalloc JniInvokeInterfacePointer[16];
                jni.GetCreatedJavaVMs(vms, out var nVMs);

                // initialize new JRE instances, and track those remaining
                var del = new HashSet<JniInvokeInterfacePointer>(runtimes.Keys);
                for (var i = 0; i < nVMs; i++)
                    del.Remove(runtimes.AddOrUpdate(vms[i], _ => new JavaRuntime(this, null, new JavaVM(_)), (_, __) => __).VM.Handle);

                // clean up missing VMs
                foreach (var jre in del)
                    runtimes.TryRemove(jre, out _);
            }
        }

        /// <summary>
        /// Gets the existing <see cref="JavaRuntime"/> or attempts to initialize it.
        /// </summary>
        /// <returns></returns>
        unsafe JavaRuntime GetOrCreateRuntime(JavaOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            lock (syncRoot)
            {
                LoadInstances();

                // check for existing JREs
                if (runtimes.Count > 0)
                    if (runtimes.FirstOrDefault().Value is JavaRuntime jre_)
                        return jre_;

                // create new JRE
                var jre = CreateJavaRuntime(options);
                if (jre == null)
                    throw new JavaException("Null result creating JVM.");
                if (runtimes.TryAdd(jre.VM.Handle, jre) == false)
                    throw new JavaException("Failed to add JRE.");
                if (runtimes.IsEmpty)
                    throw new JavaException("No JREs available.");

                return jre;
            }
        }

        /// <summary>
        /// Creates a new JVM instance.
        /// </summary>
        unsafe JavaRuntime CreateJavaRuntime(JavaOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // initialize arguments
            var args = new JavaVMInitArgs();
            args.Version = JavaRuntime.MinJniVersion;
            jni.GetDefaultJavaVMInitArgs(ref args);

            // assemble JVM options
            var optsList = new List<string>();
            if (options.Options != null && options.Options.Count > 0)
                optsList.AddRange(options.Options);

            // marshal assembled options into native array
            var enc = JavaUtf8Encoding.Default;
            var osz = optsList.Count + 1;
            var opt = osz > 128 ? new JavaVMOption[osz] : stackalloc JavaVMOption[osz];
            var opm = new IMemoryOwner<byte>[osz];
            var oph = new MemoryHandle[osz];

            try
            {
                // copy arguments into options list
                for (int i = 0; i < optsList.Count; i++)
                {
                    var s = optsList[i];
                    opm[i] = MemoryPool<byte>.Shared.Rent(enc.GetByteCount(s));
                    enc.GetBytes(s, opm[i].Memory.Span);
                    oph[i] = opm[i].Memory.Pin();
                    opt[i].optionString = (byte*)oph[i].Pointer;
                }

                try
                {
                    // invoke creation of VM
                    jni.CreateJavaVM(out var vm_ptr, out var env_ptr, ref args);
                    if (vm_ptr.IsNull)
                        throw new JavaException("JRE VM result was null.");
                    if (env_ptr.IsNull)
                        throw new JavaException("JRE environment result was null.");

                    // create new runtime instance and return
                    return new JavaRuntime(this, options, new JavaVM(vm_ptr));
                }
                catch (JniException e)
                {
                    throw new JavaException("Exception occurred creating Java VM.", e);
                }
            }
            finally
            {
                // attempt to discard the allocated memory
                for (int i = 0; i < optsList.Count; i++)
                {
                    oph[i].Dispose();
                    opm[i].Dispose();
                }
            }
        }

    }

}
