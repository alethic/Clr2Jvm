using Clr2Jvm.Interop;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests
{

    [TestClass]
    public class JavaRuntimeTests
    {

        [TestMethod]
        public void Run()
        {
            JavaInstall.DefaultJvmLibName = @"C:\Program Files\Java\jdk-16.0.1\bin\server\jvm.dll";
            JavaInstall.DefaultOptions.Options.Add("-Xmx1024m");
            JavaInstall.DefaultOptions.Options.Add("-XX:MaxPermSize=512m");
            var jre = JavaInstall.Default.Runtime;
            jre.Should().NotBeNull();

            var env = jre.Environment;
            env.Should().NotBeNull();

            var classLoaderCls = env.FindClass("java/lang/ClassLoader");
        }

    }

}
