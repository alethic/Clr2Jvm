using System;

using Clr2Jvm.Interop.Native;
using Clr2Jvm.Interop.Proxies;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests.Interop.Proxies
{

    [TestClass]
    public class ProxyMethodBuilderTests
    {

        static ProxyMethodBuilderTests()
        {
            JavaInstall.DefaultJvmLibName = @"C:\Program Files\Java\jdk-16.0.1\bin\server\jvm.dll";
        }

        [TestMethod]
        public void Can_call_int_static_method_with_int_arg()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetStaticMethodID(clazz, "bitCount", "(I)I");
            var builder = new ProxyMethodBuilder(jre);
            var bitCount = (Func<int, int>)builder.BuildCallStaticMethodDelegate(clazz, method, "(I)I");
            bitCount(1).Should().Be(1);
            bitCount(2).Should().Be(1);
            bitCount(3).Should().Be(2);
        }

        [TestMethod]
        public void Can_call_int_static_method_with_two_int_args()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetStaticMethodID(clazz, "compare", "(II)I");
            var builder = new ProxyMethodBuilder(jre);
            var compare = (Func<int, int, int>)builder.BuildCallStaticMethodDelegate(clazz, method, "(II)I");
            compare(1, 1).Should().Be(0);
            compare(0, 1).Should().Be(-1);
            compare(1, 0).Should().Be(1);
        }

        [TestMethod]
        public void Can_call_int_static_method_with_string_arg()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetStaticMethodID(clazz, "parseInt", "(Ljava/lang/String;)I");
            var builder = new ProxyMethodBuilder(jre);
            var parseInt = (Func<string, int>)builder.BuildCallStaticMethodDelegate(clazz, method, "(Ljava/lang/String;)I");
            parseInt("1").Should().Be(1);
            parseInt("666").Should().Be(666);
        }

        [TestMethod]
        public void Can_call_string_static_method_with_int_arg()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetStaticMethodID(clazz, "toString", "(I)Ljava/lang/String;");
            var builder = new ProxyMethodBuilder(jre);
            var toString = (Func<int, string>)builder.BuildCallStaticMethodDelegate(clazz, method, "(I)Ljava/lang/String;");
            toString(1).Should().Be("1");
            toString(666).Should().Be("666");
        }

        [TestMethod]
        public void Can_call_string_static_method_with_two_int_args()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetStaticMethodID(clazz, "toString", "(II)Ljava/lang/String;");
            var builder = new ProxyMethodBuilder(jre);
            var toString = (Func<int, int, string>)builder.BuildCallStaticMethodDelegate(clazz, method, "(II)Ljava/lang/String;");
            toString(1, 10).Should().Be("1");
            toString(666, 10).Should().Be("666");
        }

        [TestMethod]
        public void Can_call_int_method()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("java/lang/Integer");
            var method = jre.Environment.GetMethodID(clazz, "intValue", "()I");
            var builder = new ProxyMethodBuilder(jre);
            var intValue = (Func<JObject, int>)builder.BuildCallMethodDelegate(clazz, method, "()I");
            var instance = jre.Environment.NewObject(clazz, "(I)V", (JInt)1);
            intValue(instance).Should().Be(1);
        }

        [TestMethod]
        public void Can_call_static_string_array_method()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var clazz = jre.Environment.FindClass("com/sun/tools/javac/Main");
            var method = jre.Environment.GetStaticMethodID(clazz, "compile", "([Ljava/lang/String;)I");
            var builder = new ProxyMethodBuilder(jre);
            var compile = (Func<string[], int>)builder.BuildCallStaticMethodDelegate(clazz, method, "([Ljava/lang/String;)I");
            compile(new string[1] { "test" }).Should().Be(1);
        }

    }

}
