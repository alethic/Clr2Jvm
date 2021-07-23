using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Provides methods to access the wrapped JNIEnv.
    /// </summary>
    unsafe partial class JniEnv
    {

        /// <summary>
        /// Creates a managed delegate for a native function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
        static T GetDelegateForFunctionPointer<T>(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new JniException("Empty JNIEnv pointer.");

            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
        }

        readonly JniNativeInterface** env;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="ptr"></param>
        public unsafe JniEnv(JniNativeInterface** env)
        {
            if (env == null)
                throw new ArgumentNullException(nameof(env));

            this.env = env;
        }

    }

}
