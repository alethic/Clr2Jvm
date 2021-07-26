using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Java
{

    /// <summary>
    /// Base type for primitive Java array types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PrimitiveArray<T> : ArrayBase<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        internal PrimitiveArray(JArray handle) : base(handle)
        {

        }

    }

}
