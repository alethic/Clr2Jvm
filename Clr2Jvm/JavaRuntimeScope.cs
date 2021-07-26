using System;

namespace Clr2Jvm
{

    /// <summary>
    /// Tracks the ambient <see cref="JavaRuntime"/> instance.
    /// </summary>
    class JavaRuntimeScope : IDisposable
    {

        Action action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runtime"></param>
        public JavaRuntimeScope(Action action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            action();
            action = null;
        }

    }

}
