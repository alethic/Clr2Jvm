using System.Collections.Generic;

namespace Clr2Jvm
{

    /// <summary>
    /// Describes options available to a Java Runtime.
    /// </summary>
    public class JavaOptions
    {

        /// <summary>
        /// Options to pass into the Java Runtime.
        /// </summary>
        public List<string> Options { get; } = new List<string>();

    }

}
