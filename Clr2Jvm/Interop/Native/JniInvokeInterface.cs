using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    [StructLayout(LayoutKind.Sequential)]
    readonly struct JniInvokeInterface
    {

        readonly IntPtr reserved0;
        readonly IntPtr reserved1;
        readonly IntPtr reserved2;

        public readonly IntPtr DestroyJavaVM;
        public readonly IntPtr AttachCurrentThread;
        public readonly IntPtr DetachCurrentThread;

        public readonly IntPtr GetEnv;

        public readonly IntPtr AttachCurrentThreadAsDaemon;

    }

}
