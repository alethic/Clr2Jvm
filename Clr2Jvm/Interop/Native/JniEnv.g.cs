#nullable enable
#pragma warning disable IDE0047
#pragma warning disable IDE1006

using System;
using System.Runtime.InteropServices;

namespace Clr2Jvm.Interop.Native
{

    /// <summary>
    /// Represents the JniNativeInterface structure from 'jni.h'.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    readonly partial struct JniNativeInterface
    {

        readonly IntPtr reserved0;                            // void*
        readonly IntPtr reserved1;                            // void*
        readonly IntPtr reserved2;                            // void*
        readonly IntPtr reserved3;                            // void*
        public readonly IntPtr GetVersion;                    // jint        (*GetVersion)(JNIEnv*);
        public readonly IntPtr DefineClass;                   // jclass      (*DefineClass)(JNIEnv*, const char, jobject, const jbyte*, jsize);
        public readonly IntPtr FindClass;                     // jclass      (*FindClass)(JNIEnv*, const char*);
        public readonly IntPtr FromReflectedMethod;           // jmethodID   (*FromReflectedMethod)(JNIEnv*, jobject);
        public readonly IntPtr FromReflectedField;            // jfieldID    (*FromReflectedField)(JNIEnv*, jobject);
        public readonly IntPtr ToReflectedMethod;             // jobject     (*ToReflectedMethod)(JNIEnv*, jclass, jmethodID, jboolean);
        public readonly IntPtr GetSuperclass;                 // jclass      (*GetSuperclass)(JNIEnv*, jclass);
        public readonly IntPtr IsAssignableFrom;              // jboolean    (*IsAssignableFrom)(JNIEnv*, jclass, jclass);
        public readonly IntPtr ToReflectedField;              // jobject     (*ToReflectedField)(JNIEnv*, jclass, jfieldID, jboolean);
        public readonly IntPtr Throw;                         // jint        (*Throw)(JNIEnv*, jthrowable);
        public readonly IntPtr ThrowNew;                      // jint        (*ThrowNew)(JNIEnv*, jclass, const char*);
        public readonly IntPtr ExceptionOccurred;             // jthrowable  (*ExceptionOccurred)(JNIEnv*);
        public readonly IntPtr ExceptionDescribe;             // void        (*ExceptionDescribe)(JNIEnv*);
        public readonly IntPtr ExceptionClear;                // void        (*ExceptionClear)(JNIEnv*);
        public readonly IntPtr FatalError;                    // void        (*FatalError)(JNIEnv*, const char*);
        public readonly IntPtr PushLocalFrame;                // jint        (*PushLocalFrame)(JNIEnv*, jint);
        public readonly IntPtr PopLocalFrame;                 // jobject     (*PopLocalFrame)(JNIEnv*, jobject);
        public readonly IntPtr NewGlobalRef;                  // jobject     (*NewGlobalRef)(JNIEnv*, jobject);
        public readonly IntPtr DeleteGlobalRef;               // void        (*DeleteGlobalRef)(JNIEnv*, jobject);
        public readonly IntPtr DeleteLocalRef;                // void        (*DeleteLocalRef)(JNIEnv*, jobject);
        public readonly IntPtr IsSameObject;                  // jboolean    (*IsSameObject)(JNIEnv*, jobject, jobject);
        public readonly IntPtr NewLocalRef;                   // jobject     (*NewLocalRef)(JNIEnv*, jobject);
        public readonly IntPtr EnsureLocalCapacity;           // jint        (*EnsureLocalCapacity)(JNIEnv*, jint);
        public readonly IntPtr AllocObject;                   // jobject     (*AllocObject)(JNIEnv*, jclass);
        public readonly IntPtr NewObject;                     // jobject     (*NewObject)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr NewObjectV;                    // jobject     (*NewObjectV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr NewObjectA;                    // jobject     (*NewObjectA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr GetObjectClass;                // jclass      (*GetObjectClass)(JNIEnv*, jobject);
        public readonly IntPtr IsInstanceOf;                  // jboolean    (*IsInstanceOf)(JNIEnv*, jobject, jclass);
        public readonly IntPtr GetMethodID;                   // jmethodID   (*GetMethodID)(JNIEnv*, jclass, const char*, const char*);
        public readonly IntPtr CallObjectMethod;              // jobject     (*CallObjectMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallObjectMethodV;             // jobject     (*CallObjectMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallObjectMethodA;             // jobject     (*CallObjectMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallBooleanMethod;             // jboolean    (*CallBooleanMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallBooleanMethodV;            // jboolean    (*CallBooleanMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallBooleanMethodA;            // jboolean    (*CallBooleanMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallByteMethod;                // jbyte       (*CallByteMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallByteMethodV;               // jbyte       (*CallByteMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallByteMethodA;               // jbyte       (*CallByteMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallCharMethod;                // jchar       (*CallCharMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallCharMethodV;               // jchar       (*CallCharMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallCharMethodA;               // jchar       (*CallCharMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallShortMethod;               // jshort      (*CallShortMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallShortMethodV;              // jshort      (*CallShortMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallShortMethodA;              // jshort      (*CallShortMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallIntMethod;                 // jint        (*CallIntMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallIntMethodV;                // jint        (*CallIntMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallIntMethodA;                // jint        (*CallIntMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallLongMethod;                // jlong       (*CallLongMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallLongMethodV;               // jlong       (*CallLongMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallLongMethodA;               // jlong       (*CallLongMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallFloatMethod;               // jfloat      (*CallFloatMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallFloatMethodV;              // jfloat      (*CallFloatMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallFloatMethodA;              // jfloat      (*CallFloatMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallDoubleMethod;              // jdouble     (*CallDoubleMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallDoubleMethodV;             // jdouble     (*CallDoubleMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallDoubleMethodA;             // jdouble     (*CallDoubleMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallVoidMethod;                // void        (*CallVoidMethod)(JNIEnv*, jobject, jmethodID, ...);
        public readonly IntPtr CallVoidMethodV;               // void        (*CallVoidMethodV)(JNIEnv*, jobject, jmethodID, va_list);
        public readonly IntPtr CallVoidMethodA;               // void        (*CallVoidMethodA)(JNIEnv*, jobject, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualObjectMethod;    // jobject     (*CallNonvirtualObjectMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualObjectMethodV;   // jobject     (*CallNonvirtualObjectMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualObjectMethodA;   // jobject     (*CallNonvirtualObjectMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualBooleanMethod;   // jboolean    (*CallNonvirtualBooleanMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualBooleanMethodV;  // jboolean    (*CallNonvirtualBooleanMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualBooleanMethodA;  // jboolean    (*CallNonvirtualBooleanMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualByteMethod;      // jbyte       (*CallNonvirtualByteMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualByteMethodV;     // jbyte       (*CallNonvirtualByteMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualByteMethodA;     // jbyte       (*CallNonvirtualByteMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualCharMethod;      // jchar       (*CallNonvirtualCharMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualCharMethodV;     // jchar       (*CallNonvirtualCharMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualCharMethodA;     // jchar       (*CallNonvirtualCharMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualShortMethod;     // jshort      (*CallNonvirtualShortMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualShortMethodV;    // jshort      (*CallNonvirtualShortMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualShortMethodA;    // jshort      (*CallNonvirtualShortMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualIntMethod;       // jint        (*CallNonvirtualIntMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualIntMethodV;      // jint        (*CallNonvirtualIntMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualIntMethodA;      // jint        (*CallNonvirtualIntMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualLongMethod;      // jlong       (*CallNonvirtualLongMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualLongMethodV;     // jlong       (*CallNonvirtualLongMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualLongMethodA;     // jlong       (*CallNonvirtualLongMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualFloatMethod;     // jfloat      (*CallNonvirtualFloatMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualFloatMethodV;    // jfloat      (*CallNonvirtualFloatMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualFloatMethodA;    // jfloat      (*CallNonvirtualFloatMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualDoubleMethod;    // jdouble     (*CallNonvirtualDoubleMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualDoubleMethodV;   // jdouble     (*CallNonvirtualDoubleMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualDoubleMethodA;   // jdouble     (*CallNonvirtualDoubleMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallNonvirtualVoidMethod;      // void        (*CallNonvirtualVoidMethod)(JNIEnv*, jobject, jclass, jmethodID, ...);
        public readonly IntPtr CallNonvirtualVoidMethodV;     // void        (*CallNonvirtualVoidMethodV)(JNIEnv*, jobject, jclass, jmethodID, va_list);
        public readonly IntPtr CallNonvirtualVoidMethodA;     // void        (*CallNonvirtualVoidMethodA)(JNIEnv*, jobject, jclass, jmethodID, jvalue*);
        public readonly IntPtr GetFieldID;                    // jfieldID    (*GetFieldID)(JNIEnv*, jclass, const char*, const char*);
        public readonly IntPtr GetObjectField;                // jobject     (*GetObjectField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetBooleanField;               // jboolean    (*GetBooleanField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetByteField;                  // jbyte       (*GetByteField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetCharField;                  // jchar       (*GetCharField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetShortField;                 // jshort      (*GetShortField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetIntField;                   // jint        (*GetIntField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetLongField;                  // jlong       (*GetLongField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetFloatField;                 // jfloat      (*GetFloatField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr GetDoubleField;                // jdouble     (*GetDoubleField)(JNIEnv*, jobject, jfieldID);
        public readonly IntPtr SetObjectField;                // void        (*SetObjectField)(JNIEnv*, jobject, jfieldID, jobject);
        public readonly IntPtr SetBooleanField;               // void        (*SetBooleanField)(JNIEnv*, jobject, jfieldID, jboolean);
        public readonly IntPtr SetByteField;                  // void        (*SetByteField)(JNIEnv*, jobject, jfieldID, jbyte);
        public readonly IntPtr SetCharField;                  // void        (*SetCharField)(JNIEnv*, jobject, jfieldID, jchar);
        public readonly IntPtr SetShortField;                 // void        (*SetShortField)(JNIEnv*, jobject, jfieldID, jshort);
        public readonly IntPtr SetIntField;                   // void        (*SetIntField)(JNIEnv*, jobject, jfieldID, jint);
        public readonly IntPtr SetLongField;                  // void        (*SetLongField)(JNIEnv*, jobject, jfieldID, jlong);
        public readonly IntPtr SetFloatField;                 // void        (*SetFloatField)(JNIEnv*, jobject, jfieldID, jfloat);
        public readonly IntPtr SetDoubleField;                // void        (*SetDoubleField)(JNIEnv*, jobject, jfieldID, jdouble);
        public readonly IntPtr GetStaticMethodID;             // jmethodID   (*GetStaticMethodID)(JNIEnv*, jclass, const char*, const char*);
        public readonly IntPtr CallStaticObjectMethod;        // jobject     (*CallStaticObjectMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticObjectMethodV;       // jobject     (*CallStaticObjectMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticObjectMethodA;       // jobject     (*CallStaticObjectMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticBooleanMethod;       // jboolean    (*CallStaticBooleanMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticBooleanMethodV;      // jboolean    (*CallStaticBooleanMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticBooleanMethodA;      // jboolean    (*CallStaticBooleanMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticByteMethod;          // jbyte       (*CallStaticByteMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticByteMethodV;         // jbyte       (*CallStaticByteMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticByteMethodA;         // jbyte       (*CallStaticByteMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticCharMethod;          // jchar       (*CallStaticCharMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticCharMethodV;         // jchar       (*CallStaticCharMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticCharMethodA;         // jchar       (*CallStaticCharMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticShortMethod;         // jshort      (*CallStaticShortMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticShortMethodV;        // jshort      (*CallStaticShortMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticShortMethodA;        // jshort      (*CallStaticShortMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticIntMethod;           // jint        (*CallStaticIntMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticIntMethodV;          // jint        (*CallStaticIntMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticIntMethodA;          // jint        (*CallStaticIntMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticLongMethod;          // jlong       (*CallStaticLongMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticLongMethodV;         // jlong       (*CallStaticLongMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticLongMethodA;         // jlong       (*CallStaticLongMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticFloatMethod;         // jfloat      (*CallStaticFloatMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticFloatMethodV;        // jfloat      (*CallStaticFloatMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticFloatMethodA;        // jfloat      (*CallStaticFloatMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticDoubleMethod;        // jdouble     (*CallStaticDoubleMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticDoubleMethodV;       // jdouble     (*CallStaticDoubleMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticDoubleMethodA;       // jdouble     (*CallStaticDoubleMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr CallStaticVoidMethod;          // void        (*CallStaticVoidMethod)(JNIEnv*, jclass, jmethodID, ...);
        public readonly IntPtr CallStaticVoidMethodV;         // void        (*CallStaticVoidMethodV)(JNIEnv*, jclass, jmethodID, va_list);
        public readonly IntPtr CallStaticVoidMethodA;         // void        (*CallStaticVoidMethodA)(JNIEnv*, jclass, jmethodID, jvalue*);
        public readonly IntPtr GetStaticFieldID;              // jfieldID    (*GetStaticFieldID)(JNIEnv*, jclass, const char*, const char*);
        public readonly IntPtr GetStaticObjectField;          // jobject     (*GetStaticObjectField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticBooleanField;         // jboolean    (*GetStaticBooleanField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticByteField;            // jbyte       (*GetStaticByteField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticCharField;            // jchar       (*GetStaticCharField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticShortField;           // jshort      (*GetStaticShortField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticIntField;             // jint        (*GetStaticIntField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticLongField;            // jlong       (*GetStaticLongField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticFloatField;           // jfloat      (*GetStaticFloatField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr GetStaticDoubleField;          // jdouble     (*GetStaticDoubleField)(JNIEnv*, jclass, jfieldID);
        public readonly IntPtr SetStaticObjectField;          // void        (*SetStaticObjectField)(JNIEnv*, jclass, jfieldID, jobject);
        public readonly IntPtr SetStaticBooleanField;         // void        (*SetStaticBooleanField)(JNIEnv*, jclass, jfieldID, jboolean);
        public readonly IntPtr SetStaticByteField;            // void        (*SetStaticByteField)(JNIEnv*, jclass, jfieldID, jbyte);
        public readonly IntPtr SetStaticCharField;            // void        (*SetStaticCharField)(JNIEnv*, jclass, jfieldID, jchar);
        public readonly IntPtr SetStaticShortField;           // void        (*SetStaticShortField)(JNIEnv*, jclass, jfieldID, jshort);
        public readonly IntPtr SetStaticIntField;             // void        (*SetStaticIntField)(JNIEnv*, jclass, jfieldID, jint);
        public readonly IntPtr SetStaticLongField;            // void        (*SetStaticLongField)(JNIEnv*, jclass, jfieldID, jlong);
        public readonly IntPtr SetStaticFloatField;           // void        (*SetStaticFloatField)(JNIEnv*, jclass, jfieldID, jfloat);
        public readonly IntPtr SetStaticDoubleField;          // void        (*SetStaticDoubleField)(JNIEnv*, jclass, jfieldID, jdouble);
        public readonly IntPtr NewString;                     // jstring     (*NewString)(JNIEnv*, const jchar*, jsize);
        public readonly IntPtr GetStringLength;               // jsize       (*GetStringLength)(JNIEnv*, jstring);
        public readonly IntPtr GetStringChars;                // const jchar* (*GetStringChars)(JNIEnv*, jstring, jboolean*);
        public readonly IntPtr ReleaseStringChars;            // void        (*ReleaseStringChars)(JNIEnv*, jstring, const jchar*);
        public readonly IntPtr NewStringUTF;                  // jstring     (*NewStringUTF)(JNIEnv*, const char*);
        public readonly IntPtr GetStringUTFLength;            // jsize       (*GetStringUTFLength)(JNIEnv*, jstring);
        public readonly IntPtr GetStringUTFChars;             // const char* (*GetStringUTFChars)(JNIEnv*, jstring, jboolean*);
        public readonly IntPtr ReleaseStringUTFChars;         // void        (*ReleaseStringUTFChars)(JNIEnv*, jstring, const char*);
        public readonly IntPtr GetArrayLength;                // jsize       (*GetArrayLength)(JNIEnv*, jarray);
        public readonly IntPtr NewObjectArray;                // jobjectArray (*NewObjectArray)(JNIEnv*, jsize, jclass, jobject);
        public readonly IntPtr GetObjectArrayElement;         // jobject     (*GetObjectArrayElement)(JNIEnv*, jobjectArray, jsize);
        public readonly IntPtr SetObjectArrayElement;         // void        (*SetObjectArrayElement)(JNIEnv*, jobjectArray, jsize, jobject);
        public readonly IntPtr NewBooleanArray;               // jbooleanArray (*NewBooleanArray)(JNIEnv*, jsize);
        public readonly IntPtr NewByteArray;                  // jbyteArray  (*NewByteArray)(JNIEnv*, jsize);
        public readonly IntPtr NewCharArray;                  // jcharArray  (*NewCharArray)(JNIEnv*, jsize);
        public readonly IntPtr NewShortArray;                 // jshortArray (*NewShortArray)(JNIEnv*, jsize);
        public readonly IntPtr NewIntArray;                   // jintArray   (*NewIntArray)(JNIEnv*, jsize);
        public readonly IntPtr NewLongArray;                  // jlongArray  (*NewLongArray)(JNIEnv*, jsize);
        public readonly IntPtr NewFloatArray;                 // jfloatArray (*NewFloatArray)(JNIEnv*, jsize);
        public readonly IntPtr NewDoubleArray;                // jdoubleArray (*NewDoubleArray)(JNIEnv*, jsize);
        public readonly IntPtr GetBooleanArrayElements;       // jboolean*   (*GetBooleanArrayElements)(JNIEnv*, jbooleanArray, jboolean*);
        public readonly IntPtr GetByteArrayElements;          // jbyte*      (*GetByteArrayElements)(JNIEnv*, jbyteArray, jboolean*);
        public readonly IntPtr GetCharArrayElements;          // jchar*      (*GetCharArrayElements)(JNIEnv*, jcharArray, jboolean*);
        public readonly IntPtr GetShortArrayElements;         // jshort*     (*GetShortArrayElements)(JNIEnv*, jshortArray, jboolean*);
        public readonly IntPtr GetIntArrayElements;           // jint*       (*GetIntArrayElements)(JNIEnv*, jintArray, jboolean*);
        public readonly IntPtr GetLongArrayElements;          // jlong*      (*GetLongArrayElements)(JNIEnv*, jlongArray, jboolean*);
        public readonly IntPtr GetFloatArrayElements;         // jfloat*     (*GetFloatArrayElements)(JNIEnv*, jfloatArray, jboolean*);
        public readonly IntPtr GetDoubleArrayElements;        // jdouble*    (*GetDoubleArrayElements)(JNIEnv*, jdoubleArray, jboolean*);
        public readonly IntPtr ReleaseBooleanArrayElements;   // void        (*ReleaseBooleanArrayElements)(JNIEnv*, jbooleanArray, jboolean*, jint);
        public readonly IntPtr ReleaseByteArrayElements;      // void        (*ReleaseByteArrayElements)(JNIEnv*, jbyteArray, jbyte*, jint);
        public readonly IntPtr ReleaseCharArrayElements;      // void        (*ReleaseCharArrayElements)(JNIEnv*, jcharArray, jchar*, jint);
        public readonly IntPtr ReleaseShortArrayElements;     // void        (*ReleaseShortArrayElements)(JNIEnv*, jshortArray, jshort*, jint);
        public readonly IntPtr ReleaseIntArrayElements;       // void        (*ReleaseIntArrayElements)(JNIEnv*, jintArray, jint*, jint);
        public readonly IntPtr ReleaseLongArrayElements;      // void        (*ReleaseLongArrayElements)(JNIEnv*, jlongArray, jlong*, jint);
        public readonly IntPtr ReleaseFloatArrayElements;     // void        (*ReleaseFloatArrayElements)(JNIEnv*, jfloatArray, jfloat*, jint);
        public readonly IntPtr ReleaseDoubleArrayElements;    // void        (*ReleaseDoubleArrayElements)(JNIEnv*, jdoubleArray, jdouble*, jint);
        public readonly IntPtr GetBooleanArrayRegion;         // void        (*GetBooleanArrayRegion)(JNIEnv*, jbooleanArray, jsize, jsize, jboolean*);
        public readonly IntPtr GetByteArrayRegion;            // void        (*GetByteArrayRegion)(JNIEnv*, jbyteArray, jsize, jsize, jbyte*);
        public readonly IntPtr GetCharArrayRegion;            // void        (*GetCharArrayRegion)(JNIEnv*, jcharArray, jsize, jsize, jchar*);
        public readonly IntPtr GetShortArrayRegion;           // void        (*GetShortArrayRegion)(JNIEnv*, jshortArray, jsize, jsize, jshort*);
        public readonly IntPtr GetIntArrayRegion;             // void        (*GetIntArrayRegion)(JNIEnv*, jintArray, jsize, jsize, jint*);
        public readonly IntPtr GetLongArrayRegion;            // void        (*GetLongArrayRegion)(JNIEnv*, jlongArray, jsize, jsize, jlong*);
        public readonly IntPtr GetFloatArrayRegion;           // void        (*GetFloatArrayRegion)(JNIEnv*, jfloatArray, jsize, jsize, jfloat*);
        public readonly IntPtr GetDoubleArrayRegion;          // void        (*GetDoubleArrayRegion)(JNIEnv*, jdoubleArray, jsize, jsize, jdouble*);
        public readonly IntPtr SetBooleanArrayRegion;         // void        (*SetBooleanArrayRegion)(JNIEnv*, jbooleanArray, jsize, jsize, const jboolean*);
        public readonly IntPtr SetByteArrayRegion;            // void        (*SetByteArrayRegion)(JNIEnv*, jbyteArray, jsize, jsize, const jbyte*);
        public readonly IntPtr SetCharArrayRegion;            // void        (*SetCharArrayRegion)(JNIEnv*, jcharArray, jsize, jsize, const jchar*);
        public readonly IntPtr SetShortArrayRegion;           // void        (*SetShortArrayRegion)(JNIEnv*, jshortArray, jsize, jsize, const jshort*);
        public readonly IntPtr SetIntArrayRegion;             // void        (*SetIntArrayRegion)(JNIEnv*, jintArray, jsize, jsize, const jint*);
        public readonly IntPtr SetLongArrayRegion;            // void        (*SetLongArrayRegion)(JNIEnv*, jlongArray, jsize, jsize, const jlong*);
        public readonly IntPtr SetFloatArrayRegion;           // void        (*SetFloatArrayRegion)(JNIEnv*, jfloatArray, jsize, jsize, const jfloat*);
        public readonly IntPtr SetDoubleArrayRegion;          // void        (*SetDoubleArrayRegion)(JNIEnv*, jdoubleArray, jsize, jsize, const jdouble*);
        public readonly IntPtr RegisterNatives;               // jint        (*RegisterNatives)(JNIEnv*, jclass, const JNINativeMethod*, jint);
        public readonly IntPtr UnregisterNatives;             // jint        (*UnregisterNatives)(JNIEnv*, jclass);
        public readonly IntPtr MonitorEnter;                  // jint        (*MonitorEnter)(JNIEnv*, jobject);
        public readonly IntPtr MonitorExit;                   // jint        (*MonitorExit)(JNIEnv*, jobject);
        public readonly IntPtr GetJavaVM;                     // jint        (*GetJavaVM)(JNIEnv*, JavaVM**);
        public readonly IntPtr GetStringRegion;               // void        (*GetStringRegion)(JNIEnv*, jstring, jsize, jsize, jchar*);
        public readonly IntPtr GetStringUTFRegion;            // void        (*GetStringUTFRegion)(JNIEnv*, jstring, jsize, jsize, char*);
        public readonly IntPtr GetPrimitiveArrayCritical;     // void*       (*GetPrimitiveArrayCritical)(JNIEnv*, jarray, jboolean*);
        public readonly IntPtr ReleasePrimitiveArrayCritical; // void        (*ReleasePrimitiveArrayCritical)(JNIEnv*, jarray, void*, jint);
        public readonly IntPtr GetStringCritical;             // const jchar* (*GetStringCritical)(JNIEnv*, jstring, jboolean*);
        public readonly IntPtr ReleaseStringCritical;         // void        (*ReleaseStringCritical)(JNIEnv*, jstring, const jchar*);
        public readonly IntPtr NewWeakGlobalRef;              // jweak       (*NewWeakGlobalRef)(JNIEnv*, jobject);
        public readonly IntPtr DeleteWeakGlobalRef;           // void        (*DeleteWeakGlobalRef)(JNIEnv*, jweak);
        public readonly IntPtr ExceptionCheck;                // jboolean    (*ExceptionCheck)(JNIEnv*);
        public readonly IntPtr NewDirectByteBuffer;           // jobject     (*NewDirectByteBuffer)(JNIEnv*, void*, jlong);
        public readonly IntPtr GetDirectBufferAddress;        // void*       (*GetDirectBufferAddress)(JNIEnv*, jobject);
        public readonly IntPtr GetDirectBufferCapacity;       // jlong       (*GetDirectBufferCapacity)(JNIEnv*, jobject);
        public readonly IntPtr GetObjectRefType;              // jobjectRefType (*GetObjectRefType)(JNIEnv*, jobject);

    }

