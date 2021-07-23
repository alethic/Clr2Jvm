#nullable enable

using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    [StructLayout(LayoutKind.Sequential)]
    struct JavaVMInitArgs
    {

        public JniVersion Version;
        public int NumOptions;
        public IntPtr Options;
        public byte IgnoreUnrecognized;

    }

}

