using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Exposes the JNI interface.
    /// </summary>
    unsafe class Jni
    {

        delegate int GetDefaultJavaVMInitArgsDelegate(void* vm_args);
        delegate int GetCreatedJavaVMsDelegate(JniInvokeInterface*** vmBuf, int bufLen, out int nVMs);
        delegate int CreateJavaVMDelegate(JniInvokeInterface*** p_vm, void** p_env, void* vm_args);

        readonly IntPtr handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public Jni(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Invalid handle.");

            this.handle = handle;
        }

        /// <summary>
        /// Creates a managed delegate for a native function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
        T GetDelegateForFunction<T>(string name)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(NativeLibrary.GetExport(handle, name));
        }

        GetDefaultJavaVMInitArgsDelegate ___GetDefaultJavaVMInitArgs;
        GetDefaultJavaVMInitArgsDelegate __GetDefaultJavaVMInitArgs => ___GetDefaultJavaVMInitArgs ??= GetDelegateForFunction<GetDefaultJavaVMInitArgsDelegate>("JNI_GetDefaultJavaVMInitArgs");

        JInt _GetDefaultJavaVMInitArgs(JavaVMInitArgs* vm_args)
        {
            return __GetDefaultJavaVMInitArgs(vm_args);
        }

        /// <summary>
        /// Returns a default configuration for the Java VM. Before calling this function, native code must set the
        /// vm_args->version field to the JNI version it expects the VM to support. After this function returns,
        /// vm_args->version will be set to the actual JNI version the VM supports.
        /// </summary>
        /// <param name="vm_args"></param>
        /// <returns></returns>
        public void GetDefaultJavaVMInitArgs(ref JavaVMInitArgs vm_args)
        {
            var err = _GetDefaultJavaVMInitArgs((JavaVMInitArgs*)Unsafe.AsPointer(ref vm_args));
            if (err != 0)
                throw new JniException(err, nameof(GetDefaultJavaVMInitArgs));
        }

        GetCreatedJavaVMsDelegate ___GetCreatedJavaVMs;
        GetCreatedJavaVMsDelegate __GetCreatedJavaVMs => ___GetCreatedJavaVMs ??= GetDelegateForFunction<GetCreatedJavaVMsDelegate>("JNI_GetCreatedJavaVMs");

        public JInt _GetCreatedJavaVMs(JniInvokeInterface*** vmBuf, JSize bufLen, out JSize nVMs)
        {
            var @return = __GetCreatedJavaVMs(vmBuf, bufLen, out var _nVMs);
            nVMs = _nVMs;
            return @return;
        }

        /// <summary>
        /// Returns all Java VMs that have been created. Pointers to VMs are written in the buffer vmBuf in the order
        /// they are created. At most bufLen number of entries will be written. The total number of created VMs is
        /// returned in *nVMs.
        /// </summary>
        /// <param name="vmBuf"></param>
        /// <param name="nVMs"></param>
        /// <returns></returns>
        public void GetCreatedJavaVMs(JniInvokeInterfacePointerSpan vmBuf, out JSize nVMs)
        {
            fixed (JniInvokeInterfacePointer* _vmBuf_ptr = vmBuf.Span)
            {
                var err = _GetCreatedJavaVMs((JniInvokeInterface***)(void**)_vmBuf_ptr, vmBuf.Span.Length, out nVMs);
                if (err != 0)
                    throw new JniException(err, nameof(GetCreatedJavaVMs));
            }
        }

        CreateJavaVMDelegate ___CreateJavaVM;
        CreateJavaVMDelegate __CreateJavaVM => ___CreateJavaVM ??= GetDelegateForFunction<CreateJavaVMDelegate>("JNI_CreateJavaVM");

        JInt _CreateJavaVM(JniInvokeInterface*** p_vm, JniNativeInterface*** p_env, JavaVMInitArgs* vm_args)
        {
            return __CreateJavaVM(p_vm, (void**)p_env, vm_args);
        }

        /// <summary>
        /// Loads and initializes a Java VM. The current thread becomes the main thread. Sets the env argument to the
        /// JNI interface pointer of the main thread.
        /// </summary>
        /// <param name="p_vm"></param>
        /// <param name="p_env"></param>
        /// <param name="vm_args"></param>
        /// <returns></returns>
        public void CreateJavaVM(out JniInvokeInterfacePointer p_vm, out JniNativeInterfacePointer p_env, ref JavaVMInitArgs vm_args)
        {
            JniInvokeInterface** _p_vm_ptr;
            JniNativeInterface** _p_env_ptr;

            var err = _CreateJavaVM(&_p_vm_ptr, &_p_env_ptr, (JavaVMInitArgs*)Unsafe.AsPointer(ref vm_args));
            if (err != 0)
                throw new JniException(err, nameof(CreateJavaVM));

            p_vm = _p_vm_ptr;
            p_env = _p_env_ptr;
        }

    }

}
