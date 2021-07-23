using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    [StructLayout(LayoutKind.Sequential)]
    readonly unsafe struct JniNativeMethod
    {

        public readonly byte* name;
        public readonly byte* signature;
        public readonly void* fnPtr;

    }

}
