using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct JavaVMOption
    {

        public void* optionString;

        public void* extraInfo;

    }

}