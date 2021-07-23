using System;
using System.Buffers;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Provides high level methods for the current JNI environment.
    /// </summary>
    public class JavaEnvironment
    {

        readonly JniEnv env;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="env"></param>
        internal JavaEnvironment(JniEnv env)
        {
            this.env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public unsafe IntPtr FindClass(string name)
        {
            var _name_len = JavaUtf8Encoding.Default.GetByteCount(name) + 2;
            using var _name = MemoryPool<byte>.Shared.Rent(_name_len);
            using var _name_pin = _name.Memory.Pin();
            var _name_buf = _name.Memory.Span.Slice(0, _name_len);
            JavaUtf8Encoding.Default.GetBytes(name, _name_buf);

            fixed (byte* _name_ptr = _name_buf)
            {
                return env.FindClass(_name_ptr);
            }
        }

    }

}
