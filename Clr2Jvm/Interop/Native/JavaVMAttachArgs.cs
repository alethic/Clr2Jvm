#nullable enable

using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    [StructLayout(LayoutKind.Sequential)]
    struct JavaVMAttachArgs
    {

        public JniVersion Version;
        public IntPtr Name;
        public IntPtr Group;

    }

}

