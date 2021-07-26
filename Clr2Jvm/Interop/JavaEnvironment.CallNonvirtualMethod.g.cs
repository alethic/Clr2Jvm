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

        public readonly static MethodInfo CallNonvirtualBooleanMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualBooleanMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualBooleanMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualBooleanMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualBooleanMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualBooleanMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualBooleanMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JBoolean CallNonvirtualBooleanMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualBooleanMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualByteMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualByteMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualByteMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualByteMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualByteMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualByteMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualByteMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JByte CallNonvirtualByteMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualByteMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualCharMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualCharMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualCharMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualCharMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualCharMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualCharMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualCharMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JChar CallNonvirtualCharMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualCharMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualShortMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualShortMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualShortMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualShortMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualShortMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualShortMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualShortMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JShort CallNonvirtualShortMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualShortMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualIntMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualIntMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualIntMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualIntMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualIntMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualIntMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualIntMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JInt CallNonvirtualIntMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualIntMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualLongMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualLongMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualLongMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualLongMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualLongMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualLongMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualLongMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JLong CallNonvirtualLongMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualLongMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualFloatMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualFloatMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualFloatMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualFloatMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualFloatMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualFloatMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualFloatMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JFloat CallNonvirtualFloatMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualFloatMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualDoubleMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualDoubleMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualDoubleMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualDoubleMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualDoubleMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualDoubleMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualDoubleMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JDouble CallNonvirtualDoubleMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualDoubleMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualObjectMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualObjectMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallNonvirtualObjectMethodA(instance, clazz, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallNonvirtualObjectMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JClass clazz, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallNonvirtualObjectMethod(instance, clazz, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallNonvirtualObjectMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
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

                return CallNonvirtualObjectMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified non-virtual instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JObject CallNonvirtualObjectMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallNonvirtualObjectMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }


    }

}