    /// <summary>
    /// Provides managed methods around a JniNativeInterface.
    /// </summary>
    unsafe partial class JniEnv
    {

        delegate int GetVersionDelegate(JniNativeInterface** env);
        GetVersionDelegate? __GetVersion;
        GetVersionDelegate _GetVersion => __GetVersion ??= GetDelegateForFunctionPointer<GetVersionDelegate>((*env)->GetVersion);

        public JInt GetVersion()
        {
            JInt @return;
            @return = (JInt)_GetVersion(env);
            return @return;
        }

        delegate IntPtr DefineClassDelegate(JniNativeInterface** env, byte* name, IntPtr loader, sbyte* buffer, int bufferLength);
        DefineClassDelegate? __DefineClass;
        DefineClassDelegate _DefineClass => __DefineClass ??= GetDelegateForFunctionPointer<DefineClassDelegate>((*env)->DefineClass);

        public JClass DefineClass(ReadOnlySpan<byte> name, JObject loader, ReadOnlySpan<JByte> buffer, JSize bufferLength)
        {
            JClass @return;
            fixed (byte* _name_ptr = name)
            {
                fixed (JByte* _buffer_ptr = buffer)
                {
                    @return = _DefineClass(env, (byte*)_name_ptr, loader, (sbyte*)_buffer_ptr, (int)bufferLength);
                }
            }
            return @return;
        }

        delegate IntPtr FindClassDelegate(JniNativeInterface** env, byte* classname);
        FindClassDelegate? __FindClass;
        FindClassDelegate _FindClass => __FindClass ??= GetDelegateForFunctionPointer<FindClassDelegate>((*env)->FindClass);

        public JClass FindClass(ReadOnlySpan<byte> classname)
        {
            JClass @return;
            fixed (byte* _classname_ptr = classname)
            {
                @return = _FindClass(env, (byte*)_classname_ptr);
            }
            return @return;
        }

        delegate IntPtr FromReflectedMethodDelegate(JniNativeInterface** env, IntPtr method);
        FromReflectedMethodDelegate? __FromReflectedMethod;
        FromReflectedMethodDelegate _FromReflectedMethod => __FromReflectedMethod ??= GetDelegateForFunctionPointer<FromReflectedMethodDelegate>((*env)->FromReflectedMethod);

        public JMethodID FromReflectedMethod(JObject method)
        {
            JMethodID @return;
            @return = _FromReflectedMethod(env, method);
            return @return;
        }

        delegate IntPtr FromReflectedFieldDelegate(JniNativeInterface** env, IntPtr field);
        FromReflectedFieldDelegate? __FromReflectedField;
        FromReflectedFieldDelegate _FromReflectedField => __FromReflectedField ??= GetDelegateForFunctionPointer<FromReflectedFieldDelegate>((*env)->FromReflectedField);

        public JFieldID FromReflectedField(JObject field)
        {
            JFieldID @return;
            @return = _FromReflectedField(env, field);
            return @return;
        }

        delegate IntPtr ToReflectedMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method, byte isStatic);
        ToReflectedMethodDelegate? __ToReflectedMethod;
        ToReflectedMethodDelegate _ToReflectedMethod => __ToReflectedMethod ??= GetDelegateForFunctionPointer<ToReflectedMethodDelegate>((*env)->ToReflectedMethod);

        public JObject ToReflectedMethod(JClass type, JMethodID method, JBoolean isStatic)
        {
            JObject @return;
            @return = _ToReflectedMethod(env, type, method, (byte)isStatic);
            return @return;
        }

        delegate IntPtr GetSuperclassDelegate(JniNativeInterface** env, IntPtr type);
        GetSuperclassDelegate? __GetSuperclass;
        GetSuperclassDelegate _GetSuperclass => __GetSuperclass ??= GetDelegateForFunctionPointer<GetSuperclassDelegate>((*env)->GetSuperclass);

        public JClass GetSuperclass(JClass type)
        {
            JClass @return;
            @return = _GetSuperclass(env, type);
            return @return;
        }

        delegate byte IsAssignableFromDelegate(JniNativeInterface** env, IntPtr class1, IntPtr class2);
        IsAssignableFromDelegate? __IsAssignableFrom;
        IsAssignableFromDelegate _IsAssignableFrom => __IsAssignableFrom ??= GetDelegateForFunctionPointer<IsAssignableFromDelegate>((*env)->IsAssignableFrom);

