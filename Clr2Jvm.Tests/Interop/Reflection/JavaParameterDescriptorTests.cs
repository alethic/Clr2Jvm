using Clr2Jvm.Interop.Reflection;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests.Interop.Reflection
{

    [TestClass]
    public class JavaParameterDescriptorTests
    {

        [TestMethod]
        public void Can_parse_boolean()
        {
            var s = JavaParameterDescriptor.Parse("Z");
            s.Type.Should().Be(JavaDescriptorType.Boolean);
            s.ArrayRank.Should().Be(0);
            s.Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_object()
        {
            var s = JavaParameterDescriptor.Parse("Ljava/lang/String");
            s.Type.Should().Be(JavaDescriptorType.Object);
            s.ArrayRank.Should().Be(0);
            s.Class.Should().Be("java.lang.String");
        }

        [TestMethod]
        public void Can_parse_boolean_array()
        {
            var s = JavaParameterDescriptor.Parse("[Z");
            s.Type.Should().Be(JavaDescriptorType.Boolean);
            s.ArrayRank.Should().Be(1);
            s.Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_object_array()
        {
            var s = JavaParameterDescriptor.Parse("[Ljava/lang/String");
            s.Type.Should().Be(JavaDescriptorType.Object);
            s.ArrayRank.Should().Be(1);
            s.Class.Should().Be("java.lang.String");
        }

    }

}
