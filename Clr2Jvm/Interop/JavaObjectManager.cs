using System;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Proxies;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Manages access to proxies.
    /// </summary>
    class JavaObjectManager
    {

        readonly JavaRuntime runtime;
        readonly ProxyMethodBuilder builder;

        readonly JObjectGlobalRef systemRef;
        readonly JMethodID systemIdentityHashCodeMethodId;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        public JavaObjectManager(JavaRuntime runtime)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            this.builder = new ProxyMethodBuilder(runtime);

            var env = runtime.Environment;
            var cls = JClass.Null;

            try
            {
                cls = env.FindClass("java/lang/System");
                if (cls.IsNull)
                    throw new JavaException("Could not find 'java/lang/System'.");

                var method = env.GetStaticMethodID(cls, "identityHashCode", "(Ljava/lang/Object;)I");
                if (method.IsNull)
                    throw new JavaException("Could not find 'java/lang/System:identityHashCode'.");

                systemRef = new JObjectGlobalRef(runtime, cls);
                systemIdentityHashCodeMethodId = method;
            }
            finally
            {
                env.SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Gets the Java system hashcode for the specified object instance.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        int GetSystemHashCode(JObject o) => o.IsNull == false
                ? (int)runtime.Environment.CallStaticIntMethod((JClass)systemRef.Handle, systemIdentityHashCodeMethodId, o)
                : throw new ArgumentNullException(nameof(o));

    }

}