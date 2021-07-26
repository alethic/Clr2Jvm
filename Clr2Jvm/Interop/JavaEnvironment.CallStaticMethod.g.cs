#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;
using System.Reflection;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;

namespace Clr2Jvm.Interop
{

    partial class JavaEnvironment
    {

        public readonly static MethodInfo CallStaticBooleanMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticBooleanMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticBooleanMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticBooleanMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticBooleanMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticBooleanMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticBooleanMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticBooleanMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticBooleanMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticBooleanMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticBooleanMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticBooleanMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Boolean.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JBoolean CallStaticBooleanMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticBooleanMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticByteMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticByteMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticByteMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticByteMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticByteMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticByteMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticByteMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticByteMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticByteMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticByteMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticByteMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticByteMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Byte.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JByte CallStaticByteMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticByteMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticCharMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticCharMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticCharMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticCharMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticCharMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticCharMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticCharMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticCharMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticCharMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticCharMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticCharMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticCharMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Char.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JChar CallStaticCharMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticCharMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticShortMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticShortMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticShortMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticShortMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticShortMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticShortMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticShortMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticShortMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticShortMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticShortMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticShortMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticShortMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Short.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JShort CallStaticShortMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticShortMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticIntMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticIntMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticIntMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticIntMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticIntMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticIntMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticIntMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticIntMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticIntMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticIntMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticIntMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticIntMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Int.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JInt CallStaticIntMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticIntMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticLongMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticLongMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticLongMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticLongMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticLongMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticLongMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticLongMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticLongMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticLongMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticLongMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticLongMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticLongMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Long.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JLong CallStaticLongMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticLongMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticFloatMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticFloatMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticFloatMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticFloatMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticFloatMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticFloatMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticFloatMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticFloatMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticFloatMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticFloatMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticFloatMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticFloatMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Float.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JFloat CallStaticFloatMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticFloatMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticDoubleMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticDoubleMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticDoubleMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticDoubleMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticDoubleMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticDoubleMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticDoubleMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticDoubleMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticDoubleMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticDoubleMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticDoubleMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticDoubleMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Double.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JDouble CallStaticDoubleMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticDoubleMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallStaticObjectMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticObjectMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallStaticObjectMethodA(clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method, JValue arg1)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[1];
            args[0] = arg1;
            return CallStaticObjectMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[2];
            args[0] = arg1;
            args[1] = arg2;
            return CallStaticObjectMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method, JValue arg1, JValue arg2, JValue arg3)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
                
            var args = (Span<JValue>)stackalloc JValue[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return CallStaticObjectMethod(clazz, method, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticObjectMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, JMethodID method)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallStaticObjectMethod(clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticObjectMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallStaticObjectMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return CallStaticObjectMethod(clazz, name, signature, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticObjectMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns a Java Object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallStaticObjectMethod(cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }


    }

}