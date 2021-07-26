using System;

using Clr2Jvm.Interop;
using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Java
{

    /// <summary>
    /// Base type for primitive Java array types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ArrayBase<T> : IJavaObject
    {

        readonly JArray handle;

        /// <summary>
        /// Initializes a new instance. The responsibility to delete the passed handle is with the caller.
        /// </summary>
        /// <param name="handle"></param>
        internal ArrayBase(JavaRuntime runtime, JArray handle)
        {
            if (handle.IsNull)
                throw new ArgumentNullException(nameof(handle));

            this.handle = (JArray)runtime.Environment.NewGlobalRef(handle);
        }

        /// <summary>
        /// Gets the native handle for this instance.
        /// </summary>
        JObject IJavaObject.Handle => handle;

        /// <summary>
        /// Gets or sets an item at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get => GetIndex(index);
            set => SetIndex(index, value);
        }

        /// <summary>
        /// Implements the code to get the value at a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected abstract T GetIndex(int index);

        /// <summary>
        /// Implements the code to set the value at a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected abstract void SetIndex(int index, T value);

    }

}
