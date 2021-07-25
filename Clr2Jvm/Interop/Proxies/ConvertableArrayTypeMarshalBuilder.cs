using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Implements the marshal build logic for a primitive Java array type.
    /// </summary>
    abstract class ConvertableArrayTypeMarshalBuilder<TManaged, TMarshal> : MarshalBuilder
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        protected ConvertableArrayTypeMarshalBuilder(JavaRuntime runtime) : 
            base(runtime)
        {

        }

    }

}
