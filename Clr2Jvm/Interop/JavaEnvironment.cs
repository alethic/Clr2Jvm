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
        /// Returns <c>true</c> if the two objects are the same object.
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns></returns>
        internal bool IsSameObject(JObject object1, JObject object2)
        {
            return env.IsSameObject(object1, object2);
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
        /// Creates a new instance of the specified class by invoking the given constructor method.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="constructor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject NewObject(JClass clazz, JMethodID constructor, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (constructor.IsNull)
                throw new ArgumentNullException(nameof(constructor));

            var result = env.NewObjectA(clazz, constructor, args);
            ThrowIfException();
            return result;
        }

        /// <summary>
        /// Creates a new instance of the specified class by invoking the given constructor method.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="constructor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject NewObject(JClass clazz, JMethodID constructor, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (constructor.IsNull)
                throw new ArgumentNullException(nameof(constructor));

            return NewObject(clazz, constructor, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Creates a new instance of the specified class by invoking the given constructor method.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="constructor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject NewObject(JClass clazz, JavaMethodDescriptor constructor, ReadOnlySpan<JValue> args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (constructor.Return.Type != JavaDescriptorType.Void)
                throw new ArgumentException("Cannot create new object with init method that does not return void.", nameof(constructor));

            var m = GetMethodID(clazz, "<init>", constructor);
            if (m.IsNull)
                throw new JavaException($"Could not find constructor method matching '{constructor}'.");

            return NewObject(clazz, m, args);
        }

        /// <summary>
        /// Creates a new instance of the specified class by invoking the given constructor method.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="constructor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public JObject NewObject(JClass clazz, JavaMethodDescriptor constructor, params JValue[] args)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (constructor.Return.Type != JavaDescriptorType.Void)
                throw new ArgumentException("Cannot create new object with init method that does not return void.", nameof(constructor));

            return NewObject(clazz, constructor, (ReadOnlySpan<JValue>)args);
        }

        /// <summary>
        /// Creates a new instance of the specified class by invoking the default constructor.
        /// </summary>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public JObject NewObject(JClass clazz)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));

            return NewObject(clazz, "()V", ReadOnlySpan<JValue>.Empty);
        }

        /// <summary>
        /// Creates a new instance of the specified class by invoking the default constructor.
        /// </summary>
        /// <param name="clazz"></param>
        /// <returns></returns>
        public JObject NewObject(JavaClassDescriptor clazz)
        {
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return NewObject(cls);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
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
        /// Gets the length of the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int GetArrayLength(JArray array)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));

            var ret = env.GetArrayLength(array);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Creates a new object array of the specified size, initialized with the specified element.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="length"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JObjectArray NewObjectArray(JClass clazz, int length, JObject initialElement)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var arr = env.NewObjectArray(length, clazz, initialElement);
            ThrowIfException();
            return arr;
        }

        /// <summary>
        /// Creates a new object array of the specified size, initalized to empty.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public JObjectArray NewObjectArray(JClass clazz, int length)
        {
            if (clazz.IsNull)
                throw new ArgumentNullException(nameof(clazz));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            return NewObjectArray(clazz, length, JObject.Null);
        }

        /// <summary>
        /// Creates a new object array of the specified size, initialized to the specified value.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="length"></param>
        /// <param name="initialElement"></param>
        /// <returns></returns>
        public JObjectArray NewObjectArray(JavaClassDescriptor clazz, int length, JObject initialElement)
        {
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return NewObjectArray(cls, length, initialElement);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Creates a new object array of the specified size, initialized to empty.
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public JObjectArray NewObjectArray(JavaClassDescriptor clazz, int size)
        {
            var cls = JClass.Null;

            try
            {
                cls = FindClass(clazz);
                if (cls.IsNull)
                    throw new JavaException($"Could not find '{clazz}'.");

                return NewObjectArray(cls, size);
            }
            finally
            {
                SafeDeleteLocalRef(cls);
            }
        }

        /// <summary>
        /// Gets an element of an Object array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public JObject GetObjectArrayElement(JObjectArray array, int index)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            var ret = env.GetObjectArrayElement(array, index);
            ThrowIfException();
            return ret;
        }

        /// <summary>
        /// Sets an element of an Object array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetObjectArrayElement(JObjectArray array, int index, JObject value)
        {
            if (array.IsNull)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            env.SetObjectArrayElement(array, index, value);
            ThrowIfException();
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
                SafeDeleteLocalRef(cls);
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

            var ret = GetFieldID((JClass)clazz.Ref.Handle, name, signature);
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
        /// Converts the given reflected method into a <see cref="JMethodID"/>.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public JObject ToReflectedMethod(JClass clazz, JMethodID method, bool isStatic)
        {
            if (method.IsNull)
                throw new ArgumentNullException(nameof(method));

            return env.ToReflectedMethod(clazz, method, isStatic);
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

            var m = GetStaticMethodID((JClass)clazz.Ref.Handle, name, signature);
            if (m.IsNull)
                return null;

            return new JavaReflectedMethodInfo(runtime, clazz, m);
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

            var m = env.GetMethodID(clazz, _name.Span, _signature.Span);
            ThrowIfException();
            return m;
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

            var m = GetMethodID((JClass)clazz.Ref.Handle, name, signature);
            if (m.IsNull)
                return null;

            return new JavaReflectedMethodInfo(runtime, clazz, m);
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

            var cls = JClass.Null;

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

            var cls = JClass.Null;

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

            var cls = JClass.Null;

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
