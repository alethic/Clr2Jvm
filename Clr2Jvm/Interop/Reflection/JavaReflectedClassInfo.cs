using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Provides introspection capabilities for a loaded Java class.
    /// </summary>
    class JavaReflectedClassInfo : JavaReflectedInfo
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="handle"></param>
        public JavaReflectedClassInfo(JavaRuntime runtime, JClass handle) :
            base(runtime, handle)
        {

        }

        /// <summary>
        /// Gets the underlying handle.
        /// </summary>
        public new JClass Handle => base.Handle.Handle;

        /// <summary>
        /// Fetches the constructors from the referenced class.
        /// </summary>
        /// <returns></returns>
        JavaReflectedMethodInfo GetDeclaredMethod(string name, params JavaReflectedClassInfo[] parameters)
        {
            var cls = new JClass();
            var mth = new JObject();
            var env = Runtime.Environment;

            try
            {
                cls = env.FindClass("java/lang/Class");
                if (cls.IsNull)
                    throw new JavaException("Could not load 'java.lang.Class'.");

                mth = env.CallStaticObjectMethod(cls, "getDeclaredMethod", "(Ljava/lang/String;[Ljava/lang/Class);[Ljava/lang/reflect/Method");
                if (mth.IsNull)
                    return null;

                return new JavaReflectedMethodInfo(Runtime, this, mth);
            }
            finally
            {
                env.SafeDeleteLocalRef(cls);
                env.SafeDeleteLocalRef(mth);
            }
        }

    }

}
