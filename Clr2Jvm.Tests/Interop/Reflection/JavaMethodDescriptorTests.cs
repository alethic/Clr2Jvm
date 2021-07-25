using Clr2Jvm.Interop.Reflection;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests.Interop.Reflection
{

    [TestClass]
    public class JavaMethodDescriptorTests
    {

        [TestMethod]
        public void Can_parse_int_arg_with_void_return()
        {
            var s = JavaMethodDescriptor.Parse("(I)V");
            s.ToString().Should().Be("(I)V");

            s.Return.Type.Should().Be(JavaDescriptorType.Void);
            s.Return.ArrayRank.Should().Be(0);
            s.Return.Class.Should().BeNull();

            s.Parameters.Should().HaveCount(1);
            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Int);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_int_arg_with_object_return()
        {
            var s = JavaMethodDescriptor.Parse("(I)Ljava/lang/String;");
            s.ToString().Should().Be("(I)Ljava/lang/String;");

            s.Return.Type.Should().Be(JavaDescriptorType.Object);
            s.Return.ArrayRank.Should().Be(0);
            s.Return.Class.Should().Be("java.lang.String");

            s.Parameters.Should().HaveCount(1);
            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Int);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_int_and_bool_arg_with_object_return()
        {
            var s = JavaMethodDescriptor.Parse("(IZ)Ljava/lang/String;");
            s.ToString().Should().Be("(IZ)Ljava/lang/String;");

            s.Return.Type.Should().Be(JavaDescriptorType.Object);
            s.Return.ArrayRank.Should().Be(0);
            s.Return.Class.Should().Be("java.lang.String");

            s.Parameters.Should().HaveCount(2);

            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Int);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().BeNull();

            s.Parameters[1].Type.Should().Be(JavaDescriptorType.Boolean);
            s.Parameters[1].ArrayRank.Should().Be(0);
            s.Parameters[1].Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_int_and_bool_array_arg_with_object_return()
        {
            var s = JavaMethodDescriptor.Parse("(I[Z)Ljava/lang/String;");
            s.ToString().Should().Be("(I[Z)Ljava/lang/String;");

            s.Return.Type.Should().Be(JavaDescriptorType.Object);
            s.Return.ArrayRank.Should().Be(0);
            s.Return.Class.Should().Be("java.lang.String");

            s.Parameters.Should().HaveCount(2);

            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Int);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().BeNull();

            s.Parameters[1].Type.Should().Be(JavaDescriptorType.Boolean);
            s.Parameters[1].ArrayRank.Should().Be(1);
            s.Parameters[1].Class.Should().BeNull();
        }

        [TestMethod]
        public void Can_parse_int_and_bool_array_arg_with_object_array_return()
        {
            var s = JavaMethodDescriptor.Parse("(I[Z)[Ljava/lang/String;");
            s.ToString().Should().Be("(I[Z)[Ljava/lang/String;");

            s.Return.Type.Should().Be(JavaDescriptorType.Object);
            s.Return.ArrayRank.Should().Be(1);
            s.Return.Class.Should().Be("java.lang.String");

            s.Parameters.Should().HaveCount(2);

            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Int);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().BeNull();

            s.Parameters[1].Type.Should().Be(JavaDescriptorType.Boolean);
            s.Parameters[1].ArrayRank.Should().Be(1);
            s.Parameters[1].Class.Should().BeNull();
        }
        
        [TestMethod]
        public void Can_parse_two_object_params_with_object_result()
        {
            var s = JavaMethodDescriptor.Parse("(Ljava/lang/String;[Ljava/lang/Class;)[Ljava/lang/reflect/Method;");
            s.ToString().Should().Be("(Ljava/lang/String;[Ljava/lang/Class;)[Ljava/lang/reflect/Method;");

            s.Return.Type.Should().Be(JavaDescriptorType.Object);
            s.Return.ArrayRank.Should().Be(1);
            s.Return.Class.Should().Be("java.lang.reflect.Method");

            s.Parameters.Should().HaveCount(2);

            s.Parameters[0].Type.Should().Be(JavaDescriptorType.Object);
            s.Parameters[0].ArrayRank.Should().Be(0);
            s.Parameters[0].Class.Should().Be("java.lang.String");

            s.Parameters[1].Type.Should().Be(JavaDescriptorType.Object);
            s.Parameters[1].ArrayRank.Should().Be(1);
            s.Parameters[1].Class.Should().Be("java.lang.Class");
        }

    }

}
