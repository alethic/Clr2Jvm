using System;
using System.Reflection;
using System.Runtime.InteropServices;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Reflection;
using Clr2Jvm.Interop.Text;

namespace Clr2Jvm.Interop
{

    /// <summary>
    /// Provides high level methods for the current JNI environment.
    /// </summary>
    partial class JavaEnvironment
    {

        static class ArgTypes
        {

            public readonly static Type[] CallStaticMethodArgTypes = new[] { typeof(JClass), typeof(JMethodID), typeof(ReadOnlySpan<JValue>) };
            public readonly static Type[] CallMethodArgTypes = new[] { typeof(JObject), typeof(JMethodID), typeof(ReadOnlySpan<JValue>) };
            public readonly static Type[] CallNonvirtualMethodArgTypes = new[] { typeof(JObject), typeof(JClass), typeof(JMethodID), typeof(ReadOnlySpan<JValue>) };

        }

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
            using var _name = JavaUtf8StringReader.Default.Read(signature);

            var cls = env.FindClass(_name.Span);
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
        /// Generates a new <see cref="JString"/> for the given .NET string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public JString NewString(string value)
        {
            return value != null ? env.NewString(MemoryMarshal.Cast<char, JChar>(value.AsSpan()), value.Length) : JString.Null;
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

            using var _name = JavaUtf8StringReader.Default.Read(name);
            using var _signature = JavaUtf8StringReader.Default.Read(signature);

            var ret = env.GetFieldID(clazz, _name.Span, _signature.Span);
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

            using var _name = JavaUtf8StringReader.Default.Read(name);
            using var _signature = JavaUtf8StringReader.Default.Read(signature);

            var ret = env.GetStaticMethodID(clazz, _name.Span, _signature.Span);
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

            using var _name = JavaUtf8StringReader.Default.Read(name);
            using var _signature = JavaUtf8StringReader.Default.Read(signature);

            var ret = env.GetMethodID(clazz, _name.Span, _signature.Span);
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

        public readonly static MethodInfo CallStaticVoidMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallStaticVoidMethod), BindingFlags.Public | BindingFlags.Instance, null, ArgTypes.CallStaticMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified static method.
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
        /// Invokes the specified static method.
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
        /// Invokes the specified static method.
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

            var m = GetStaticMethodID(clazz, name, signature);
            if (m.IsNull)
                throw new JavaException($"Could not find method '{name}'.");

            CallStaticVoidMethod(clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified static method.
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
        /// Invokes the specified static method.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallStaticVoidMethod(JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
        {
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

        public readonly static MethodInfo CallVoidMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallVoidMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified instance method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallVoidMethod(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            env.CallVoidMethodA(instance, method, args);
            ThrowIfException();
        }

        /// <summary>
        /// Invokes the specified instance method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallVoidMethod(JObject instance, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            CallVoidMethod(instance, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified instance method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallVoidMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            CallVoidMethod(instance, m, args);
        }

        /// <summary>
        /// Invokes the specified instance method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallVoidMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
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

                CallVoidMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        public readonly static MethodInfo CallNonvirtualVoidMethodInfo = typeof(JavaEnvironment).GetMethod(nameof(JavaEnvironment.CallNonvirtualVoidMethod), BindingFlags.Instance | BindingFlags.Public, null, ArgTypes.CallNonvirtualMethodArgTypes, null);

        /// <summary>
        /// Invokes the specified non-virtual method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallNonvirtualVoidMethod(JObject instance, JClass clazz, JMethodID method, ReadOnlySpan<JValue> args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            env.CallNonvirtualVoidMethodA(instance, clazz, method, args);
            ThrowIfException();
        }

        /// <summary>
        /// Invokes the specified non-virtual method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallNonvirtualVoidMethod(JObject instance, JClass clazz, JMethodID method, params JValue[] args)
        {
            if (instance.IsNull)
                throw new ArgumentNullException(nameof(instance));
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));
            if (args is null)
                throw new ArgumentNullException(nameof(args));

            CallNonvirtualVoidMethod(instance, clazz, method, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Invokes the specified non-virtual method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallNonvirtualVoidMethod(JObject instance, JClass clazz, string name, JavaMethodDescriptor signature, ReadOnlySpan<JValue> args)
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

            CallNonvirtualVoidMethod(instance, clazz, m, args);
        }

        /// <summary>
        /// Invokes the specified non-virtual method.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="signature"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void CallNonvirtualVoidMethod(JObject instance, JavaClassDescriptor clazz, string name, JavaMethodDescriptor signature, params JValue[] args)
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

                CallNonvirtualVoidMethod(instance, cls, name, signature, (ReadOnlySpan<JValue>)args);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

    }

}
