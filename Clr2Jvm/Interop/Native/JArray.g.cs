#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Holds a reference to a Java JBoolean array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JBooleanArray
    {

        public static implicit operator IntPtr(JBooleanArray h) => h.reference;
        public static implicit operator JBooleanArray(IntPtr h) => new(h);

        public static implicit operator JObject(JBooleanArray h) => new(h);
        public static implicit operator JArray(JBooleanArray h) => new(h);

        public static explicit operator JBooleanArray(JObject h) => new(h);
        public static explicit operator JBooleanArray(JArray h) => new(h);

        public static readonly JBooleanArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JBooleanArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JByte array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JByteArray
    {

        public static implicit operator IntPtr(JByteArray h) => h.reference;
        public static implicit operator JByteArray(IntPtr h) => new(h);

        public static implicit operator JObject(JByteArray h) => new(h);
        public static implicit operator JArray(JByteArray h) => new(h);

        public static explicit operator JByteArray(JObject h) => new(h);
        public static explicit operator JByteArray(JArray h) => new(h);

        public static readonly JByteArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JByteArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JChar array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JCharArray
    {

        public static implicit operator IntPtr(JCharArray h) => h.reference;
        public static implicit operator JCharArray(IntPtr h) => new(h);

        public static implicit operator JObject(JCharArray h) => new(h);
        public static implicit operator JArray(JCharArray h) => new(h);

        public static explicit operator JCharArray(JObject h) => new(h);
        public static explicit operator JCharArray(JArray h) => new(h);

        public static readonly JCharArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JCharArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JShort array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JShortArray
    {

        public static implicit operator IntPtr(JShortArray h) => h.reference;
        public static implicit operator JShortArray(IntPtr h) => new(h);

        public static implicit operator JObject(JShortArray h) => new(h);
        public static implicit operator JArray(JShortArray h) => new(h);

        public static explicit operator JShortArray(JObject h) => new(h);
        public static explicit operator JShortArray(JArray h) => new(h);

        public static readonly JShortArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JShortArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JInt array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JIntArray
    {

        public static implicit operator IntPtr(JIntArray h) => h.reference;
        public static implicit operator JIntArray(IntPtr h) => new(h);

        public static implicit operator JObject(JIntArray h) => new(h);
        public static implicit operator JArray(JIntArray h) => new(h);

        public static explicit operator JIntArray(JObject h) => new(h);
        public static explicit operator JIntArray(JArray h) => new(h);

        public static readonly JIntArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JIntArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JLong array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JLongArray
    {

        public static implicit operator IntPtr(JLongArray h) => h.reference;
        public static implicit operator JLongArray(IntPtr h) => new(h);

        public static implicit operator JObject(JLongArray h) => new(h);
        public static implicit operator JArray(JLongArray h) => new(h);

        public static explicit operator JLongArray(JObject h) => new(h);
        public static explicit operator JLongArray(JArray h) => new(h);

        public static readonly JLongArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JLongArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JFloat array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JFloatArray
    {

        public static implicit operator IntPtr(JFloatArray h) => h.reference;
        public static implicit operator JFloatArray(IntPtr h) => new(h);

        public static implicit operator JObject(JFloatArray h) => new(h);
        public static implicit operator JArray(JFloatArray h) => new(h);

        public static explicit operator JFloatArray(JObject h) => new(h);
        public static explicit operator JFloatArray(JArray h) => new(h);

        public static readonly JFloatArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JFloatArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JDouble array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JDoubleArray
    {

        public static implicit operator IntPtr(JDoubleArray h) => h.reference;
        public static implicit operator JDoubleArray(IntPtr h) => new(h);

        public static implicit operator JObject(JDoubleArray h) => new(h);
        public static implicit operator JArray(JDoubleArray h) => new(h);

        public static explicit operator JDoubleArray(JObject h) => new(h);
        public static explicit operator JDoubleArray(JArray h) => new(h);

        public static readonly JDoubleArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JDoubleArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

    /// <summary>
    /// Holds a reference to a Java JObject array.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly struct JObjectArray
    {

        public static implicit operator IntPtr(JObjectArray h) => h.reference;
        public static implicit operator JObjectArray(IntPtr h) => new(h);

        public static implicit operator JObject(JObjectArray h) => new(h);
        public static implicit operator JArray(JObjectArray h) => new(h);

        public static explicit operator JObjectArray(JObject h) => new(h);
        public static explicit operator JObjectArray(JArray h) => new(h);

        public static readonly JObjectArray Null = new(IntPtr.Zero);

        readonly IntPtr reference;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="reference"></param>
        public JObjectArray(IntPtr reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Returns <c>true</c> if the handle is null.
        /// </summary>
        public bool IsNull => reference == IntPtr.Zero;

    }

}