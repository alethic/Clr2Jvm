#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;
using System.Runtime.InteropServices;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop
{

    partial class JavaEnvironment
    {

        /// <summary>
        /// Creates a new Boolean array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JBooleanArray NewBooleanArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewBooleanArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetBooleanArrayRegion(JBooleanArray array, int start, ReadOnlySpan<JBoolean> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetBooleanArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetBooleanArrayElement(JBooleanArray array, int index, JBoolean value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetBooleanArrayRegion(array, index, stackalloc JBoolean[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetBooleanArrayRegion(JBooleanArray array, int start, Span<JBoolean> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetBooleanArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JBoolean GetBooleanArrayElement(JBooleanArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JBoolean>)stackalloc JBoolean[1];
            GetBooleanArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Creates a new Byte array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JByteArray NewByteArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewByteArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetByteArrayRegion(JByteArray array, int start, ReadOnlySpan<JByte> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetByteArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetByteArrayElement(JByteArray array, int index, JByte value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetByteArrayRegion(array, index, stackalloc JByte[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetByteArrayRegion(JByteArray array, int start, Span<JByte> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetByteArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JByte GetByteArrayElement(JByteArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JByte>)stackalloc JByte[1];
            GetByteArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetByteArrayRegion(JByteArray array, int start, ReadOnlySpan<sbyte> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetByteArrayRegion(array, start, MemoryMarshal.Cast<sbyte, JByte>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetByteArrayElement(JByteArray array, int index, sbyte value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetByteArrayRegion(array, index, stackalloc sbyte[] { value });
        }

        /// <summary>
        /// Creates a new Char array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JCharArray NewCharArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewCharArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetCharArrayRegion(JCharArray array, int start, ReadOnlySpan<JChar> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetCharArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetCharArrayElement(JCharArray array, int index, JChar value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetCharArrayRegion(array, index, stackalloc JChar[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetCharArrayRegion(JCharArray array, int start, Span<JChar> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetCharArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JChar GetCharArrayElement(JCharArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JChar>)stackalloc JChar[1];
            GetCharArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetCharArrayRegion(JCharArray array, int start, ReadOnlySpan<char> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetCharArrayRegion(array, start, MemoryMarshal.Cast<char, JChar>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetCharArrayElement(JCharArray array, int index, char value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetCharArrayRegion(array, index, stackalloc char[] { value });
        }

        /// <summary>
        /// Creates a new Short array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JShortArray NewShortArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewShortArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetShortArrayRegion(JShortArray array, int start, ReadOnlySpan<JShort> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetShortArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetShortArrayElement(JShortArray array, int index, JShort value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetShortArrayRegion(array, index, stackalloc JShort[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetShortArrayRegion(JShortArray array, int start, Span<JShort> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetShortArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JShort GetShortArrayElement(JShortArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JShort>)stackalloc JShort[1];
            GetShortArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetShortArrayRegion(JShortArray array, int start, ReadOnlySpan<short> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetShortArrayRegion(array, start, MemoryMarshal.Cast<short, JShort>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetShortArrayElement(JShortArray array, int index, short value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetShortArrayRegion(array, index, stackalloc short[] { value });
        }

        /// <summary>
        /// Creates a new Int array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JIntArray NewIntArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewIntArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetIntArrayRegion(JIntArray array, int start, ReadOnlySpan<JInt> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetIntArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetIntArrayElement(JIntArray array, int index, JInt value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetIntArrayRegion(array, index, stackalloc JInt[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetIntArrayRegion(JIntArray array, int start, Span<JInt> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetIntArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JInt GetIntArrayElement(JIntArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JInt>)stackalloc JInt[1];
            GetIntArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetIntArrayRegion(JIntArray array, int start, ReadOnlySpan<int> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetIntArrayRegion(array, start, MemoryMarshal.Cast<int, JInt>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetIntArrayElement(JIntArray array, int index, int value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetIntArrayRegion(array, index, stackalloc int[] { value });
        }

        /// <summary>
        /// Creates a new Long array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JLongArray NewLongArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewLongArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetLongArrayRegion(JLongArray array, int start, ReadOnlySpan<JLong> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetLongArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetLongArrayElement(JLongArray array, int index, JLong value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetLongArrayRegion(array, index, stackalloc JLong[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetLongArrayRegion(JLongArray array, int start, Span<JLong> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetLongArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JLong GetLongArrayElement(JLongArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JLong>)stackalloc JLong[1];
            GetLongArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetLongArrayRegion(JLongArray array, int start, ReadOnlySpan<long> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetLongArrayRegion(array, start, MemoryMarshal.Cast<long, JLong>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetLongArrayElement(JLongArray array, int index, long value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetLongArrayRegion(array, index, stackalloc long[] { value });
        }

        /// <summary>
        /// Creates a new Float array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JFloatArray NewFloatArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewFloatArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetFloatArrayRegion(JFloatArray array, int start, ReadOnlySpan<JFloat> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetFloatArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetFloatArrayElement(JFloatArray array, int index, JFloat value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetFloatArrayRegion(array, index, stackalloc JFloat[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetFloatArrayRegion(JFloatArray array, int start, Span<JFloat> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetFloatArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JFloat GetFloatArrayElement(JFloatArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JFloat>)stackalloc JFloat[1];
            GetFloatArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetFloatArrayRegion(JFloatArray array, int start, ReadOnlySpan<float> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetFloatArrayRegion(array, start, MemoryMarshal.Cast<float, JFloat>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetFloatArrayElement(JFloatArray array, int index, float value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetFloatArrayRegion(array, index, stackalloc float[] { value });
        }

        /// <summary>
        /// Creates a new Double array of the specified size.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JDoubleArray NewDoubleArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewDoubleArray(length);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetDoubleArrayRegion(JDoubleArray array, int start, ReadOnlySpan<JDouble> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.SetDoubleArrayRegion(array, start, values.Length, values);
            ThrowIfException();
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetDoubleArrayElement(JDoubleArray array, int index, JDouble value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
                
            SetDoubleArrayRegion(array, index, stackalloc JDouble[] { value });
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetDoubleArrayRegion(JDoubleArray array, int start, Span<JDouble> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            env.GetDoubleArrayRegion(array, start, buffer.Length, buffer);
            ThrowIfException();
        }

        /// <summary>
        /// Gets the value of the array at the specified index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JDouble GetDoubleArrayElement(JDoubleArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var buffer = (Span<JDouble>)stackalloc JDouble[1];
            GetDoubleArrayRegion(array, index, buffer);
            return buffer[0];
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetDoubleArrayRegion(JDoubleArray array, int start, ReadOnlySpan<double> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            SetDoubleArrayRegion(array, start, MemoryMarshal.Cast<double, JDouble>(values));
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetDoubleArrayElement(JDoubleArray array, int index, double value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetDoubleArrayRegion(array, index, stackalloc double[] { value });
        }
    }

}