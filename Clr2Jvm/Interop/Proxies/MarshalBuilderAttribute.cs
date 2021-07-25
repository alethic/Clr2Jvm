using System;

namespace Clr2Jvm.Interop.Proxies
{

    /// <summary>
    /// Describes a <see cref="MarshalBuilder"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class MarshalBuilderAttribute : Attribute
    {

        readonly int order;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="order"></param>
        public MarshalBuilderAttribute(int order)
        {
            this.order = order;
        }

        /// <summary>
        /// Gets the order for sorting this builder.
        /// </summary>
        public int Order => order;

    }

}
