using System;

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
        public void Can_call_void_static_method_with_int_arg()
        {
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();
            var bld = new ProxyMethodBuilder(jre);
            var del = (Action<int>)bld.BuildCallStaticMethodDelegate(IntPtr.Zero, IntPtr.Zero, "(I)V");
            // TODO
        }

    }

}
