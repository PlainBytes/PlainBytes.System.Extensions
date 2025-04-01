using System;
using System.Linq;
using PlainBytes.System.Extensions.BaseTypes;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.BaseTypes
{
    public class IntegerExtensionsTests
    {
        [Fact]
        public void Integers_ToBytes_RoundTrip()
        {
            // Arrange
            var expectedResult = Enumerable.Range(0, 100).Select(_ => Random.Shared.Next()).ToArray();

            // Act
            var bytes = expectedResult.GetBytes();
            var result = bytes.ToIntArray();

            // Assert
            Assert.True(expectedResult.SequenceEqual(result));
        }
    }
}
