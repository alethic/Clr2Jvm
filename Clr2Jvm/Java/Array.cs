using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Java
{

    /// <summary>
    /// Provides a class to implementation of the Java object array type.
    /// </summary>
    public sealed class Array<T> : ArrayBase<T>
    {

        readonly JavaRuntime runtime;
        readonly JArray handle;

        /// <summary>
        /// Allocates a new Double array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JArray NewArray(JavaRuntime runtime, int length)
        {
            var env = runtime.Environment;

            var h = JObjectArray.Null;
            var c = JClass.Null;

            try
            {
                // TODO discover JNI descriptor for typeof(T)
                throw new NotImplementedException();

                return env.NewObjectArray(c, length);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="handle"></param>
        internal Array(JavaRuntime runtime, JArray handle) :
            base(runtime, handle)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        Array(JavaRuntime runtime, int length, JArray h) :
            this(runtime, h = NewArray(runtime, length))
        {
            runtime.Environment.DeleteLocalRef(h);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        Array(int length) :
            this(JavaRuntime.Current, length, JArray.Null)
        {

        }

    }

}
