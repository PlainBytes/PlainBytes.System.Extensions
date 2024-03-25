using System;
using System.Collections.Generic;
using PlainBytes.System.Extensions.Collections;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.Collections
{

    public class IndexLookupTests
    {
        [Fact]
        public void HasIndex_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Act
            Assert.Throws<NullReferenceException>(() => collection.HasIndex(1));
        }

        [Fact]
        public void HasIndex_GivenNegativeIndex_ReturnFalse()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(-5);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HasIndex_GivenOutOfBoundValue_ReturnFalse()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(collection.Length);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AtIndexOrDefault_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => collection.AtIndexOrDefault(2));
        }

        [Fact]
        public void AtIndexOrDefaultValueType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.AtIndexOrDefault(collection.Length);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void AtIndexOrDefaultReferenceType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            var collection = new[] { new object(), new object(), new object(), new object() };

            // Act
            var result = collection.AtIndexOrDefault(collection.Length);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AtIndexOrFallback_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => collection.AtIndexOrFallback(2, 0));
        }

        [Fact]
        public void AtIndexOrFallback_GivenInvalidIndex_ReturnFallback()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };
            const int expectedValue = int.MaxValue;

            // Act
            var result = collection.AtIndexOrFallback(collection.Length, expectedValue);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void AtKeyOrFallback_GivenValidKey_ReturnValue()
        {
            // Arrange
            const int expectedValue = 2;
            const int fallback = -1;

            var dictionary = new Dictionary<int, int>
            {
                {1,1},
                {2,expectedValue},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(2, fallback);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void AtKeyOrFallback_GivenValidKey_ReturnFallback()
        {
            // Arrange
            const int expectedValue = -1;

            var dictionary = new Dictionary<int, int>
            {
                {1,1},
                {2,2},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(4, expectedValue);

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
