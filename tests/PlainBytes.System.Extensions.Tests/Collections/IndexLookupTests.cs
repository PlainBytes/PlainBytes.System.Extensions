using System;
using System.Collections.Generic;
using PlainBytes.System.Extensions.Collections;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.Collections
{

    public class IndexLookupTests
    {
        [Fact]
        public void HasIndex_GivenNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            int[] collection = null;

            // Act
            Assert.Throws<ArgumentNullException>(() => collection.HasIndex(1));
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
        public void AtIndexOrDefault_GivenNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            int[] collection = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => collection.AtIndexOrDefault(2));
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
        public void AtIndexOrFallback_GivenNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            int[] collection = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => collection.AtIndexOrFallback(2, 0));
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

        [Fact]
        public void IndexOf_Value_GivenNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            int[] collection = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => IndexLookup.IndexOf(collection, 1));
        }

        [Fact]
        public void IndexOf_Value_GivenArray_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = IndexLookup.IndexOf(collection,3);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Value_GivenList_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new List<int> { 10, 20, 30, 40 };

            // Act
            var result = IndexLookup.IndexOf(collection,30);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Value_GivenEnumerable_ReturnsCorrectIndex()
        {
            // Arrange
            IEnumerable<string> collection = new HashSet<string> { "apple", "banana", "cherry" };

            // Act
            var result = IndexLookup.IndexOf(collection,"banana");

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void IndexOf_Value_GivenValueNotFound_ReturnsMinusOne()
        {
            // Arrange
            var collection = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = IndexLookup.IndexOf(collection,10);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_Value_GivenEmptyCollection_ReturnsMinusOne()
        {
            // Arrange
            var collection = Array.Empty<int>();

            // Act
            var result = IndexLookup.IndexOf(collection,1);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_Value_GivenDuplicateValues_ReturnsFirstOccurrence()
        {
            // Arrange
            var collection = new[] { 1, 2, 3, 2, 5 };

            // Act
            var result = IndexLookup.IndexOf(collection,2);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void IndexOf_Value_GivenNullValue_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new[] { "a", null, "c" };

            // Act
            var result = IndexLookup.IndexOf(collection, null);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenNullCollection_ThrowsArgumentNullException()
        {
            // Arrange
            int[] collection = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => collection.IndexOfMatch(x => x > 5));
        }

        [Fact]
        public void IndexOf_Predicate_GivenMatchingItem_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = collection.IndexOfMatch(x => x > 3);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenNoMatch_ReturnsMinusOne()
        {
            // Arrange
            var collection = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = collection.IndexOfMatch(x => x > 10);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenEmptyCollection_ReturnsMinusOne()
        {
            // Arrange
            var collection = Array.Empty<int>();

            // Act
            var result = collection.IndexOfMatch(x => x > 0);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenMultipleMatches_ReturnsFirstMatch()
        {
            // Arrange
            var collection = new[] { 1, 5, 8, 10, 12 };

            // Act
            var result = collection.IndexOfMatch(x => x > 5);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenComplexPredicate_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new[] { "apple", "banana", "cherry", "date" };

            // Act
            var result = collection.IndexOfMatch(x => x.StartsWith("c"));

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenList_ReturnsCorrectIndex()
        {
            // Arrange
            var collection = new List<int> { 10, 20, 30, 40 };

            // Act
            var result = collection.IndexOfMatch(x => x == 30);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Predicate_GivenEnumerable_ReturnsCorrectIndex()
        {
            // Arrange
            IEnumerable<int> collection = new HashSet<int> { 5, 10, 15, 20 };

            // Act
            var result = collection.IndexOfMatch(x => x % 15 == 0);

            // Assert
            Assert.Equal(2, result);
        }
    }
}
