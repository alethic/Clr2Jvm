using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java class field.
    /// </summary>
    class JavaReflectedMethodInfo
    {

        readonly JavaReflectedClassInfo clazz;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        public JavaReflectedMethodInfo(JavaRuntime runtime, JavaReflectedClassInfo clazz, JMethodID method)
        {
            if (runtime is null)
                throw new ArgumentNullException(nameof(runtime));
            if (clazz == null)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            this.clazz = clazz ?? throw new ArgumentNullException(nameof(clazz));
        }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public string Name => GetName();

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <returns></returns>
        string GetName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the class which owns this method.
        /// </summary>
        public JavaReflectedClassInfo Class { get; }

    }

}
