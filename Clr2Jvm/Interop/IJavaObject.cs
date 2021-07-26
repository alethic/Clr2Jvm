using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Describes a managed object which is associted with a Java object.
    /// </summary>
    interface IJavaObject
    {

        /// <summary>
        /// Gets the JNI handle to the Java object.
        /// </summary>
        JObject Handle { get; }

    }

}
