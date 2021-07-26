#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop
{

    partial class JavaEnvironment
    {

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public void SetBooleanArrayRegion(JBooleanArray array, int start, ReadOnlySpan<bool> values)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            var s = (Span<JBoolean>)stackalloc JBoolean[values.Length];
            for (int i = 0; i < values.Length; i++)
                s[i] = values[i];

            SetBooleanArrayRegion(array, start, s);
        }

        /// <summary>
        /// Copies the values into the specified array starting at the specified start index.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetBooleanArrayElement(JBooleanArray array, int index, bool value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            SetBooleanArrayElement(array, index, (JBoolean)value);
        }

        /// <summary>
        /// Copies the values from the specified array beginning at the start index into the buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public void GetBooleanArrayRegion(JBooleanArray array, int start, Span<bool> buffer)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            var b = (Span<JBoolean>)stackalloc JBoolean[buffer.Length];
            GetBooleanArrayRegion(array, start, b);
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = b[i];
        }

    }

}