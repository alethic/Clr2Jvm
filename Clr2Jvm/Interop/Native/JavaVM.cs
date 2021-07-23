using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Wraps the JavaVM JNI interface.
    /// </summary>
    unsafe class JavaVM
    {

        delegate int DestroyJavaVMDelegate(JniInvokeInterface** vm);
        delegate int AttachCurrentThreadDelegate(JniInvokeInterface** vm, void** p_env, void* thr_args);
        delegate int DetachCurrentThreadDelegate(JniInvokeInterface** vm);
        delegate int GetEnvDelegate(JniInvokeInterface** vm, void** env, int version);
        delegate int AttachCurrentThreadAsDaemonDelegate(JniInvokeInterface** vm, void** penv, void* args);

        public static implicit operator JavaVM(JniInvokeInterfacePointer vm) => new(vm);

        /// <summary>
        /// Creates a managed delegate for a native function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
        static T GetDelegateForFunctionPointer<T>(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException(nameof(ptr));

            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
        }

        readonly JniInvokeInterfacePointer handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public JavaVM(JniInvokeInterfacePointer handle)
        {
            if (handle.IsNull)
                throw new ArgumentNullException(nameof(handle));

            this.handle = handle;
        }

        /// <summary>
        /// Unique identifier for the underlying JVM instance.
        /// </summary>
        public JniInvokeInterfacePointer Handle => handle;

        DestroyJavaVMDelegate ___DestroyJavaVM;
        DestroyJavaVMDelegate __DestroyJavaVM => ___DestroyJavaVM ??= GetDelegateForFunctionPointer<DestroyJavaVMDelegate>((*handle.Pointer)->DestroyJavaVM);
        JInt _DestroyJavaVM() => __DestroyJavaVM(handle.Pointer);

        /// <summary>
        /// Unloads a Java VM and reclaims its resources.
        /// </summary>
        void DestroyJavaVM()
        {
            var err = _DestroyJavaVM();
            if (err != 0)
                throw new JniException(err, nameof(DestroyJavaVM));
        }

        AttachCurrentThreadDelegate ___AttachCurrentThread;
        AttachCurrentThreadDelegate __AttachCurrentThread => ___AttachCurrentThread ??= GetDelegateForFunctionPointer<AttachCurrentThreadDelegate>((*handle.Pointer)->AttachCurrentThread);
        JInt _AttachCurrentThread(JniNativeInterface*** p_env, JavaVMAttachArgs* thr_args) => __AttachCurrentThread(handle.Pointer, (void**)p_env, thr_args);

        /// <summary>
        /// Attaches the current thread to a Java VM. Returns a JNI interface pointer in the JNIEnv argument.
        /// </summary>
        /// <param name="p_env"></param>
        /// <param name="thr_args"></param>
        public void AttachCurrentThread(out JniNativeInterfacePointer p_env, ref JavaVMAttachArgs thr_args)
        {
            JniNativeInterface** p_env_ptr;

            var err = _AttachCurrentThread(&p_env_ptr, (JavaVMAttachArgs*)Unsafe.AsPointer(ref thr_args));
            if (err != 0)
                throw new JniException(err, nameof(AttachCurrentThread));

            p_env = p_env_ptr;
        }

        DetachCurrentThreadDelegate ___DetachCurrentThread;
        DetachCurrentThreadDelegate __DetachCurrentThread => ___DetachCurrentThread ??= GetDelegateForFunctionPointer<DetachCurrentThreadDelegate>((*handle.Pointer)->DetachCurrentThread);
        JInt _DetachCurrentThread() => __DetachCurrentThread(handle.Pointer);

        /// <summary>
        /// Detaches the current thread from a Java VM. All Java monitors held by this thread are released. All Java threads waiting for this thread to die are notified.
        /// </summary>
        public void DetachCurrentThread()
        {
            var err = _DetachCurrentThread();
            if (err != 0)
                throw new JniException(err, nameof(DetachCurrentThread));
        }

        GetEnvDelegate ___GetEnv;
        GetEnvDelegate __GetEnv => ___GetEnv ??= GetDelegateForFunctionPointer<GetEnvDelegate>((*handle.Pointer)->GetEnv);
        JInt _GetEnv(JniNativeInterface*** env, JInt version) => __GetEnv(handle.Pointer, (void**)env, version);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="version"></param>
        public void GetEnv(out JniNativeInterfacePointer env, JniVersion version)
        {
            JniNativeInterface** _p_env;

            var err = _GetEnv(&_p_env, (int)version);
            if (err != 0)
                throw new JniException(err, nameof(GetEnv));

            env = _p_env;
        }

        AttachCurrentThreadAsDaemonDelegate ___AttachCurrentThreadAsDaemon;
        AttachCurrentThreadAsDaemonDelegate __AttachCurrentThreadAsDaemon => ___AttachCurrentThreadAsDaemon ??= GetDelegateForFunctionPointer<AttachCurrentThreadAsDaemonDelegate>((*handle.Pointer)->AttachCurrentThreadAsDaemon);
        JInt _AttachCurrentThreadAsDaemon(JniNativeInterface*** env, JavaVMAttachArgs* args) => __AttachCurrentThreadAsDaemon(handle.Pointer, (void**)env, args);

        /// <summary>
        /// Same semantics as AttachCurrentThread, but the newly-created java.lang.Thread instance is a daemon.
        /// </summary>
        /// <param name="env"></param>
        /// <param name="args"></param>
        public void AttachCurrentThreadAsDaemon(out JniNativeInterfacePointer env, ref JavaVMAttachArgs args)
        {
            JniNativeInterface** env_ptr;

            var err = _AttachCurrentThreadAsDaemon(&env_ptr, (JavaVMAttachArgs*)Unsafe.AsPointer(ref args));
            if (err != 0)
                throw new JniException(err, nameof(AttachCurrentThreadAsDaemon));

            env = env_ptr;
        }

    }

}
