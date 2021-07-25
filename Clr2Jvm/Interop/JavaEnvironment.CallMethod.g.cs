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

        public readonly static MethodInfo CallBooleanMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallBooleanMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallBooleanMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallBooleanMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallBooleanMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallBooleanMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallBooleanMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Boolean.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JBoolean CallBooleanMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallBooleanMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallByteMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallByteMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallByteMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallByteMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallByteMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallByteMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallByteMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Byte.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JByte CallByteMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallByteMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallCharMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallCharMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallCharMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallCharMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallCharMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallCharMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallCharMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Char.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JChar CallCharMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallCharMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallShortMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallShortMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallShortMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallShortMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallShortMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallShortMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallShortMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Short.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JShort CallShortMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallShortMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallIntMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallIntMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallIntMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallIntMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallIntMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallIntMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallIntMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Int.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JInt CallIntMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallIntMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallLongMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallLongMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallLongMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallLongMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallLongMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallLongMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallLongMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Long.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JLong CallLongMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallLongMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallFloatMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallFloatMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallFloatMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallFloatMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallFloatMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallFloatMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallFloatMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Float.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JFloat CallFloatMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallFloatMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallDoubleMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallDoubleMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallDoubleMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallDoubleMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallDoubleMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallDoubleMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallDoubleMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Double.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JDouble CallDoubleMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallDoubleMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallObjectMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallObjectMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            var ret = env.CallObjectMethodA(instance, method, args);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallObjectMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JMethodID method)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return CallObjectMethod(instance, method, ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            return CallObjectMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallObjectMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified instance method that returns a Java Object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var cls = new JClass();

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return CallObjectMethod(instance, cls, name, signature, ReadOnlySpan<JValue>.Empty);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }


    }

}