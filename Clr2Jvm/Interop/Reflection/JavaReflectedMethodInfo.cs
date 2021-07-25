using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java class field.
    /// </summary>
    class JavaReflectedMethodInfo : JavaReflectedInfo
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public JavaReflectedMethodInfo(JavaRuntime runtime, JavaReflectedClassInfo clazz, JObject method) :
            base(runtime, method)
        {

        }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public string Name;

    }

}
