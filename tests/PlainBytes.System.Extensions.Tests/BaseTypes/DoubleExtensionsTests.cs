using System;
using System.Linq;
using PlainBytes.System.Extensions.BaseTypes;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.BaseTypes
{
    public class DoubleExtensionsTests
    {
        [Fact]
        public void Doubles_ToBytes_RoundTrip()
        {
            // Arrange
            var expectedResult = Enumerable.Range(0, 100).Select(_ => Random.Shared.NextDouble()).ToArray();

            // Act
            var bytes = expectedResult.GetBytes();
            var result = bytes.ToDoubleArray();

            // Assert
            Assert.True(expectedResult.SequenceEqual(result));
        }
    }
}
