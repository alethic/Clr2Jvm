
using Clr2Jvm.Interop.Text;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clr2Jvm.Tests.Interop.Text
{

    [TestClass]
    public class JavaUtf8StringMarshallerTests
    {

        [TestMethod]
        public void Can_marshal_string()
        {
            using var s = JavaUtf8StringReader.Default.Read("a");
            s.Span.Length.Should().Be(2);
        }

    }

}
