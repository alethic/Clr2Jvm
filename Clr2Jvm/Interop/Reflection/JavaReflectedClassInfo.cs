using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Provides native introspection capabilities for a loaded Java class.
    /// </summary>
    class JavaReflectedClassInfo
    {

        readonly JObjectGlobalRef reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="handle"></param>
        public JavaReflectedClassInfo(JavaRuntime runtime, JClass handle)
        {
            if (runtime is null)
                throw new ArgumentNullException(nameof(runtime));
            if (handle.IsNull)
                throw new ArgumentNullException(nameof(handle));

            reference = new JObjectGlobalRef(runtime, handle);
        }

        /// <summary>
        /// Gets the reference to the associated native class.
        /// </summary>
        public JObjectGlobalRef Ref => reference;

        /// <summary>
        /// Fetches the constructors from the referenced class.
        /// </summary>
        /// <returns></returns>
        JavaReflectedMethodInfo GetDeclaredMethod(string name, params JavaReflectedClassInfo[] parameters)
        {
            var cls = new JClass();
            var mth = new JObject();
            var env = Ref.Runtime.Environment;

            try
            {
                cls = env.FindClass("java/lang/Class");
                if (cls.IsNull)
                    throw new JavaException("Could not load 'java.lang.Class'.");

                mth = env.CallStaticObjectMethod(cls, "getDeclaredMethod", "(Ljava/lang/String;[Ljava/lang/Class);[Ljava/lang/reflect/Method");
                if (mth.IsNull)
                    return null;

                env.FromReflectedMethod

                return new JavaReflectedMethodInfo(Ref.Runtime, this, mth);
            }
            finally
            {
                env.SafeDeleteLocalRef(cls);
                env.SafeDeleteLocalRef(mth);
            }
        }

    }

}
