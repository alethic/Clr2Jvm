using Clr2Jvm.Interop.Reflection;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests.Interop.Reflection
{

    [TestClass]
    public class JavaClassDescriptorTests
    {

        [TestMethod]
        public void Can_parse_string()
        {
            var s = JavaClassDescriptor.Parse("java/lang/String");
            s.ArrayRank.Should().Be(0);
            s.TypeName.Should().Be("java.lang.String");
            s.ToString().Should().Be("java/lang/String");
        }

        [TestMethod]
        public void Can_parse_string_array()
        {
            var s = JavaClassDescriptor.Parse("[Ljava/lang/String;");
            s.ArrayRank.Should().Be(1);
            s.TypeName.Should().Be("java.lang.String");
            s.ToString().Should().Be("[Ljava/lang/String;");
        }

        [TestMethod]
        public void Can_parse_string_array_array()
        {
            var s = JavaClassDescriptor.Parse("[[Ljava/lang/String;");
            s.ArrayRank.Should().Be(2);
            s.TypeName.Should().Be("java.lang.String");
        }

    }

}
