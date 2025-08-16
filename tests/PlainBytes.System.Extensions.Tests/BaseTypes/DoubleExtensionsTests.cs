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

        [Fact]
        public void IsEqual_WithNaN_ReturnsTrue()
        {
            // Arrange
            double a = double.NaN;
            double b = double.NaN;

            // Act
            var result = a.IsEqual(b);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEqual_WithTolerance_Works()
        {
            // Arrange
            double a = 1.0001;
            double b = 1.0002;
            double tolerance = 0.001;

            // Act
            var result = a.IsEqual(b, tolerance);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEqual_WithoutTolerance_FalseForDifferent()
        {
            // Arrange
            double a = 1.0;
            double b = 2.0;

            // Act
            var result = a.IsEqual(b);

            // Assert
            Assert.False(result);
        }
    }
}
