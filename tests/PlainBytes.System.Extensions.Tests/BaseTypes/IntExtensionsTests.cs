using System.IO;
using Xunit;
using PlainBytes.System.Extensions.BaseTypes;

namespace PlainBytes.System.Extensions.Tests.BaseTypes
{
    public class IntExtensionsTests
    {
        [Fact]
        public void GetBytes_And_ToIntArray_RoundTrip()
        {
            // Arrange
            var expected = new[] { 1, 2, 3, 4, 5 };

            // Act
            var bytes = expected.GetBytes();
            var result = bytes.ToIntArray();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToIntArray_InvalidLength_Throws()
        {
            var bytes = new byte[5]; // Not a multiple of 4
            Assert.Throws<InvalidDataException>(() => bytes.ToIntArray());
        }
    }
}
