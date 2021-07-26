using System;
using System.Reflection;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Marshalling
{

    /// <summary>
    /// Describes a type capable of marshalling from CLR instances to Java instances, and back.
    /// </summary>
    abstract class Marshaller
    {

        readonly JavaRuntime runtime;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        protected Marshaller(JavaRuntime runtime)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
        }

        /// <summary>
        /// Gets the associated runtime.
        /// </summary>
        public JavaRuntime Runtime => runtime;

        /// <summary>
        /// Returns <c>true</c> if this marshaller can marshal for the specified Java class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool CanMarshal(object value);

        /// <summary>
        /// Returns <c>true</c> if this marshaller can marshal for the specified Java class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool CanMarshal(JObject value);

        /// <summary>
        /// Returns the marshal type for the given Java parameter descriptor, or <c>null</c> if this builder does not
        /// suppor the given parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract TypeInfo GetMarshalType(object value);

        /// <summary>
        /// Returns the managed type for the given Java parameter descriptor, or <c>null</c> if this builder does not
        /// support the given parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract TypeInfo GetManagedType(JObject value);

        /// <summary>
        /// Marshals the given managed type to the corresponding Java mapped type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract MarshalledValue Marshal(object value);

        /// <summary>
        /// Returns an expression that marshals the given expression into the given result.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract object MarshalReturn(JObject value);

    }

}