        public JBoolean IsAssignableFrom(JClass class1, JClass class2)
        {
            JBoolean @return;
            @return = (JBoolean)_IsAssignableFrom(env, class1, class2);
            return @return;
        }

        delegate IntPtr ToReflectedFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, byte isStatic);
        ToReflectedFieldDelegate? __ToReflectedField;
        ToReflectedFieldDelegate _ToReflectedField => __ToReflectedField ??= GetDelegateForFunctionPointer<ToReflectedFieldDelegate>((*env)->ToReflectedField);

        public JObject ToReflectedField(JClass type, JFieldID field, JBoolean isStatic)
        {
            JObject @return;
            @return = _ToReflectedField(env, type, field, (byte)isStatic);
            return @return;
        }

        delegate int ThrowDelegate(JniNativeInterface** env, IntPtr toThrow);
        ThrowDelegate? __Throw;
        ThrowDelegate _Throw => __Throw ??= GetDelegateForFunctionPointer<ThrowDelegate>((*env)->Throw);

        public JInt Throw(JThrowable toThrow)
        {
            JInt @return;
            @return = (JInt)_Throw(env, toThrow);
            return @return;
        }

        delegate int ThrowNewDelegate(JniNativeInterface** env, IntPtr type, byte* message);
        ThrowNewDelegate? __ThrowNew;
        ThrowNewDelegate _ThrowNew => __ThrowNew ??= GetDelegateForFunctionPointer<ThrowNewDelegate>((*env)->ThrowNew);

        public JInt ThrowNew(JClass type, ReadOnlySpan<byte> message)
        {
            JInt @return;
            fixed (byte* _message_ptr = message)
            {
                @return = (JInt)_ThrowNew(env, type, (byte*)_message_ptr);
            }
            return @return;
        }

        delegate IntPtr ExceptionOccurredDelegate(JniNativeInterface** env);
        ExceptionOccurredDelegate? __ExceptionOccurred;
        ExceptionOccurredDelegate _ExceptionOccurred => __ExceptionOccurred ??= GetDelegateForFunctionPointer<ExceptionOccurredDelegate>((*env)->ExceptionOccurred);

        public JThrowable ExceptionOccurred()
        {
            JThrowable @return;
            @return = _ExceptionOccurred(env);
            return @return;
        }

        delegate void ExceptionDescribeDelegate(JniNativeInterface** env);
        ExceptionDescribeDelegate? __ExceptionDescribe;
        ExceptionDescribeDelegate _ExceptionDescribe => __ExceptionDescribe ??= GetDelegateForFunctionPointer<ExceptionDescribeDelegate>((*env)->ExceptionDescribe);

        public void ExceptionDescribe()
        {
            _ExceptionDescribe(env);
        }

        delegate void ExceptionClearDelegate(JniNativeInterface** env);
        ExceptionClearDelegate? __ExceptionClear;
        ExceptionClearDelegate _ExceptionClear => __ExceptionClear ??= GetDelegateForFunctionPointer<ExceptionClearDelegate>((*env)->ExceptionClear);

        public void ExceptionClear()
        {
            _ExceptionClear(env);
        }

        delegate void FatalErrorDelegate(JniNativeInterface** env, byte* message);
        FatalErrorDelegate? __FatalError;
        FatalErrorDelegate _FatalError => __FatalError ??= GetDelegateForFunctionPointer<FatalErrorDelegate>((*env)->FatalError);

        public void FatalError(ReadOnlySpan<byte> message)
        {
            fixed (byte* _message_ptr = message)
            {
                _FatalError(env, (byte*)_message_ptr);
            }
        }

        delegate int PushLocalFrameDelegate(JniNativeInterface** env, int capacity);
        PushLocalFrameDelegate? __PushLocalFrame;
        PushLocalFrameDelegate _PushLocalFrame => __PushLocalFrame ??= GetDelegateForFunctionPointer<PushLocalFrameDelegate>((*env)->PushLocalFrame);

        public JInt PushLocalFrame(JInt capacity)
        {
            JInt @return;
            @return = (JInt)_PushLocalFrame(env, (int)capacity);
            return @return;
        }

        delegate IntPtr PopLocalFrameDelegate(JniNativeInterface** env, IntPtr result);
        PopLocalFrameDelegate? __PopLocalFrame;
        PopLocalFrameDelegate _PopLocalFrame => __PopLocalFrame ??= GetDelegateForFunctionPointer<PopLocalFrameDelegate>((*env)->PopLocalFrame);

        public JObject PopLocalFrame(JObject result)
        {
            JObject @return;
            @return = _PopLocalFrame(env, result);
            return @return;
        }

        delegate IntPtr NewGlobalRefDelegate(JniNativeInterface** env, IntPtr instance);
        NewGlobalRefDelegate? __NewGlobalRef;
        NewGlobalRefDelegate _NewGlobalRef => __NewGlobalRef ??= GetDelegateForFunctionPointer<NewGlobalRefDelegate>((*env)->NewGlobalRef);

        public JObject NewGlobalRef(JObject instance)
        {
            JObject @return;
            @return = _NewGlobalRef(env, instance);
            return @return;
        }

        delegate void DeleteGlobalRefDelegate(JniNativeInterface** env, IntPtr instance);
        DeleteGlobalRefDelegate? __DeleteGlobalRef;
        DeleteGlobalRefDelegate _DeleteGlobalRef => __DeleteGlobalRef ??= GetDelegateForFunctionPointer<DeleteGlobalRefDelegate>((*env)->DeleteGlobalRef);

        public void DeleteGlobalRef(JObject instance)
        {
            _DeleteGlobalRef(env, instance);
        }

        delegate void DeleteLocalRefDelegate(JniNativeInterface** env, IntPtr instance);
        DeleteLocalRefDelegate? __DeleteLocalRef;
        DeleteLocalRefDelegate _DeleteLocalRef => __DeleteLocalRef ??= GetDelegateForFunctionPointer<DeleteLocalRefDelegate>((*env)->DeleteLocalRef);

        public void DeleteLocalRef(JObject instance)
        {
            _DeleteLocalRef(env, instance);
        }

        delegate byte IsSameObjectDelegate(JniNativeInterface** env, IntPtr object1, IntPtr object2);
        IsSameObjectDelegate? __IsSameObject;
        IsSameObjectDelegate _IsSameObject => __IsSameObject ??= GetDelegateForFunctionPointer<IsSameObjectDelegate>((*env)->IsSameObject);

        public JBoolean IsSameObject(JObject object1, JObject object2)
        {
            JBoolean @return;
            @return = (JBoolean)_IsSameObject(env, object1, object2);
            return @return;
        }

        delegate IntPtr NewLocalRefDelegate(JniNativeInterface** env, IntPtr instance);
        NewLocalRefDelegate? __NewLocalRef;
        NewLocalRefDelegate _NewLocalRef => __NewLocalRef ??= GetDelegateForFunctionPointer<NewLocalRefDelegate>((*env)->NewLocalRef);

        public JObject NewLocalRef(JObject instance)
        {
            JObject @return;
            @return = _NewLocalRef(env, instance);
            return @return;
        }

        delegate int EnsureLocalCapacityDelegate(JniNativeInterface** env, int capacity);
        EnsureLocalCapacityDelegate? __EnsureLocalCapacity;
        EnsureLocalCapacityDelegate _EnsureLocalCapacity => __EnsureLocalCapacity ??= GetDelegateForFunctionPointer<EnsureLocalCapacityDelegate>((*env)->EnsureLocalCapacity);

        public JInt EnsureLocalCapacity(JInt capacity)
        {
            JInt @return;
            @return = (JInt)_EnsureLocalCapacity(env, (int)capacity);
            return @return;
        }

        delegate IntPtr AllocObjectDelegate(JniNativeInterface** env, IntPtr type);
        AllocObjectDelegate? __AllocObject;
        AllocObjectDelegate _AllocObject => __AllocObject ??= GetDelegateForFunctionPointer<AllocObjectDelegate>((*env)->AllocObject);

        public JObject AllocObject(JClass type)
        {
            JObject @return;
            @return = _AllocObject(env, type);
            return @return;
        }

        delegate IntPtr NewObjectADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        NewObjectADelegate? __NewObjectA;
        NewObjectADelegate _NewObjectA => __NewObjectA ??= GetDelegateForFunctionPointer<NewObjectADelegate>((*env)->NewObjectA);

        public JObject NewObjectA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JObject @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = _NewObjectA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate IntPtr GetObjectClassDelegate(JniNativeInterface** env, IntPtr instance);
        GetObjectClassDelegate? __GetObjectClass;
        GetObjectClassDelegate _GetObjectClass => __GetObjectClass ??= GetDelegateForFunctionPointer<GetObjectClassDelegate>((*env)->GetObjectClass);

        public JClass GetObjectClass(JObject instance)
        {
            JClass @return;
            @return = _GetObjectClass(env, instance);
            return @return;
        }

        delegate byte IsInstanceOfDelegate(JniNativeInterface** env, IntPtr instance, IntPtr type);
        IsInstanceOfDelegate? __IsInstanceOf;
        IsInstanceOfDelegate _IsInstanceOf => __IsInstanceOf ??= GetDelegateForFunctionPointer<IsInstanceOfDelegate>((*env)->IsInstanceOf);

        public JBoolean IsInstanceOf(JObject instance, JClass type)
        {
            JBoolean @return;
            @return = (JBoolean)_IsInstanceOf(env, instance, type);
            return @return;
        }

        delegate IntPtr GetMethodIDDelegate(JniNativeInterface** env, IntPtr type, byte* name, byte* signature);
        GetMethodIDDelegate? __GetMethodID;
        GetMethodIDDelegate _GetMethodID => __GetMethodID ??= GetDelegateForFunctionPointer<GetMethodIDDelegate>((*env)->GetMethodID);

        public JMethodID GetMethodID(JClass type, ReadOnlySpan<byte> name, ReadOnlySpan<byte> signature)
        {
            JMethodID @return;
            fixed (byte* _name_ptr = name)
            {
                fixed (byte* _signature_ptr = signature)
                {
                    @return = _GetMethodID(env, type, (byte*)_name_ptr, (byte*)_signature_ptr);
                }
            }
            return @return;
        }

        delegate IntPtr CallObjectMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallObjectMethodADelegate? __CallObjectMethodA;
        CallObjectMethodADelegate _CallObjectMethodA => __CallObjectMethodA ??= GetDelegateForFunctionPointer<CallObjectMethodADelegate>((*env)->CallObjectMethodA);

        public JObject CallObjectMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JObject @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = _CallObjectMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate byte CallBooleanMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallBooleanMethodADelegate? __CallBooleanMethodA;
        CallBooleanMethodADelegate _CallBooleanMethodA => __CallBooleanMethodA ??= GetDelegateForFunctionPointer<CallBooleanMethodADelegate>((*env)->CallBooleanMethodA);

        public JBoolean CallBooleanMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JBoolean @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JBoolean)_CallBooleanMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate sbyte CallByteMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallByteMethodADelegate? __CallByteMethodA;
        CallByteMethodADelegate _CallByteMethodA => __CallByteMethodA ??= GetDelegateForFunctionPointer<CallByteMethodADelegate>((*env)->CallByteMethodA);

        public JByte CallByteMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JByte @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JByte)_CallByteMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate char CallCharMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallCharMethodADelegate? __CallCharMethodA;
        CallCharMethodADelegate _CallCharMethodA => __CallCharMethodA ??= GetDelegateForFunctionPointer<CallCharMethodADelegate>((*env)->CallCharMethodA);

        public JChar CallCharMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JChar @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JChar)_CallCharMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate short CallShortMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallShortMethodADelegate? __CallShortMethodA;
        CallShortMethodADelegate _CallShortMethodA => __CallShortMethodA ??= GetDelegateForFunctionPointer<CallShortMethodADelegate>((*env)->CallShortMethodA);

        public JShort CallShortMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JShort @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JShort)_CallShortMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate int CallIntMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallIntMethodADelegate? __CallIntMethodA;
        CallIntMethodADelegate _CallIntMethodA => __CallIntMethodA ??= GetDelegateForFunctionPointer<CallIntMethodADelegate>((*env)->CallIntMethodA);

        public JInt CallIntMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JInt @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JInt)_CallIntMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate long CallLongMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallLongMethodADelegate? __CallLongMethodA;
        CallLongMethodADelegate _CallLongMethodA => __CallLongMethodA ??= GetDelegateForFunctionPointer<CallLongMethodADelegate>((*env)->CallLongMethodA);

        public JLong CallLongMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JLong @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JLong)_CallLongMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate float CallFloatMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallFloatMethodADelegate? __CallFloatMethodA;
        CallFloatMethodADelegate _CallFloatMethodA => __CallFloatMethodA ??= GetDelegateForFunctionPointer<CallFloatMethodADelegate>((*env)->CallFloatMethodA);

        public JFloat CallFloatMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JFloat @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JFloat)_CallFloatMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate double CallDoubleMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallDoubleMethodADelegate? __CallDoubleMethodA;
        CallDoubleMethodADelegate _CallDoubleMethodA => __CallDoubleMethodA ??= GetDelegateForFunctionPointer<CallDoubleMethodADelegate>((*env)->CallDoubleMethodA);

        public JDouble CallDoubleMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JDouble @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JDouble)_CallDoubleMethodA(env, instance, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate void CallVoidMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr method, JValue* args);
        CallVoidMethodADelegate? __CallVoidMethodA;
        CallVoidMethodADelegate _CallVoidMethodA => __CallVoidMethodA ??= GetDelegateForFunctionPointer<CallVoidMethodADelegate>((*env)->CallVoidMethodA);

        public void CallVoidMethodA(JObject instance, JMethodID method, ReadOnlySpan<JValue> args)
        {
            fixed (JValue* _args_ptr = args)
            {
                _CallVoidMethodA(env, instance, method, (JValue*)_args_ptr);
            }
        }

        delegate IntPtr CallNonvirtualObjectMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualObjectMethodADelegate? __CallNonvirtualObjectMethodA;
        CallNonvirtualObjectMethodADelegate _CallNonvirtualObjectMethodA => __CallNonvirtualObjectMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualObjectMethodADelegate>((*env)->CallNonvirtualObjectMethodA);

        public JObject CallNonvirtualObjectMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JObject @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = _CallNonvirtualObjectMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate byte CallNonvirtualBooleanMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualBooleanMethodADelegate? __CallNonvirtualBooleanMethodA;
        CallNonvirtualBooleanMethodADelegate _CallNonvirtualBooleanMethodA => __CallNonvirtualBooleanMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualBooleanMethodADelegate>((*env)->CallNonvirtualBooleanMethodA);

        public JBoolean CallNonvirtualBooleanMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JBoolean @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JBoolean)_CallNonvirtualBooleanMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate sbyte CallNonvirtualByteMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualByteMethodADelegate? __CallNonvirtualByteMethodA;
        CallNonvirtualByteMethodADelegate _CallNonvirtualByteMethodA => __CallNonvirtualByteMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualByteMethodADelegate>((*env)->CallNonvirtualByteMethodA);

        public JByte CallNonvirtualByteMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JByte @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JByte)_CallNonvirtualByteMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate char CallNonvirtualCharMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualCharMethodADelegate? __CallNonvirtualCharMethodA;
        CallNonvirtualCharMethodADelegate _CallNonvirtualCharMethodA => __CallNonvirtualCharMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualCharMethodADelegate>((*env)->CallNonvirtualCharMethodA);

        public JChar CallNonvirtualCharMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JChar @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JChar)_CallNonvirtualCharMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate short CallNonvirtualShortMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualShortMethodADelegate? __CallNonvirtualShortMethodA;
        CallNonvirtualShortMethodADelegate _CallNonvirtualShortMethodA => __CallNonvirtualShortMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualShortMethodADelegate>((*env)->CallNonvirtualShortMethodA);

        public JShort CallNonvirtualShortMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JShort @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JShort)_CallNonvirtualShortMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate int CallNonvirtualIntMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualIntMethodADelegate? __CallNonvirtualIntMethodA;
        CallNonvirtualIntMethodADelegate _CallNonvirtualIntMethodA => __CallNonvirtualIntMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualIntMethodADelegate>((*env)->CallNonvirtualIntMethodA);

        public JInt CallNonvirtualIntMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JInt @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JInt)_CallNonvirtualIntMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate long CallNonvirtualLongMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualLongMethodADelegate? __CallNonvirtualLongMethodA;
        CallNonvirtualLongMethodADelegate _CallNonvirtualLongMethodA => __CallNonvirtualLongMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualLongMethodADelegate>((*env)->CallNonvirtualLongMethodA);

        public JLong CallNonvirtualLongMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JLong @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JLong)_CallNonvirtualLongMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate float CallNonvirtualFloatMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualFloatMethodADelegate? __CallNonvirtualFloatMethodA;
        CallNonvirtualFloatMethodADelegate _CallNonvirtualFloatMethodA => __CallNonvirtualFloatMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualFloatMethodADelegate>((*env)->CallNonvirtualFloatMethodA);

        public JFloat CallNonvirtualFloatMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JFloat @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JFloat)_CallNonvirtualFloatMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate double CallNonvirtualDoubleMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualDoubleMethodADelegate? __CallNonvirtualDoubleMethodA;
        CallNonvirtualDoubleMethodADelegate _CallNonvirtualDoubleMethodA => __CallNonvirtualDoubleMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualDoubleMethodADelegate>((*env)->CallNonvirtualDoubleMethodA);

        public JDouble CallNonvirtualDoubleMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JDouble @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JDouble)_CallNonvirtualDoubleMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate void CallNonvirtualVoidMethodADelegate(JniNativeInterface** env, IntPtr instance, IntPtr type, IntPtr method, JValue* args);
        CallNonvirtualVoidMethodADelegate? __CallNonvirtualVoidMethodA;
        CallNonvirtualVoidMethodADelegate _CallNonvirtualVoidMethodA => __CallNonvirtualVoidMethodA ??= GetDelegateForFunctionPointer<CallNonvirtualVoidMethodADelegate>((*env)->CallNonvirtualVoidMethodA);

        public void CallNonvirtualVoidMethodA(JObject instance, JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            fixed (JValue* _args_ptr = args)
            {
                _CallNonvirtualVoidMethodA(env, instance, type, method, (JValue*)_args_ptr);
            }
        }

        delegate IntPtr GetFieldIDDelegate(JniNativeInterface** env, IntPtr type, byte* name, byte* signature);
        GetFieldIDDelegate? __GetFieldID;
        GetFieldIDDelegate _GetFieldID => __GetFieldID ??= GetDelegateForFunctionPointer<GetFieldIDDelegate>((*env)->GetFieldID);

        public JFieldID GetFieldID(JClass type, ReadOnlySpan<byte> name, ReadOnlySpan<byte> signature)
        {
            JFieldID @return;
            fixed (byte* _name_ptr = name)
            {
                fixed (byte* _signature_ptr = signature)
                {
                    @return = _GetFieldID(env, type, (byte*)_name_ptr, (byte*)_signature_ptr);
                }
            }
            return @return;
        }

        delegate IntPtr GetObjectFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetObjectFieldDelegate? __GetObjectField;
        GetObjectFieldDelegate _GetObjectField => __GetObjectField ??= GetDelegateForFunctionPointer<GetObjectFieldDelegate>((*env)->GetObjectField);

        public JObject GetObjectField(JObject instance, JFieldID field)
        {
            JObject @return;
            @return = _GetObjectField(env, instance, field);
            return @return;
        }

        delegate byte GetBooleanFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetBooleanFieldDelegate? __GetBooleanField;
        GetBooleanFieldDelegate _GetBooleanField => __GetBooleanField ??= GetDelegateForFunctionPointer<GetBooleanFieldDelegate>((*env)->GetBooleanField);

        public JBoolean GetBooleanField(JObject instance, JFieldID field)
        {
            JBoolean @return;
            @return = (JBoolean)_GetBooleanField(env, instance, field);
            return @return;
        }

        delegate sbyte GetByteFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetByteFieldDelegate? __GetByteField;
        GetByteFieldDelegate _GetByteField => __GetByteField ??= GetDelegateForFunctionPointer<GetByteFieldDelegate>((*env)->GetByteField);

        public JByte GetByteField(JObject instance, JFieldID field)
        {
            JByte @return;
            @return = (JByte)_GetByteField(env, instance, field);
            return @return;
        }

        delegate char GetCharFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetCharFieldDelegate? __GetCharField;
        GetCharFieldDelegate _GetCharField => __GetCharField ??= GetDelegateForFunctionPointer<GetCharFieldDelegate>((*env)->GetCharField);

        public JChar GetCharField(JObject instance, JFieldID field)
        {
            JChar @return;
            @return = (JChar)_GetCharField(env, instance, field);
            return @return;
        }

        delegate short GetShortFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetShortFieldDelegate? __GetShortField;
        GetShortFieldDelegate _GetShortField => __GetShortField ??= GetDelegateForFunctionPointer<GetShortFieldDelegate>((*env)->GetShortField);

        public JShort GetShortField(JObject instance, JFieldID field)
        {
            JShort @return;
            @return = (JShort)_GetShortField(env, instance, field);
            return @return;
        }

        delegate int GetIntFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetIntFieldDelegate? __GetIntField;
        GetIntFieldDelegate _GetIntField => __GetIntField ??= GetDelegateForFunctionPointer<GetIntFieldDelegate>((*env)->GetIntField);

        public JInt GetIntField(JObject instance, JFieldID field)
        {
            JInt @return;
            @return = (JInt)_GetIntField(env, instance, field);
            return @return;
        }

        delegate long GetLongFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetLongFieldDelegate? __GetLongField;
        GetLongFieldDelegate _GetLongField => __GetLongField ??= GetDelegateForFunctionPointer<GetLongFieldDelegate>((*env)->GetLongField);

        public JLong GetLongField(JObject instance, JFieldID field)
        {
            JLong @return;
            @return = (JLong)_GetLongField(env, instance, field);
            return @return;
        }

        delegate float GetFloatFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetFloatFieldDelegate? __GetFloatField;
        GetFloatFieldDelegate _GetFloatField => __GetFloatField ??= GetDelegateForFunctionPointer<GetFloatFieldDelegate>((*env)->GetFloatField);

        public JFloat GetFloatField(JObject instance, JFieldID field)
        {
            JFloat @return;
            @return = (JFloat)_GetFloatField(env, instance, field);
            return @return;
        }

        delegate double GetDoubleFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field);
        GetDoubleFieldDelegate? __GetDoubleField;
        GetDoubleFieldDelegate _GetDoubleField => __GetDoubleField ??= GetDelegateForFunctionPointer<GetDoubleFieldDelegate>((*env)->GetDoubleField);

        public JDouble GetDoubleField(JObject instance, JFieldID field)
        {
            JDouble @return;
            @return = (JDouble)_GetDoubleField(env, instance, field);
            return @return;
        }

        delegate void SetObjectFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, IntPtr value);
        SetObjectFieldDelegate? __SetObjectField;
        SetObjectFieldDelegate _SetObjectField => __SetObjectField ??= GetDelegateForFunctionPointer<SetObjectFieldDelegate>((*env)->SetObjectField);

        public void SetObjectField(JObject instance, JFieldID field, JObject value)
        {
            _SetObjectField(env, instance, field, value);
        }

        delegate void SetBooleanFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, byte value);
        SetBooleanFieldDelegate? __SetBooleanField;
        SetBooleanFieldDelegate _SetBooleanField => __SetBooleanField ??= GetDelegateForFunctionPointer<SetBooleanFieldDelegate>((*env)->SetBooleanField);

        public void SetBooleanField(JObject instance, JFieldID field, JBoolean value)
        {
            _SetBooleanField(env, instance, field, (byte)value);
        }

        delegate void SetByteFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, sbyte value);
        SetByteFieldDelegate? __SetByteField;
        SetByteFieldDelegate _SetByteField => __SetByteField ??= GetDelegateForFunctionPointer<SetByteFieldDelegate>((*env)->SetByteField);

        public void SetByteField(JObject instance, JFieldID field, JByte value)
        {
            _SetByteField(env, instance, field, (sbyte)value);
        }

        delegate void SetCharFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, char value);
        SetCharFieldDelegate? __SetCharField;
        SetCharFieldDelegate _SetCharField => __SetCharField ??= GetDelegateForFunctionPointer<SetCharFieldDelegate>((*env)->SetCharField);

        public void SetCharField(JObject instance, JFieldID field, JChar value)
        {
            _SetCharField(env, instance, field, (char)value);
        }

        delegate void SetShortFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, short value);
        SetShortFieldDelegate? __SetShortField;
        SetShortFieldDelegate _SetShortField => __SetShortField ??= GetDelegateForFunctionPointer<SetShortFieldDelegate>((*env)->SetShortField);

        public void SetShortField(JObject instance, JFieldID field, JShort value)
        {
            _SetShortField(env, instance, field, (short)value);
        }

        delegate void SetIntFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, int value);
        SetIntFieldDelegate? __SetIntField;
        SetIntFieldDelegate _SetIntField => __SetIntField ??= GetDelegateForFunctionPointer<SetIntFieldDelegate>((*env)->SetIntField);

        public void SetIntField(JObject instance, JFieldID field, JInt value)
        {
            _SetIntField(env, instance, field, (int)value);
        }

        delegate void SetLongFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, long value);
        SetLongFieldDelegate? __SetLongField;
        SetLongFieldDelegate _SetLongField => __SetLongField ??= GetDelegateForFunctionPointer<SetLongFieldDelegate>((*env)->SetLongField);

        public void SetLongField(JObject instance, JFieldID field, JLong value)
        {
            _SetLongField(env, instance, field, (long)value);
        }

        delegate void SetFloatFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, float value);
        SetFloatFieldDelegate? __SetFloatField;
        SetFloatFieldDelegate _SetFloatField => __SetFloatField ??= GetDelegateForFunctionPointer<SetFloatFieldDelegate>((*env)->SetFloatField);

        public void SetFloatField(JObject instance, JFieldID field, JFloat value)
        {
            _SetFloatField(env, instance, field, (float)value);
        }

        delegate void SetDoubleFieldDelegate(JniNativeInterface** env, IntPtr instance, IntPtr field, double value);
        SetDoubleFieldDelegate? __SetDoubleField;
        SetDoubleFieldDelegate _SetDoubleField => __SetDoubleField ??= GetDelegateForFunctionPointer<SetDoubleFieldDelegate>((*env)->SetDoubleField);

        public void SetDoubleField(JObject instance, JFieldID field, JDouble value)
        {
            _SetDoubleField(env, instance, field, (double)value);
        }

        delegate IntPtr GetStaticMethodIDDelegate(JniNativeInterface** env, IntPtr type, byte* name, byte* signature);
        GetStaticMethodIDDelegate? __GetStaticMethodID;
        GetStaticMethodIDDelegate _GetStaticMethodID => __GetStaticMethodID ??= GetDelegateForFunctionPointer<GetStaticMethodIDDelegate>((*env)->GetStaticMethodID);

        public JMethodID GetStaticMethodID(JClass type, ReadOnlySpan<byte> name, ReadOnlySpan<byte> signature)
        {
            JMethodID @return;
            fixed (byte* _name_ptr = name)
            {
                fixed (byte* _signature_ptr = signature)
                {
                    @return = _GetStaticMethodID(env, type, (byte*)_name_ptr, (byte*)_signature_ptr);
                }
            }
            return @return;
        }

        delegate IntPtr CallStaticObjectMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticObjectMethodADelegate? __CallStaticObjectMethodA;
        CallStaticObjectMethodADelegate _CallStaticObjectMethodA => __CallStaticObjectMethodA ??= GetDelegateForFunctionPointer<CallStaticObjectMethodADelegate>((*env)->CallStaticObjectMethodA);

        public JObject CallStaticObjectMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JObject @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = _CallStaticObjectMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate byte CallStaticBooleanMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticBooleanMethodDelegate? __CallStaticBooleanMethod;
        CallStaticBooleanMethodDelegate _CallStaticBooleanMethod => __CallStaticBooleanMethod ??= GetDelegateForFunctionPointer<CallStaticBooleanMethodDelegate>((*env)->CallStaticBooleanMethod);

        public JBoolean CallStaticBooleanMethod(JClass type, JMethodID method)
        {
            JBoolean @return;
            @return = (JBoolean)_CallStaticBooleanMethod(env, type, method);
            return @return;
        }

        delegate byte CallStaticBooleanMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticBooleanMethodADelegate? __CallStaticBooleanMethodA;
        CallStaticBooleanMethodADelegate _CallStaticBooleanMethodA => __CallStaticBooleanMethodA ??= GetDelegateForFunctionPointer<CallStaticBooleanMethodADelegate>((*env)->CallStaticBooleanMethodA);

        public JBoolean CallStaticBooleanMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JBoolean @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JBoolean)_CallStaticBooleanMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate sbyte CallStaticByteMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticByteMethodDelegate? __CallStaticByteMethod;
        CallStaticByteMethodDelegate _CallStaticByteMethod => __CallStaticByteMethod ??= GetDelegateForFunctionPointer<CallStaticByteMethodDelegate>((*env)->CallStaticByteMethod);

        public JByte CallStaticByteMethod(JClass type, JMethodID method)
        {
            JByte @return;
            @return = (JByte)_CallStaticByteMethod(env, type, method);
            return @return;
        }

        delegate sbyte CallStaticByteMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticByteMethodADelegate? __CallStaticByteMethodA;
        CallStaticByteMethodADelegate _CallStaticByteMethodA => __CallStaticByteMethodA ??= GetDelegateForFunctionPointer<CallStaticByteMethodADelegate>((*env)->CallStaticByteMethodA);

        public JByte CallStaticByteMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JByte @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JByte)_CallStaticByteMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate char CallStaticCharMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticCharMethodDelegate? __CallStaticCharMethod;
        CallStaticCharMethodDelegate _CallStaticCharMethod => __CallStaticCharMethod ??= GetDelegateForFunctionPointer<CallStaticCharMethodDelegate>((*env)->CallStaticCharMethod);

        public JChar CallStaticCharMethod(JClass type, JMethodID method)
        {
            JChar @return;
            @return = (JChar)_CallStaticCharMethod(env, type, method);
            return @return;
        }

        delegate char CallStaticCharMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticCharMethodADelegate? __CallStaticCharMethodA;
        CallStaticCharMethodADelegate _CallStaticCharMethodA => __CallStaticCharMethodA ??= GetDelegateForFunctionPointer<CallStaticCharMethodADelegate>((*env)->CallStaticCharMethodA);

        public JChar CallStaticCharMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JChar @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JChar)_CallStaticCharMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate short CallStaticShortMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticShortMethodDelegate? __CallStaticShortMethod;
        CallStaticShortMethodDelegate _CallStaticShortMethod => __CallStaticShortMethod ??= GetDelegateForFunctionPointer<CallStaticShortMethodDelegate>((*env)->CallStaticShortMethod);

        public JShort CallStaticShortMethod(JClass type, JMethodID method)
        {
            JShort @return;
            @return = (JShort)_CallStaticShortMethod(env, type, method);
            return @return;
        }

        delegate short CallStaticShortMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticShortMethodADelegate? __CallStaticShortMethodA;
        CallStaticShortMethodADelegate _CallStaticShortMethodA => __CallStaticShortMethodA ??= GetDelegateForFunctionPointer<CallStaticShortMethodADelegate>((*env)->CallStaticShortMethodA);

        public JShort CallStaticShortMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JShort @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JShort)_CallStaticShortMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate int CallStaticIntMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticIntMethodDelegate? __CallStaticIntMethod;
        CallStaticIntMethodDelegate _CallStaticIntMethod => __CallStaticIntMethod ??= GetDelegateForFunctionPointer<CallStaticIntMethodDelegate>((*env)->CallStaticIntMethod);

        public JInt CallStaticIntMethod(JClass type, JMethodID method)
        {
            JInt @return;
            @return = (JInt)_CallStaticIntMethod(env, type, method);
            return @return;
        }

        delegate int CallStaticIntMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticIntMethodADelegate? __CallStaticIntMethodA;
        CallStaticIntMethodADelegate _CallStaticIntMethodA => __CallStaticIntMethodA ??= GetDelegateForFunctionPointer<CallStaticIntMethodADelegate>((*env)->CallStaticIntMethodA);

        public JInt CallStaticIntMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JInt @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JInt)_CallStaticIntMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate long CallStaticLongMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticLongMethodDelegate? __CallStaticLongMethod;
        CallStaticLongMethodDelegate _CallStaticLongMethod => __CallStaticLongMethod ??= GetDelegateForFunctionPointer<CallStaticLongMethodDelegate>((*env)->CallStaticLongMethod);

        public JLong CallStaticLongMethod(JClass type, JMethodID method)
        {
            JLong @return;
            @return = (JLong)_CallStaticLongMethod(env, type, method);
            return @return;
        }

        delegate long CallStaticLongMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticLongMethodADelegate? __CallStaticLongMethodA;
        CallStaticLongMethodADelegate _CallStaticLongMethodA => __CallStaticLongMethodA ??= GetDelegateForFunctionPointer<CallStaticLongMethodADelegate>((*env)->CallStaticLongMethodA);

        public JLong CallStaticLongMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JLong @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JLong)_CallStaticLongMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate float CallStaticFloatMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticFloatMethodDelegate? __CallStaticFloatMethod;
        CallStaticFloatMethodDelegate _CallStaticFloatMethod => __CallStaticFloatMethod ??= GetDelegateForFunctionPointer<CallStaticFloatMethodDelegate>((*env)->CallStaticFloatMethod);

        public JFloat CallStaticFloatMethod(JClass type, JMethodID method)
        {
            JFloat @return;
            @return = (JFloat)_CallStaticFloatMethod(env, type, method);
            return @return;
        }

        delegate float CallStaticFloatMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticFloatMethodADelegate? __CallStaticFloatMethodA;
        CallStaticFloatMethodADelegate _CallStaticFloatMethodA => __CallStaticFloatMethodA ??= GetDelegateForFunctionPointer<CallStaticFloatMethodADelegate>((*env)->CallStaticFloatMethodA);

        public JFloat CallStaticFloatMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JFloat @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JFloat)_CallStaticFloatMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate double CallStaticDoubleMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticDoubleMethodDelegate? __CallStaticDoubleMethod;
        CallStaticDoubleMethodDelegate _CallStaticDoubleMethod => __CallStaticDoubleMethod ??= GetDelegateForFunctionPointer<CallStaticDoubleMethodDelegate>((*env)->CallStaticDoubleMethod);

        public JDouble CallStaticDoubleMethod(JClass type, JMethodID method)
        {
            JDouble @return;
            @return = (JDouble)_CallStaticDoubleMethod(env, type, method);
            return @return;
        }

        delegate double CallStaticDoubleMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticDoubleMethodADelegate? __CallStaticDoubleMethodA;
        CallStaticDoubleMethodADelegate _CallStaticDoubleMethodA => __CallStaticDoubleMethodA ??= GetDelegateForFunctionPointer<CallStaticDoubleMethodADelegate>((*env)->CallStaticDoubleMethodA);

        public JDouble CallStaticDoubleMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            JDouble @return;
            fixed (JValue* _args_ptr = args)
            {
                @return = (JDouble)_CallStaticDoubleMethodA(env, type, method, (JValue*)_args_ptr);
            }
            return @return;
        }

        delegate void CallStaticVoidMethodDelegate(JniNativeInterface** env, IntPtr type, IntPtr method);
        CallStaticVoidMethodDelegate? __CallStaticVoidMethod;
        CallStaticVoidMethodDelegate _CallStaticVoidMethod => __CallStaticVoidMethod ??= GetDelegateForFunctionPointer<CallStaticVoidMethodDelegate>((*env)->CallStaticVoidMethod);

        public void CallStaticVoidMethod(JClass type, JMethodID method)
        {
            _CallStaticVoidMethod(env, type, method);
        }

        delegate void CallStaticVoidMethodADelegate(JniNativeInterface** env, IntPtr type, IntPtr method, JValue* args);
        CallStaticVoidMethodADelegate? __CallStaticVoidMethodA;
        CallStaticVoidMethodADelegate _CallStaticVoidMethodA => __CallStaticVoidMethodA ??= GetDelegateForFunctionPointer<CallStaticVoidMethodADelegate>((*env)->CallStaticVoidMethodA);

        public void CallStaticVoidMethodA(JClass type, JMethodID method, ReadOnlySpan<JValue> args)
        {
            fixed (JValue* _args_ptr = args)
            {
                _CallStaticVoidMethodA(env, type, method, (JValue*)_args_ptr);
            }
        }

        delegate IntPtr GetStaticFieldIDDelegate(JniNativeInterface** env, IntPtr type, byte* name, byte* signature);
        GetStaticFieldIDDelegate? __GetStaticFieldID;
        GetStaticFieldIDDelegate _GetStaticFieldID => __GetStaticFieldID ??= GetDelegateForFunctionPointer<GetStaticFieldIDDelegate>((*env)->GetStaticFieldID);

        public JFieldID GetStaticFieldID(JClass type, ReadOnlySpan<byte> name, ReadOnlySpan<byte> signature)
        {
            JFieldID @return;
            fixed (byte* _name_ptr = name)
            {
                fixed (byte* _signature_ptr = signature)
                {
                    @return = _GetStaticFieldID(env, type, (byte*)_name_ptr, (byte*)_signature_ptr);
                }
            }
            return @return;
        }

        delegate IntPtr GetStaticObjectFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticObjectFieldDelegate? __GetStaticObjectField;
        GetStaticObjectFieldDelegate _GetStaticObjectField => __GetStaticObjectField ??= GetDelegateForFunctionPointer<GetStaticObjectFieldDelegate>((*env)->GetStaticObjectField);

        public JObject GetStaticObjectField(JClass type, JFieldID field)
        {
            JObject @return;
            @return = _GetStaticObjectField(env, type, field);
            return @return;
        }

        delegate byte GetStaticBooleanFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticBooleanFieldDelegate? __GetStaticBooleanField;
        GetStaticBooleanFieldDelegate _GetStaticBooleanField => __GetStaticBooleanField ??= GetDelegateForFunctionPointer<GetStaticBooleanFieldDelegate>((*env)->GetStaticBooleanField);

        public JBoolean GetStaticBooleanField(JClass type, JFieldID field)
        {
            JBoolean @return;
            @return = (JBoolean)_GetStaticBooleanField(env, type, field);
            return @return;
        }

        delegate sbyte GetStaticByteFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticByteFieldDelegate? __GetStaticByteField;
        GetStaticByteFieldDelegate _GetStaticByteField => __GetStaticByteField ??= GetDelegateForFunctionPointer<GetStaticByteFieldDelegate>((*env)->GetStaticByteField);

        public JByte GetStaticByteField(JClass type, JFieldID field)
        {
            JByte @return;
            @return = (JByte)_GetStaticByteField(env, type, field);
            return @return;
        }

        delegate char GetStaticCharFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticCharFieldDelegate? __GetStaticCharField;
        GetStaticCharFieldDelegate _GetStaticCharField => __GetStaticCharField ??= GetDelegateForFunctionPointer<GetStaticCharFieldDelegate>((*env)->GetStaticCharField);

        public JChar GetStaticCharField(JClass type, JFieldID field)
        {
            JChar @return;
            @return = (JChar)_GetStaticCharField(env, type, field);
            return @return;
        }

        delegate short GetStaticShortFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticShortFieldDelegate? __GetStaticShortField;
        GetStaticShortFieldDelegate _GetStaticShortField => __GetStaticShortField ??= GetDelegateForFunctionPointer<GetStaticShortFieldDelegate>((*env)->GetStaticShortField);

        public JShort GetStaticShortField(JClass type, JFieldID field)
        {
            JShort @return;
            @return = (JShort)_GetStaticShortField(env, type, field);
            return @return;
        }

        delegate int GetStaticIntFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticIntFieldDelegate? __GetStaticIntField;
        GetStaticIntFieldDelegate _GetStaticIntField => __GetStaticIntField ??= GetDelegateForFunctionPointer<GetStaticIntFieldDelegate>((*env)->GetStaticIntField);

        public JInt GetStaticIntField(JClass type, JFieldID field)
        {
            JInt @return;
            @return = (JInt)_GetStaticIntField(env, type, field);
            return @return;
        }

        delegate long GetStaticLongFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticLongFieldDelegate? __GetStaticLongField;
        GetStaticLongFieldDelegate _GetStaticLongField => __GetStaticLongField ??= GetDelegateForFunctionPointer<GetStaticLongFieldDelegate>((*env)->GetStaticLongField);

        public JLong GetStaticLongField(JClass type, JFieldID field)
        {
            JLong @return;
            @return = (JLong)_GetStaticLongField(env, type, field);
            return @return;
        }

        delegate float GetStaticFloatFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticFloatFieldDelegate? __GetStaticFloatField;
        GetStaticFloatFieldDelegate _GetStaticFloatField => __GetStaticFloatField ??= GetDelegateForFunctionPointer<GetStaticFloatFieldDelegate>((*env)->GetStaticFloatField);

        public JFloat GetStaticFloatField(JClass type, JFieldID field)
        {
            JFloat @return;
            @return = (JFloat)_GetStaticFloatField(env, type, field);
            return @return;
        }

        delegate double GetStaticDoubleFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field);
        GetStaticDoubleFieldDelegate? __GetStaticDoubleField;
        GetStaticDoubleFieldDelegate _GetStaticDoubleField => __GetStaticDoubleField ??= GetDelegateForFunctionPointer<GetStaticDoubleFieldDelegate>((*env)->GetStaticDoubleField);

        public JDouble GetStaticDoubleField(JClass type, JFieldID field)
        {
            JDouble @return;
            @return = (JDouble)_GetStaticDoubleField(env, type, field);
            return @return;
        }

        delegate void SetStaticObjectFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, IntPtr value);
        SetStaticObjectFieldDelegate? __SetStaticObjectField;
        SetStaticObjectFieldDelegate _SetStaticObjectField => __SetStaticObjectField ??= GetDelegateForFunctionPointer<SetStaticObjectFieldDelegate>((*env)->SetStaticObjectField);

        public void SetStaticObjectField(JClass type, JFieldID field, JObject value)
        {
            _SetStaticObjectField(env, type, field, value);
        }

        delegate void SetStaticBooleanFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, byte value);
        SetStaticBooleanFieldDelegate? __SetStaticBooleanField;
        SetStaticBooleanFieldDelegate _SetStaticBooleanField => __SetStaticBooleanField ??= GetDelegateForFunctionPointer<SetStaticBooleanFieldDelegate>((*env)->SetStaticBooleanField);

        public void SetStaticBooleanField(JClass type, JFieldID field, JBoolean value)
        {
            _SetStaticBooleanField(env, type, field, (byte)value);
        }

        delegate void SetStaticByteFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, sbyte value);
        SetStaticByteFieldDelegate? __SetStaticByteField;
        SetStaticByteFieldDelegate _SetStaticByteField => __SetStaticByteField ??= GetDelegateForFunctionPointer<SetStaticByteFieldDelegate>((*env)->SetStaticByteField);

        public void SetStaticByteField(JClass type, JFieldID field, JByte value)
        {
            _SetStaticByteField(env, type, field, (sbyte)value);
        }

        delegate void SetStaticCharFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, char value);
        SetStaticCharFieldDelegate? __SetStaticCharField;
        SetStaticCharFieldDelegate _SetStaticCharField => __SetStaticCharField ??= GetDelegateForFunctionPointer<SetStaticCharFieldDelegate>((*env)->SetStaticCharField);

        public void SetStaticCharField(JClass type, JFieldID field, JChar value)
        {
            _SetStaticCharField(env, type, field, (char)value);
        }

        delegate void SetStaticShortFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, short value);
        SetStaticShortFieldDelegate? __SetStaticShortField;
        SetStaticShortFieldDelegate _SetStaticShortField => __SetStaticShortField ??= GetDelegateForFunctionPointer<SetStaticShortFieldDelegate>((*env)->SetStaticShortField);

        public void SetStaticShortField(JClass type, JFieldID field, JShort value)
        {
            _SetStaticShortField(env, type, field, (short)value);
        }

        delegate void SetStaticIntFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, int value);
        SetStaticIntFieldDelegate? __SetStaticIntField;
        SetStaticIntFieldDelegate _SetStaticIntField => __SetStaticIntField ??= GetDelegateForFunctionPointer<SetStaticIntFieldDelegate>((*env)->SetStaticIntField);

        public void SetStaticIntField(JClass type, JFieldID field, JInt value)
        {
            _SetStaticIntField(env, type, field, (int)value);
        }

        delegate void SetStaticLongFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, long value);
        SetStaticLongFieldDelegate? __SetStaticLongField;
        SetStaticLongFieldDelegate _SetStaticLongField => __SetStaticLongField ??= GetDelegateForFunctionPointer<SetStaticLongFieldDelegate>((*env)->SetStaticLongField);

        public void SetStaticLongField(JClass type, JFieldID field, JLong value)
        {
            _SetStaticLongField(env, type, field, (long)value);
        }

        delegate void SetStaticFloatFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, float value);
        SetStaticFloatFieldDelegate? __SetStaticFloatField;
        SetStaticFloatFieldDelegate _SetStaticFloatField => __SetStaticFloatField ??= GetDelegateForFunctionPointer<SetStaticFloatFieldDelegate>((*env)->SetStaticFloatField);

        public void SetStaticFloatField(JClass type, JFieldID field, JFloat value)
        {
            _SetStaticFloatField(env, type, field, (float)value);
        }

        delegate void SetStaticDoubleFieldDelegate(JniNativeInterface** env, IntPtr type, IntPtr field, double value);
        SetStaticDoubleFieldDelegate? __SetStaticDoubleField;
        SetStaticDoubleFieldDelegate _SetStaticDoubleField => __SetStaticDoubleField ??= GetDelegateForFunctionPointer<SetStaticDoubleFieldDelegate>((*env)->SetStaticDoubleField);

        public void SetStaticDoubleField(JClass type, JFieldID field, JDouble value)
        {
            _SetStaticDoubleField(env, type, field, (double)value);
        }

        delegate IntPtr NewStringDelegate(JniNativeInterface** env, char* unicodeChars, int length);
        NewStringDelegate? __NewString;
        NewStringDelegate _NewString => __NewString ??= GetDelegateForFunctionPointer<NewStringDelegate>((*env)->NewString);

        public JString NewString(ReadOnlySpan<JChar> unicodeChars, JSize length)
        {
            JString @return;
            fixed (JChar* _unicodeChars_ptr = unicodeChars)
            {
                @return = _NewString(env, (char*)_unicodeChars_ptr, (int)length);
            }
            return @return;
        }

        delegate int GetStringLengthDelegate(JniNativeInterface** env, IntPtr stringInstance);
        GetStringLengthDelegate? __GetStringLength;
        GetStringLengthDelegate _GetStringLength => __GetStringLength ??= GetDelegateForFunctionPointer<GetStringLengthDelegate>((*env)->GetStringLength);

        public JSize GetStringLength(JString stringInstance)
        {
            JSize @return;
            @return = (JSize)_GetStringLength(env, stringInstance);
            return @return;
        }

        delegate char* GetStringCharsDelegate(JniNativeInterface** env, IntPtr stringInstance, out byte isCopy);
        GetStringCharsDelegate? __GetStringChars;
        GetStringCharsDelegate _GetStringChars => __GetStringChars ??= GetDelegateForFunctionPointer<GetStringCharsDelegate>((*env)->GetStringChars);

        public JPointer<JChar> GetStringChars(JString stringInstance, out JBoolean isCopy)
        {
            JPointer<JChar> @return;
            @return = (JPointer<JChar>)(JChar*)_GetStringChars(env, stringInstance, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate void ReleaseStringCharsDelegate(JniNativeInterface** env, IntPtr stringInstance, char* chars);
        ReleaseStringCharsDelegate? __ReleaseStringChars;
        ReleaseStringCharsDelegate _ReleaseStringChars => __ReleaseStringChars ??= GetDelegateForFunctionPointer<ReleaseStringCharsDelegate>((*env)->ReleaseStringChars);

        public void ReleaseStringChars(JString stringInstance, ReadOnlySpan<JChar> chars)
        {
            fixed (JChar* _chars_ptr = chars)
            {
                _ReleaseStringChars(env, stringInstance, (char*)_chars_ptr);
            }
        }

        delegate IntPtr NewStringUTFDelegate(JniNativeInterface** env, byte* bytes);
        NewStringUTFDelegate? __NewStringUTF;
        NewStringUTFDelegate _NewStringUTF => __NewStringUTF ??= GetDelegateForFunctionPointer<NewStringUTFDelegate>((*env)->NewStringUTF);

        public JString NewStringUTF(ReadOnlySpan<byte> bytes)
        {
            JString @return;
            fixed (byte* _bytes_ptr = bytes)
            {
                @return = _NewStringUTF(env, (byte*)_bytes_ptr);
            }
            return @return;
        }

        delegate int GetStringUTFLengthDelegate(JniNativeInterface** env, IntPtr stringInstance);
        GetStringUTFLengthDelegate? __GetStringUTFLength;
        GetStringUTFLengthDelegate _GetStringUTFLength => __GetStringUTFLength ??= GetDelegateForFunctionPointer<GetStringUTFLengthDelegate>((*env)->GetStringUTFLength);

        public JSize GetStringUTFLength(JString stringInstance)
        {
            JSize @return;
            @return = (JSize)_GetStringUTFLength(env, stringInstance);
            return @return;
        }

        delegate byte* GetStringUTFCharsDelegate(JniNativeInterface** env, IntPtr stringInstance, out byte isCopy);
        GetStringUTFCharsDelegate? __GetStringUTFChars;
        GetStringUTFCharsDelegate _GetStringUTFChars => __GetStringUTFChars ??= GetDelegateForFunctionPointer<GetStringUTFCharsDelegate>((*env)->GetStringUTFChars);

        public JPointer<byte> GetStringUTFChars(JString stringInstance, out JBoolean isCopy)
        {
            JPointer<byte> @return;
            @return = (JPointer<byte>)(byte*)_GetStringUTFChars(env, stringInstance, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate void ReleaseStringUTFCharsDelegate(JniNativeInterface** env, IntPtr stringInstance, byte* utf);
        ReleaseStringUTFCharsDelegate? __ReleaseStringUTFChars;
        ReleaseStringUTFCharsDelegate _ReleaseStringUTFChars => __ReleaseStringUTFChars ??= GetDelegateForFunctionPointer<ReleaseStringUTFCharsDelegate>((*env)->ReleaseStringUTFChars);

        public void ReleaseStringUTFChars(JString stringInstance, ReadOnlySpan<byte> utf)
        {
            fixed (byte* _utf_ptr = utf)
            {
                _ReleaseStringUTFChars(env, stringInstance, (byte*)_utf_ptr);
            }
        }

        delegate int GetArrayLengthDelegate(JniNativeInterface** env, IntPtr array);
        GetArrayLengthDelegate? __GetArrayLength;
        GetArrayLengthDelegate _GetArrayLength => __GetArrayLength ??= GetDelegateForFunctionPointer<GetArrayLengthDelegate>((*env)->GetArrayLength);

        public JSize GetArrayLength(JArray array)
        {
            JSize @return;
            @return = (JSize)_GetArrayLength(env, array);
            return @return;
        }

        delegate IntPtr NewObjectArrayDelegate(JniNativeInterface** env, int length, IntPtr elementClass, IntPtr initialElement);
        NewObjectArrayDelegate? __NewObjectArray;
        NewObjectArrayDelegate _NewObjectArray => __NewObjectArray ??= GetDelegateForFunctionPointer<NewObjectArrayDelegate>((*env)->NewObjectArray);

        public JObjectArray NewObjectArray(JSize length, JClass elementClass, JObject initialElement)
        {
            JObjectArray @return;
            @return = _NewObjectArray(env, (int)length, elementClass, initialElement);
            return @return;
        }

        delegate IntPtr GetObjectArrayElementDelegate(JniNativeInterface** env, IntPtr array, int index);
        GetObjectArrayElementDelegate? __GetObjectArrayElement;
        GetObjectArrayElementDelegate _GetObjectArrayElement => __GetObjectArrayElement ??= GetDelegateForFunctionPointer<GetObjectArrayElementDelegate>((*env)->GetObjectArrayElement);

        public JObject GetObjectArrayElement(JObjectArray array, JSize index)
        {
            JObject @return;
            @return = _GetObjectArrayElement(env, array, (int)index);
            return @return;
        }

        delegate void SetObjectArrayElementDelegate(JniNativeInterface** env, IntPtr array, int index, IntPtr value);
        SetObjectArrayElementDelegate? __SetObjectArrayElement;
        SetObjectArrayElementDelegate _SetObjectArrayElement => __SetObjectArrayElement ??= GetDelegateForFunctionPointer<SetObjectArrayElementDelegate>((*env)->SetObjectArrayElement);

        public void SetObjectArrayElement(JObjectArray array, JSize index, JObject value)
        {
            _SetObjectArrayElement(env, array, (int)index, value);
        }

        delegate IntPtr NewBooleanArrayDelegate(JniNativeInterface** env, int length);
        NewBooleanArrayDelegate? __NewBooleanArray;
        NewBooleanArrayDelegate _NewBooleanArray => __NewBooleanArray ??= GetDelegateForFunctionPointer<NewBooleanArrayDelegate>((*env)->NewBooleanArray);

        public JBooleanArray NewBooleanArray(JSize length)
        {
            JBooleanArray @return;
            @return = _NewBooleanArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewByteArrayDelegate(JniNativeInterface** env, int length);
        NewByteArrayDelegate? __NewByteArray;
        NewByteArrayDelegate _NewByteArray => __NewByteArray ??= GetDelegateForFunctionPointer<NewByteArrayDelegate>((*env)->NewByteArray);

        public JByteArray NewByteArray(JSize length)
        {
            JByteArray @return;
            @return = _NewByteArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewCharArrayDelegate(JniNativeInterface** env, int length);
        NewCharArrayDelegate? __NewCharArray;
        NewCharArrayDelegate _NewCharArray => __NewCharArray ??= GetDelegateForFunctionPointer<NewCharArrayDelegate>((*env)->NewCharArray);

        public JCharArray NewCharArray(JSize length)
        {
            JCharArray @return;
            @return = _NewCharArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewShortArrayDelegate(JniNativeInterface** env, int length);
        NewShortArrayDelegate? __NewShortArray;
        NewShortArrayDelegate _NewShortArray => __NewShortArray ??= GetDelegateForFunctionPointer<NewShortArrayDelegate>((*env)->NewShortArray);

        public JShortArray NewShortArray(JSize length)
        {
            JShortArray @return;
            @return = _NewShortArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewIntArrayDelegate(JniNativeInterface** env, int length);
        NewIntArrayDelegate? __NewIntArray;
        NewIntArrayDelegate _NewIntArray => __NewIntArray ??= GetDelegateForFunctionPointer<NewIntArrayDelegate>((*env)->NewIntArray);

        public JIntArray NewIntArray(JSize length)
        {
            JIntArray @return;
            @return = _NewIntArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewLongArrayDelegate(JniNativeInterface** env, int length);
        NewLongArrayDelegate? __NewLongArray;
        NewLongArrayDelegate _NewLongArray => __NewLongArray ??= GetDelegateForFunctionPointer<NewLongArrayDelegate>((*env)->NewLongArray);

        public JLongArray NewLongArray(JSize length)
        {
            JLongArray @return;
            @return = _NewLongArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewFloatArrayDelegate(JniNativeInterface** env, int length);
        NewFloatArrayDelegate? __NewFloatArray;
        NewFloatArrayDelegate _NewFloatArray => __NewFloatArray ??= GetDelegateForFunctionPointer<NewFloatArrayDelegate>((*env)->NewFloatArray);

        public JFloatArray NewFloatArray(JSize length)
        {
            JFloatArray @return;
            @return = _NewFloatArray(env, (int)length);
            return @return;
        }

        delegate IntPtr NewDoubleArrayDelegate(JniNativeInterface** env, int length);
        NewDoubleArrayDelegate? __NewDoubleArray;
        NewDoubleArrayDelegate _NewDoubleArray => __NewDoubleArray ??= GetDelegateForFunctionPointer<NewDoubleArrayDelegate>((*env)->NewDoubleArray);

        public JDoubleArray NewDoubleArray(JSize length)
        {
            JDoubleArray @return;
            @return = _NewDoubleArray(env, (int)length);
            return @return;
        }

        delegate byte* GetBooleanArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetBooleanArrayElementsDelegate? __GetBooleanArrayElements;
        GetBooleanArrayElementsDelegate _GetBooleanArrayElements => __GetBooleanArrayElements ??= GetDelegateForFunctionPointer<GetBooleanArrayElementsDelegate>((*env)->GetBooleanArrayElements);

        public JPointer<JBoolean> GetBooleanArrayElements(JBooleanArray array, out JBoolean isCopy)
        {
            JPointer<JBoolean> @return;
            @return = (JPointer<JBoolean>)(JBoolean*)_GetBooleanArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate sbyte* GetByteArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetByteArrayElementsDelegate? __GetByteArrayElements;
        GetByteArrayElementsDelegate _GetByteArrayElements => __GetByteArrayElements ??= GetDelegateForFunctionPointer<GetByteArrayElementsDelegate>((*env)->GetByteArrayElements);

        public JPointer<JByte> GetByteArrayElements(JByteArray array, out JBoolean isCopy)
        {
            JPointer<JByte> @return;
            @return = (JPointer<JByte>)(JByte*)_GetByteArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate char* GetCharArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetCharArrayElementsDelegate? __GetCharArrayElements;
        GetCharArrayElementsDelegate _GetCharArrayElements => __GetCharArrayElements ??= GetDelegateForFunctionPointer<GetCharArrayElementsDelegate>((*env)->GetCharArrayElements);

        public JPointer<JChar> GetCharArrayElements(JCharArray array, out JBoolean isCopy)
        {
            JPointer<JChar> @return;
            @return = (JPointer<JChar>)(JChar*)_GetCharArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate short* GetShortArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetShortArrayElementsDelegate? __GetShortArrayElements;
        GetShortArrayElementsDelegate _GetShortArrayElements => __GetShortArrayElements ??= GetDelegateForFunctionPointer<GetShortArrayElementsDelegate>((*env)->GetShortArrayElements);

        public JPointer<JShort> GetShortArrayElements(JShortArray array, out JBoolean isCopy)
        {
            JPointer<JShort> @return;
            @return = (JPointer<JShort>)(JShort*)_GetShortArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate int* GetIntArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetIntArrayElementsDelegate? __GetIntArrayElements;
        GetIntArrayElementsDelegate _GetIntArrayElements => __GetIntArrayElements ??= GetDelegateForFunctionPointer<GetIntArrayElementsDelegate>((*env)->GetIntArrayElements);

        public JPointer<JInt> GetIntArrayElements(JIntArray array, out JBoolean isCopy)
        {
            JPointer<JInt> @return;
            @return = (JPointer<JInt>)(JInt*)_GetIntArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate long* GetLongArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetLongArrayElementsDelegate? __GetLongArrayElements;
        GetLongArrayElementsDelegate _GetLongArrayElements => __GetLongArrayElements ??= GetDelegateForFunctionPointer<GetLongArrayElementsDelegate>((*env)->GetLongArrayElements);

        public JPointer<JLong> GetLongArrayElements(JLongArray array, out JBoolean isCopy)
        {
            JPointer<JLong> @return;
            @return = (JPointer<JLong>)(JLong*)_GetLongArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate float* GetFloatArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetFloatArrayElementsDelegate? __GetFloatArrayElements;
        GetFloatArrayElementsDelegate _GetFloatArrayElements => __GetFloatArrayElements ??= GetDelegateForFunctionPointer<GetFloatArrayElementsDelegate>((*env)->GetFloatArrayElements);

        public JPointer<JFloat> GetFloatArrayElements(JFloatArray array, out JBoolean isCopy)
        {
            JPointer<JFloat> @return;
            @return = (JPointer<JFloat>)(JFloat*)_GetFloatArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate double* GetDoubleArrayElementsDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetDoubleArrayElementsDelegate? __GetDoubleArrayElements;
        GetDoubleArrayElementsDelegate _GetDoubleArrayElements => __GetDoubleArrayElements ??= GetDelegateForFunctionPointer<GetDoubleArrayElementsDelegate>((*env)->GetDoubleArrayElements);

        public JPointer<JDouble> GetDoubleArrayElements(JDoubleArray array, out JBoolean isCopy)
        {
            JPointer<JDouble> @return;
            @return = (JPointer<JDouble>)(JDouble*)_GetDoubleArrayElements(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate void ReleaseBooleanArrayElementsDelegate(JniNativeInterface** env, IntPtr array, byte* elements, int mode);
        ReleaseBooleanArrayElementsDelegate? __ReleaseBooleanArrayElements;
        ReleaseBooleanArrayElementsDelegate _ReleaseBooleanArrayElements => __ReleaseBooleanArrayElements ??= GetDelegateForFunctionPointer<ReleaseBooleanArrayElementsDelegate>((*env)->ReleaseBooleanArrayElements);

        public void ReleaseBooleanArrayElements(JBooleanArray array, ReadOnlySpan<JBoolean> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JBoolean* _elements_ptr = elements)
            {
                _ReleaseBooleanArrayElements(env, array, (byte*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseByteArrayElementsDelegate(JniNativeInterface** env, IntPtr array, sbyte* elements, int mode);
        ReleaseByteArrayElementsDelegate? __ReleaseByteArrayElements;
        ReleaseByteArrayElementsDelegate _ReleaseByteArrayElements => __ReleaseByteArrayElements ??= GetDelegateForFunctionPointer<ReleaseByteArrayElementsDelegate>((*env)->ReleaseByteArrayElements);

        public void ReleaseByteArrayElements(JByteArray array, ReadOnlySpan<JByte> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JByte* _elements_ptr = elements)
            {
                _ReleaseByteArrayElements(env, array, (sbyte*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseCharArrayElementsDelegate(JniNativeInterface** env, IntPtr array, char* elements, int mode);
        ReleaseCharArrayElementsDelegate? __ReleaseCharArrayElements;
        ReleaseCharArrayElementsDelegate _ReleaseCharArrayElements => __ReleaseCharArrayElements ??= GetDelegateForFunctionPointer<ReleaseCharArrayElementsDelegate>((*env)->ReleaseCharArrayElements);

        public void ReleaseCharArrayElements(JCharArray array, ReadOnlySpan<JChar> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JChar* _elements_ptr = elements)
            {
                _ReleaseCharArrayElements(env, array, (char*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseShortArrayElementsDelegate(JniNativeInterface** env, IntPtr array, short* elements, int mode);
        ReleaseShortArrayElementsDelegate? __ReleaseShortArrayElements;
        ReleaseShortArrayElementsDelegate _ReleaseShortArrayElements => __ReleaseShortArrayElements ??= GetDelegateForFunctionPointer<ReleaseShortArrayElementsDelegate>((*env)->ReleaseShortArrayElements);

        public void ReleaseShortArrayElements(JShortArray array, ReadOnlySpan<JShort> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JShort* _elements_ptr = elements)
            {
                _ReleaseShortArrayElements(env, array, (short*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseIntArrayElementsDelegate(JniNativeInterface** env, IntPtr array, int* elements, int mode);
        ReleaseIntArrayElementsDelegate? __ReleaseIntArrayElements;
        ReleaseIntArrayElementsDelegate _ReleaseIntArrayElements => __ReleaseIntArrayElements ??= GetDelegateForFunctionPointer<ReleaseIntArrayElementsDelegate>((*env)->ReleaseIntArrayElements);

        public void ReleaseIntArrayElements(JIntArray array, ReadOnlySpan<JInt> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JInt* _elements_ptr = elements)
            {
                _ReleaseIntArrayElements(env, array, (int*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseLongArrayElementsDelegate(JniNativeInterface** env, IntPtr array, long* elements, int mode);
        ReleaseLongArrayElementsDelegate? __ReleaseLongArrayElements;
        ReleaseLongArrayElementsDelegate _ReleaseLongArrayElements => __ReleaseLongArrayElements ??= GetDelegateForFunctionPointer<ReleaseLongArrayElementsDelegate>((*env)->ReleaseLongArrayElements);

        public void ReleaseLongArrayElements(JLongArray array, ReadOnlySpan<JLong> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JLong* _elements_ptr = elements)
            {
                _ReleaseLongArrayElements(env, array, (long*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseFloatArrayElementsDelegate(JniNativeInterface** env, IntPtr array, float* elements, int mode);
        ReleaseFloatArrayElementsDelegate? __ReleaseFloatArrayElements;
        ReleaseFloatArrayElementsDelegate _ReleaseFloatArrayElements => __ReleaseFloatArrayElements ??= GetDelegateForFunctionPointer<ReleaseFloatArrayElementsDelegate>((*env)->ReleaseFloatArrayElements);

        public void ReleaseFloatArrayElements(JFloatArray array, ReadOnlySpan<JFloat> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JFloat* _elements_ptr = elements)
            {
                _ReleaseFloatArrayElements(env, array, (float*)_elements_ptr, (int)mode);
            }
        }

        delegate void ReleaseDoubleArrayElementsDelegate(JniNativeInterface** env, IntPtr array, double* elements, int mode);
        ReleaseDoubleArrayElementsDelegate? __ReleaseDoubleArrayElements;
        ReleaseDoubleArrayElementsDelegate _ReleaseDoubleArrayElements => __ReleaseDoubleArrayElements ??= GetDelegateForFunctionPointer<ReleaseDoubleArrayElementsDelegate>((*env)->ReleaseDoubleArrayElements);

        public void ReleaseDoubleArrayElements(JDoubleArray array, ReadOnlySpan<JDouble> elements, JniReleaseArrayElementsMode mode)
        {
            fixed (JDouble* _elements_ptr = elements)
            {
                _ReleaseDoubleArrayElements(env, array, (double*)_elements_ptr, (int)mode);
            }
        }

        delegate void GetBooleanArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, byte* buffer);
        GetBooleanArrayRegionDelegate? __GetBooleanArrayRegion;
        GetBooleanArrayRegionDelegate _GetBooleanArrayRegion => __GetBooleanArrayRegion ??= GetDelegateForFunctionPointer<GetBooleanArrayRegionDelegate>((*env)->GetBooleanArrayRegion);

        public void GetBooleanArrayRegion(JBooleanArray array, JSize start, JSize length, Span<JBoolean> buffer)
        {
            fixed (JBoolean* _buffer_ptr = buffer)
            {
                _GetBooleanArrayRegion(env, array, (int)start, (int)length, (byte*)_buffer_ptr);
            }
        }

        delegate void GetByteArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, sbyte* buffer);
        GetByteArrayRegionDelegate? __GetByteArrayRegion;
        GetByteArrayRegionDelegate _GetByteArrayRegion => __GetByteArrayRegion ??= GetDelegateForFunctionPointer<GetByteArrayRegionDelegate>((*env)->GetByteArrayRegion);

        public void GetByteArrayRegion(JByteArray array, JSize start, JSize length, Span<JByte> buffer)
        {
            fixed (JByte* _buffer_ptr = buffer)
            {
                _GetByteArrayRegion(env, array, (int)start, (int)length, (sbyte*)_buffer_ptr);
            }
        }

        delegate void GetCharArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, char* buffer);
        GetCharArrayRegionDelegate? __GetCharArrayRegion;
        GetCharArrayRegionDelegate _GetCharArrayRegion => __GetCharArrayRegion ??= GetDelegateForFunctionPointer<GetCharArrayRegionDelegate>((*env)->GetCharArrayRegion);

        public void GetCharArrayRegion(JCharArray array, JSize start, JSize length, Span<JChar> buffer)
        {
            fixed (JChar* _buffer_ptr = buffer)
            {
                _GetCharArrayRegion(env, array, (int)start, (int)length, (char*)_buffer_ptr);
            }
        }

        delegate void GetShortArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, short* buffer);
        GetShortArrayRegionDelegate? __GetShortArrayRegion;
        GetShortArrayRegionDelegate _GetShortArrayRegion => __GetShortArrayRegion ??= GetDelegateForFunctionPointer<GetShortArrayRegionDelegate>((*env)->GetShortArrayRegion);

        public void GetShortArrayRegion(JShortArray array, JSize start, JSize length, Span<JShort> buffer)
        {
            fixed (JShort* _buffer_ptr = buffer)
            {
                _GetShortArrayRegion(env, array, (int)start, (int)length, (short*)_buffer_ptr);
            }
        }

        delegate void GetIntArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, int* buffer);
        GetIntArrayRegionDelegate? __GetIntArrayRegion;
        GetIntArrayRegionDelegate _GetIntArrayRegion => __GetIntArrayRegion ??= GetDelegateForFunctionPointer<GetIntArrayRegionDelegate>((*env)->GetIntArrayRegion);

        public void GetIntArrayRegion(JIntArray array, JSize start, JSize length, Span<JInt> buffer)
        {
            fixed (JInt* _buffer_ptr = buffer)
            {
                _GetIntArrayRegion(env, array, (int)start, (int)length, (int*)_buffer_ptr);
            }
        }

        delegate void GetLongArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, long* buffer);
        GetLongArrayRegionDelegate? __GetLongArrayRegion;
        GetLongArrayRegionDelegate _GetLongArrayRegion => __GetLongArrayRegion ??= GetDelegateForFunctionPointer<GetLongArrayRegionDelegate>((*env)->GetLongArrayRegion);

        public void GetLongArrayRegion(JLongArray array, JSize start, JSize length, Span<JLong> buffer)
        {
            fixed (JLong* _buffer_ptr = buffer)
            {
                _GetLongArrayRegion(env, array, (int)start, (int)length, (long*)_buffer_ptr);
            }
        }

        delegate void GetFloatArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, float* buffer);
        GetFloatArrayRegionDelegate? __GetFloatArrayRegion;
        GetFloatArrayRegionDelegate _GetFloatArrayRegion => __GetFloatArrayRegion ??= GetDelegateForFunctionPointer<GetFloatArrayRegionDelegate>((*env)->GetFloatArrayRegion);

        public void GetFloatArrayRegion(JLongArray array, JSize start, JSize length, Span<JFloat> buffer)
        {
            fixed (JFloat* _buffer_ptr = buffer)
            {
                _GetFloatArrayRegion(env, array, (int)start, (int)length, (float*)_buffer_ptr);
            }
        }

        delegate void GetDoubleArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, double* buffer);
        GetDoubleArrayRegionDelegate? __GetDoubleArrayRegion;
        GetDoubleArrayRegionDelegate _GetDoubleArrayRegion => __GetDoubleArrayRegion ??= GetDelegateForFunctionPointer<GetDoubleArrayRegionDelegate>((*env)->GetDoubleArrayRegion);

        public void GetDoubleArrayRegion(JDoubleArray array, JSize start, JSize length, Span<JDouble> buffer)
        {
            fixed (JDouble* _buffer_ptr = buffer)
            {
                _GetDoubleArrayRegion(env, array, (int)start, (int)length, (double*)_buffer_ptr);
            }
        }

        delegate void SetBooleanArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, byte* buffer);
        SetBooleanArrayRegionDelegate? __SetBooleanArrayRegion;
        SetBooleanArrayRegionDelegate _SetBooleanArrayRegion => __SetBooleanArrayRegion ??= GetDelegateForFunctionPointer<SetBooleanArrayRegionDelegate>((*env)->SetBooleanArrayRegion);

        public void SetBooleanArrayRegion(JBooleanArray array, JSize start, JSize length, ReadOnlySpan<JBoolean> buffer)
        {
            fixed (JBoolean* _buffer_ptr = buffer)
            {
                _SetBooleanArrayRegion(env, array, (int)start, (int)length, (byte*)_buffer_ptr);
            }
        }

        delegate void SetByteArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, sbyte* buffer);
        SetByteArrayRegionDelegate? __SetByteArrayRegion;
        SetByteArrayRegionDelegate _SetByteArrayRegion => __SetByteArrayRegion ??= GetDelegateForFunctionPointer<SetByteArrayRegionDelegate>((*env)->SetByteArrayRegion);

        public void SetByteArrayRegion(JByteArray array, JSize start, JSize length, ReadOnlySpan<JByte> buffer)
        {
            fixed (JByte* _buffer_ptr = buffer)
            {
                _SetByteArrayRegion(env, array, (int)start, (int)length, (sbyte*)_buffer_ptr);
            }
        }

        delegate void SetCharArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, char* buffer);
        SetCharArrayRegionDelegate? __SetCharArrayRegion;
        SetCharArrayRegionDelegate _SetCharArrayRegion => __SetCharArrayRegion ??= GetDelegateForFunctionPointer<SetCharArrayRegionDelegate>((*env)->SetCharArrayRegion);

        public void SetCharArrayRegion(JCharArray array, JSize start, JSize length, ReadOnlySpan<JChar> buffer)
        {
            fixed (JChar* _buffer_ptr = buffer)
            {
                _SetCharArrayRegion(env, array, (int)start, (int)length, (char*)_buffer_ptr);
            }
        }

        delegate void SetShortArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, short* buffer);
        SetShortArrayRegionDelegate? __SetShortArrayRegion;
        SetShortArrayRegionDelegate _SetShortArrayRegion => __SetShortArrayRegion ??= GetDelegateForFunctionPointer<SetShortArrayRegionDelegate>((*env)->SetShortArrayRegion);

        public void SetShortArrayRegion(JShortArray array, JSize start, JSize length, ReadOnlySpan<JShort> buffer)
        {
            fixed (JShort* _buffer_ptr = buffer)
            {
                _SetShortArrayRegion(env, array, (int)start, (int)length, (short*)_buffer_ptr);
            }
        }

        delegate void SetIntArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, int* buffer);
        SetIntArrayRegionDelegate? __SetIntArrayRegion;
        SetIntArrayRegionDelegate _SetIntArrayRegion => __SetIntArrayRegion ??= GetDelegateForFunctionPointer<SetIntArrayRegionDelegate>((*env)->SetIntArrayRegion);

        public void SetIntArrayRegion(JIntArray array, JSize start, JSize length, ReadOnlySpan<JInt> buffer)
        {
            fixed (JInt* _buffer_ptr = buffer)
            {
                _SetIntArrayRegion(env, array, (int)start, (int)length, (int*)_buffer_ptr);
            }
        }

        delegate void SetLongArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, long* buffer);
        SetLongArrayRegionDelegate? __SetLongArrayRegion;
        SetLongArrayRegionDelegate _SetLongArrayRegion => __SetLongArrayRegion ??= GetDelegateForFunctionPointer<SetLongArrayRegionDelegate>((*env)->SetLongArrayRegion);

        public void SetLongArrayRegion(JLongArray array, JSize start, JSize length, ReadOnlySpan<JLong> buffer)
        {
            fixed (JLong* _buffer_ptr = buffer)
            {
                _SetLongArrayRegion(env, array, (int)start, (int)length, (long*)_buffer_ptr);
            }
        }

        delegate void SetFloatArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, float* buffer);
        SetFloatArrayRegionDelegate? __SetFloatArrayRegion;
        SetFloatArrayRegionDelegate _SetFloatArrayRegion => __SetFloatArrayRegion ??= GetDelegateForFunctionPointer<SetFloatArrayRegionDelegate>((*env)->SetFloatArrayRegion);

        public void SetFloatArrayRegion(JFloatArray array, JSize start, JSize length, ReadOnlySpan<JFloat> buffer)
        {
            fixed (JFloat* _buffer_ptr = buffer)
            {
                _SetFloatArrayRegion(env, array, (int)start, (int)length, (float*)_buffer_ptr);
            }
        }

        delegate void SetDoubleArrayRegionDelegate(JniNativeInterface** env, IntPtr array, int start, int length, double* buffer);
        SetDoubleArrayRegionDelegate? __SetDoubleArrayRegion;
        SetDoubleArrayRegionDelegate _SetDoubleArrayRegion => __SetDoubleArrayRegion ??= GetDelegateForFunctionPointer<SetDoubleArrayRegionDelegate>((*env)->SetDoubleArrayRegion);

        public void SetDoubleArrayRegion(JDoubleArray array, JSize start, JSize length, ReadOnlySpan<JDouble> buffer)
        {
            fixed (JDouble* _buffer_ptr = buffer)
            {
                _SetDoubleArrayRegion(env, array, (int)start, (int)length, (double*)_buffer_ptr);
            }
        }

        delegate int RegisterNativesDelegate(JniNativeInterface** env, IntPtr type, JniNativeMethod* methods, int numMethods);
        RegisterNativesDelegate? __RegisterNatives;
        RegisterNativesDelegate _RegisterNatives => __RegisterNatives ??= GetDelegateForFunctionPointer<RegisterNativesDelegate>((*env)->RegisterNatives);

        public JInt RegisterNatives(JClass type, JPointer<JniNativeMethod> methods, JInt numMethods)
        {
            JInt @return;
            @return = (JInt)_RegisterNatives(env, type, methods, (int)numMethods);
            return @return;
        }

        delegate int UnregisterNativesDelegate(JniNativeInterface** env, IntPtr type);
        UnregisterNativesDelegate? __UnregisterNatives;
        UnregisterNativesDelegate _UnregisterNatives => __UnregisterNatives ??= GetDelegateForFunctionPointer<UnregisterNativesDelegate>((*env)->UnregisterNatives);

        public JInt UnregisterNatives(JClass type)
        {
            JInt @return;
            @return = (JInt)_UnregisterNatives(env, type);
            return @return;
        }

        delegate int MonitorEnterDelegate(JniNativeInterface** env, IntPtr instance);
        MonitorEnterDelegate? __MonitorEnter;
        MonitorEnterDelegate _MonitorEnter => __MonitorEnter ??= GetDelegateForFunctionPointer<MonitorEnterDelegate>((*env)->MonitorEnter);

        public JInt MonitorEnter(JObject instance)
        {
            JInt @return;
            @return = (JInt)_MonitorEnter(env, instance);
            return @return;
        }

        delegate int MonitorExitDelegate(JniNativeInterface** env, IntPtr instance);
        MonitorExitDelegate? __MonitorExit;
        MonitorExitDelegate _MonitorExit => __MonitorExit ??= GetDelegateForFunctionPointer<MonitorExitDelegate>((*env)->MonitorExit);

        public JInt MonitorExit(JObject instance)
        {
            JInt @return;
            @return = (JInt)_MonitorExit(env, instance);
            return @return;
        }

        delegate int GetJavaVMDelegate(JniNativeInterface** env, out JniInvokeInterface* vm);
        GetJavaVMDelegate? __GetJavaVM;
        GetJavaVMDelegate _GetJavaVM => __GetJavaVM ??= GetDelegateForFunctionPointer<GetJavaVMDelegate>((*env)->GetJavaVM);

        public JInt GetJavaVM(out JniInvokeInterface* vm)
        {
            JInt @return;
            @return = (JInt)_GetJavaVM(env, out var _vm);
            vm = _vm;
            return @return;
        }

        delegate void GetStringRegionDelegate(JniNativeInterface** env, IntPtr stringInstance, int start, int length, char* buffer);
        GetStringRegionDelegate? __GetStringRegion;
        GetStringRegionDelegate _GetStringRegion => __GetStringRegion ??= GetDelegateForFunctionPointer<GetStringRegionDelegate>((*env)->GetStringRegion);

        public void GetStringRegion(JString stringInstance, JSize start, JSize length, Span<JChar> buffer)
        {
            fixed (JChar* _buffer_ptr = buffer)
            {
                _GetStringRegion(env, stringInstance, (int)start, (int)length, (char*)_buffer_ptr);
            }
        }

        delegate void GetStringUTFRegionDelegate(JniNativeInterface** env, IntPtr stringInstance, int start, int length, byte* buffer);
        GetStringUTFRegionDelegate? __GetStringUTFRegion;
        GetStringUTFRegionDelegate _GetStringUTFRegion => __GetStringUTFRegion ??= GetDelegateForFunctionPointer<GetStringUTFRegionDelegate>((*env)->GetStringUTFRegion);

        public void GetStringUTFRegion(JString stringInstance, JSize start, JSize length, ReadOnlySpan<byte> buffer)
        {
            fixed (byte* _buffer_ptr = buffer)
            {
                _GetStringUTFRegion(env, stringInstance, (int)start, (int)length, (byte*)_buffer_ptr);
            }
        }

        delegate void* GetPrimitiveArrayCriticalDelegate(JniNativeInterface** env, IntPtr array, out byte isCopy);
        GetPrimitiveArrayCriticalDelegate? __GetPrimitiveArrayCritical;
        GetPrimitiveArrayCriticalDelegate _GetPrimitiveArrayCritical => __GetPrimitiveArrayCritical ??= GetDelegateForFunctionPointer<GetPrimitiveArrayCriticalDelegate>((*env)->GetPrimitiveArrayCritical);

        public JPointer<JVoid> GetPrimitiveArrayCritical(JArray array, out JBoolean isCopy)
        {
            JPointer<JVoid> @return;
            @return = (JPointer<JVoid>)(JVoid*)_GetPrimitiveArrayCritical(env, array, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate void ReleasePrimitiveArrayCriticalDelegate(JniNativeInterface** env, IntPtr array, void* carray, int mode);
        ReleasePrimitiveArrayCriticalDelegate? __ReleasePrimitiveArrayCritical;
        ReleasePrimitiveArrayCriticalDelegate _ReleasePrimitiveArrayCritical => __ReleasePrimitiveArrayCritical ??= GetDelegateForFunctionPointer<ReleasePrimitiveArrayCriticalDelegate>((*env)->ReleasePrimitiveArrayCritical);

        public void ReleasePrimitiveArrayCritical(JArray array, ReadOnlySpan<JVoid> carray, JniReleaseArrayElementsMode mode)
        {
            fixed (JVoid* _carray_ptr = carray)
            {
                _ReleasePrimitiveArrayCritical(env, array, (void*)_carray_ptr, (int)mode);
            }
        }

        delegate char* GetStringCriticalDelegate(JniNativeInterface** env, IntPtr stringInstance, out byte isCopy);
        GetStringCriticalDelegate? __GetStringCritical;
        GetStringCriticalDelegate _GetStringCritical => __GetStringCritical ??= GetDelegateForFunctionPointer<GetStringCriticalDelegate>((*env)->GetStringCritical);

        public JPointer<JChar> GetStringCritical(JString stringInstance, out JBoolean isCopy)
        {
            JPointer<JChar> @return;
            @return = (JPointer<JChar>)(JChar*)_GetStringCritical(env, stringInstance, out var _isCopy);
            isCopy = _isCopy;
            return @return;
        }

        delegate void ReleaseStringCriticalDelegate(JniNativeInterface** env, IntPtr stringInstance, char* carray);
        ReleaseStringCriticalDelegate? __ReleaseStringCritical;
        ReleaseStringCriticalDelegate _ReleaseStringCritical => __ReleaseStringCritical ??= GetDelegateForFunctionPointer<ReleaseStringCriticalDelegate>((*env)->ReleaseStringCritical);

        public void ReleaseStringCritical(JString stringInstance, ReadOnlySpan<JChar> carray)
        {
            fixed (JChar* _carray_ptr = carray)
            {
                _ReleaseStringCritical(env, stringInstance, (char*)_carray_ptr);
            }
        }

        delegate IntPtr NewWeakGlobalRefDelegate(JniNativeInterface** env, IntPtr instance);
        NewWeakGlobalRefDelegate? __NewWeakGlobalRef;
        NewWeakGlobalRefDelegate _NewWeakGlobalRef => __NewWeakGlobalRef ??= GetDelegateForFunctionPointer<NewWeakGlobalRefDelegate>((*env)->NewWeakGlobalRef);

        public JWeak NewWeakGlobalRef(JObject instance)
        {
            JWeak @return;
            @return = _NewWeakGlobalRef(env, instance);
            return @return;
        }

        delegate void DeleteWeakGlobalRefDelegate(JniNativeInterface** env, IntPtr instance);
        DeleteWeakGlobalRefDelegate? __DeleteWeakGlobalRef;
        DeleteWeakGlobalRefDelegate _DeleteWeakGlobalRef => __DeleteWeakGlobalRef ??= GetDelegateForFunctionPointer<DeleteWeakGlobalRefDelegate>((*env)->DeleteWeakGlobalRef);

        public void DeleteWeakGlobalRef(JWeak instance)
        {
            _DeleteWeakGlobalRef(env, instance);
        }

        delegate byte ExceptionCheckDelegate(JniNativeInterface** env);
        ExceptionCheckDelegate? __ExceptionCheck;
        ExceptionCheckDelegate _ExceptionCheck => __ExceptionCheck ??= GetDelegateForFunctionPointer<ExceptionCheckDelegate>((*env)->ExceptionCheck);

        public JBoolean ExceptionCheck()
        {
            JBoolean @return;
            @return = (JBoolean)_ExceptionCheck(env);
            return @return;
        }

        delegate IntPtr NewDirectByteBufferDelegate(JniNativeInterface** env, void* address, long capacity);
        NewDirectByteBufferDelegate? __NewDirectByteBuffer;
        NewDirectByteBufferDelegate _NewDirectByteBuffer => __NewDirectByteBuffer ??= GetDelegateForFunctionPointer<NewDirectByteBufferDelegate>((*env)->NewDirectByteBuffer);

        public JObject NewDirectByteBuffer(JPointer<JVoid> address, JLong capacity)
        {
            JObject @return;
            @return = _NewDirectByteBuffer(env, address, (long)capacity);
            return @return;
        }

        delegate void* GetDirectBufferAddressDelegate(JniNativeInterface** env, IntPtr buffer);
        GetDirectBufferAddressDelegate? __GetDirectBufferAddress;
        GetDirectBufferAddressDelegate _GetDirectBufferAddress => __GetDirectBufferAddress ??= GetDelegateForFunctionPointer<GetDirectBufferAddressDelegate>((*env)->GetDirectBufferAddress);

        public JPointer<JVoid> GetDirectBufferAddress(JObject buffer)
        {
            JPointer<JVoid> @return;
            @return = (JPointer<JVoid>)(JVoid*)_GetDirectBufferAddress(env, buffer);
            return @return;
        }

        delegate long GetDirectBufferCapacityDelegate(JniNativeInterface** env, IntPtr buffer);
        GetDirectBufferCapacityDelegate? __GetDirectBufferCapacity;
        GetDirectBufferCapacityDelegate _GetDirectBufferCapacity => __GetDirectBufferCapacity ??= GetDelegateForFunctionPointer<GetDirectBufferCapacityDelegate>((*env)->GetDirectBufferCapacity);

        public JLong GetDirectBufferCapacity(JObject buffer)
        {
            JLong @return;
            @return = (JLong)_GetDirectBufferCapacity(env, buffer);
            return @return;
        }

        delegate JObjectRefType GetObjectRefTypeDelegate(JniNativeInterface** env, IntPtr instance);
        GetObjectRefTypeDelegate? __GetObjectRefType;
        GetObjectRefTypeDelegate _GetObjectRefType => __GetObjectRefType ??= GetDelegateForFunctionPointer<GetObjectRefTypeDelegate>((*env)->GetObjectRefType);

        public JObjectRefType GetObjectRefType(JObject instance)
        {
            JObjectRefType @return;
            @return = (JObjectRefType)_GetObjectRefType(env, instance);
            return @return;
        }

    }

}

