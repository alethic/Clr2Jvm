using Clr2Jvm.Interop.Reflection;

using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Provides high level methods for the current JNI environment.
    /// </summary>
    class JavaEnvironment
    {

        readonly JavaRuntime runtime;
        readonly JniEnv env;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="runtime"></param>
        /// <param name="env"></param>
        internal JavaEnvironment(JavaRuntime runtime, JniEnv env)
        {
            this.runtime = runtime ?? throw new ArgumentNullException(nameof(runtime));
            this.env = env ?? throw new ArgumentNullException(nameof(env));
        }

        /// <summary>
        /// Throws the last exception.
        /// </summary>
        internal void ThrowIfException()
        {
            // check for any exception, and get a reference to it
            var e = env.ExceptionOccurred();
            if (e.IsNull)
                return;

            env.ExceptionClear();
            var x = new JavaThrowableException(runtime, e);
            SafeDeleteLocalRef(e);
            throw x;
        }

        /// <summary>
        /// Allocates a new local reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal JObject NewLocalRef(JObject handle)
        {
            if (handle.IsNull)
                throw new JavaException("Handle must not be null.");

            return env.NewLocalRef(handle);
        }

        /// <summary>
        /// Deletes the specified local reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        internal void DeleteLocalRef(JObject handle)
        {
            if (handle.IsNull)
                throw new JavaException("Handle must not be null.");

            env.DeleteLocalRef(handle);
        }

        /// <summary>
        /// Deletes the specified local reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        internal void SafeDeleteLocalRef(JObject handle)
        {
            if (handle.IsNull == false)
                DeleteLocalRef(handle);
        }

        /// <summary>
        /// Allocates a new global reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal JObject NewGlobalRef(JObject handle)
        {
            if (handle.IsNull)
                throw new JavaException("Handle must not be null.");

            return env.NewGlobalRef(handle);
        }

        /// <summary>
        /// Allocates a new global reference for the specified class.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal JClass NewGlobalRef(JClass handle)
        {
            if (handle.IsNull)
                throw new JavaException("Handle must not be null.");

            return (JClass)env.NewGlobalRef(handle);
        }

        /// <summary>
        /// Deletes the specified global reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        internal void DeleteGlobalRef(JObject handle)
        {
            if (handle.IsNull)
                throw new JavaException("Handle must not be null.");

            env.DeleteGlobalRef(handle);
        }

        /// <summary>
        /// Deletes the specified global reference for the specified object.
        /// </summary>
        /// <param name="handle"></param>
        internal void SafeDeleteGlobalRef(JObject handle)
        {
            if (handle.IsNull == false)
                DeleteGlobalRef(handle);
        }

        /// <summary>
        /// Finds the Java class with the specified name.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public unsafe JClass FindClass(JavaClassDescriptor signature)
        {
            using var _name = JavaUtf8Marshaller.Default.Marshal(signature);

            var cls = env.FindClass(_name);
            ThrowIfException();
            return cls;
        }

        /// <summary>
        /// Gets the value of the Java string.
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public unsafe string GetString(JString @string)
        {
            if (@string.IsNull)
                return null;

            var p = JPointer<JChar>.Empty;
            var c = ReadOnlySpan<JChar>.Empty;

            try
            {
                var l = env.GetStringLength(@string);
                p = env.GetStringChars(@string, out _);
                c = new ReadOnlySpan<JChar>(p, l);
                return new string(MemoryMarshal.Cast<JChar, char>(c));
            }
            finally
            {
                if (p.IsNull == false)
                    env.ReleaseStringChars(@string, c);
            }
        }

        /// <summary>
        /// Finds the Java class with the specified name.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        public unsafe JavaReflectedClassInfo GetClassInfo(JavaClassDescriptor signature)
        {
            var cls = new JClass();

            try
            {
                cls = FindClass(signature);
                if (cls.IsNull)
                    return null;

                return new JavaReflectedClassInfo(runtime, cls);
            }
            finally
            {
                if (cls.IsNull == false)
                    env.DeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Finds the Java field on the given type.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        JFieldID GetFieldID(JClass clazz, string name, JavaFieldDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            using var _name = JavaUtf8Marshaller.Default.Marshal(name);
            using var _signature = JavaUtf8Marshaller.Default.Marshal(signature);

            var ret = env.GetFieldID(clazz, _name, _signature);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Finds the Java field on the given class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JavaFieldInfo GetFieldInfo(JavaReflectedClassInfo clazz, string name, JavaFieldDescriptor signature)
        {
            if (clazz == null)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            var ret = GetFieldID(clazz.Handle, name, signature);
            return ret.IsNull ? null : new JavaFieldInfo(clazz, ret);
        }

        /// <summary>
        /// Converts the given reflected method into a <see cref="JMethodID"/>.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public JMethodID FromReflectedMethod(JObject method)
        {
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return env.FromReflectedMethod(method);
        }

        /// <summary>
        /// Finds the instance method on the given class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JMethodID GetStaticMethodID(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            using var _name = JavaUtf8Marshaller.Default.Marshal(name);
            using var _signature = JavaUtf8Marshaller.Default.Marshal(signature);

            var ret = env.GetStaticMethodID(clazz, _name, _signature);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Finds the instance method on the given class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JavaReflectedMethodInfo GetStaticMethodInfo(JavaReflectedClassInfo clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz == null)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            var m = new JObject();

            try
            {
                var ret = GetStaticMethodID(clazz.Handle, name, signature);
                if (ret.IsNull)
                    return null;

                m = env.ToReflectedMethod(clazz.Handle, ret, false);
                ThrowIfException();
                if (m.IsNull)
                    throw new JavaException("Could not obtain reflected method.");

                return ret.IsNull ? null : new JavaReflectedMethodInfo(runtime, clazz, m);
            }
            finally
            {
                SafeDeleteLocalRef(m);
            }
        }

        /// <summary>
        /// Finds the instance method on the given class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JMethodID GetMethodID(JClass clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            using var _name = JavaUtf8Marshaller.Default.Marshal(name);
            using var _signature = JavaUtf8Marshaller.Default.Marshal(signature);

            var ret = env.GetMethodID(clazz, _name, _signature);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Finds the instance method on the given class.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public JavaReflectedMethodInfo GetMethodInfo(JavaReflectedClassInfo clazz, string name, JavaMethodDescriptor signature)
        {
            if (clazz == null)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

            var m = new JObject();

            try
            {
                var ret = GetMethodID(clazz.Handle, name, signature);
                if (ret.IsNull)
                    return null;

                m = env.ToReflectedMethod(clazz.Handle, ret, false);
                ThrowIfException();
                if (m.IsNull)
                    throw new JavaException("Could not obtain reflected method.");

                return ret.IsNull ? null : new JavaReflectedMethodInfo(runtime, clazz, m);
            }
            finally
            {
                SafeDeleteLocalRef(m);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns void.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            env.CallStaticVoidMethodA(clazz, method, args);
            ThrowIfException();
        }

        /// <summary>
        /// Invokes the specified static method that returns void.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JClass clazz, JMethodID method, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            CallStaticVoidMethod(clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns void.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            CallStaticVoidMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns void.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JClass clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            CallStaticVoidMethod(clazz, name, signature, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns void.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(clazz))
                throw new ArgumentException($"'{nameof(clazz)}' cannot be null or whitespace.", nameof(clazz));
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

                CallStaticVoidMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns an object.
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
        /// Invokes the specified static method that returns an object.
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
        /// Invokes the specified static method that returns an object.
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

            var m = GetMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallStaticObjectMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method that returns an object.
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
        /// Invokes the specified static method that returns an object.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallStaticObjectMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (string.IsNullOrWhiteSpace(clazz))
                throw new ArgumentException($"'{nameof(clazz)}' cannot be null or whitespace.", nameof(clazz));
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

                return CallStaticObjectMethod(cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Invokes the specified static method that returns an object.
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
        /// Invokes the specified static method that returns an object.
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
        /// Invokes the specified static method that returns an object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var c = env.GetObjectClass(instance);
            if (c.IsNull)
                throw new JavaException($"Could not find class for instance.");

            var m = GetMethodID(c, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            return CallObjectMethod(instance, m, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified static method that returns an object.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject CallObjectMethod(JObject instance, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            return CallObjectMethod(instance, name, signature, (ReadOnlySpan<JValue>)args);
        }

    }

}
