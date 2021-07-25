using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Reflection
{

    /// <summary>
    /// Describes a Java class field.
    /// </summary>
    class JavaFieldInfo
    {

        readonly JavaReflectedClassInfo cls;
        readonly JFieldID id;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="cls"></param>
        /// <param name="id"></param>
        public JavaFieldInfo(JavaReflectedClassInfo cls, JFieldID id)
        {
            this.cls = cls ?? throw new ArgumentNullException(nameof(cls));
            this.id = id;
        }

    }

}
