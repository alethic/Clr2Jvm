#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Java
{

    /// <summary>
    /// Provides an implementation of the Java primitive Boolean array type.
    /// </summary>
    public sealed class BooleanArray : PrimitiveArray<bool>
    {

        /// <summary>
        /// Allocates a new Boolean array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JBooleanArray.Null;

            try
            {
                h = env.NewBooleanArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal BooleanArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public BooleanArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override bool GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetBooleanArrayElement((JBooleanArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, bool value)
        {
            Ref.Runtime.Environment.SetBooleanArrayElement((JBooleanArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Byte array type.
    /// </summary>
    public sealed class ByteArray : PrimitiveArray<sbyte>
    {

        /// <summary>
        /// Allocates a new Byte array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JByteArray.Null;

            try
            {
                h = env.NewByteArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal ByteArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public ByteArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override sbyte GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetByteArrayElement((JByteArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, sbyte value)
        {
            Ref.Runtime.Environment.SetByteArrayElement((JByteArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Char array type.
    /// </summary>
    public sealed class CharArray : PrimitiveArray<char>
    {

        /// <summary>
        /// Allocates a new Char array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JCharArray.Null;

            try
            {
                h = env.NewCharArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal CharArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public CharArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override char GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetCharArrayElement((JCharArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, char value)
        {
            Ref.Runtime.Environment.SetCharArrayElement((JCharArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Short array type.
    /// </summary>
    public sealed class ShortArray : PrimitiveArray<short>
    {

        /// <summary>
        /// Allocates a new Short array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JShortArray.Null;

            try
            {
                h = env.NewShortArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal ShortArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public ShortArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override short GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetShortArrayElement((JShortArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, short value)
        {
            Ref.Runtime.Environment.SetShortArrayElement((JShortArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Int array type.
    /// </summary>
    public sealed class IntArray : PrimitiveArray<int>
    {

        /// <summary>
        /// Allocates a new Int array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JIntArray.Null;

            try
            {
                h = env.NewIntArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal IntArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public IntArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override int GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetIntArrayElement((JIntArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, int value)
        {
            Ref.Runtime.Environment.SetIntArrayElement((JIntArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Long array type.
    /// </summary>
    public sealed class LongArray : PrimitiveArray<long>
    {

        /// <summary>
        /// Allocates a new Long array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JLongArray.Null;

            try
            {
                h = env.NewLongArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal LongArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public LongArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override long GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetLongArrayElement((JLongArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, long value)
        {
            Ref.Runtime.Environment.SetLongArrayElement((JLongArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Float array type.
    /// </summary>
    public sealed class FloatArray : PrimitiveArray<float>
    {

        /// <summary>
        /// Allocates a new Float array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JFloatArray.Null;

            try
            {
                h = env.NewFloatArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal FloatArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public FloatArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override float GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetFloatArrayElement((JFloatArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, float value)
        {
            Ref.Runtime.Environment.SetFloatArrayElement((JFloatArray)Ref.Handle, index, value);
        }

    }

    /// <summary>
    /// Provides an implementation of the Java primitive Double array type.
    /// </summary>
    public sealed class DoubleArray : PrimitiveArray<double>
    {

        /// <summary>
        /// Allocates a new Double array within Java.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static JObjectGlobalRef NewArray(JavaRuntime runtime, int length)
        {
            if (runtime == null)
                throw new ArgumentNullException(nameof(runtime));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var env = runtime.Environment;

            var h = JDoubleArray.Null;

            try
            {
                h = env.NewDoubleArray(length);
                return new JObjectGlobalRef(runtime, h);
            }
            finally
            {
                env.SafeDeleteLocalRef(h);
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        internal DoubleArray(JObjectGlobalRef reference) :
            base(reference)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="length"></param>
        public DoubleArray(int length) :
            base(NewArray(JavaRuntime.Current, length))
        {

        }

        protected override double GetIndex(int index)
        {
            return Ref.Runtime.Environment.GetDoubleArrayElement((JDoubleArray)Ref.Handle, index);
        }

        protected override void SetIndex(int index, double value)
        {
            Ref.Runtime.Environment.SetDoubleArrayElement((JDoubleArray)Ref.Handle, index, value);
        }

    }

}