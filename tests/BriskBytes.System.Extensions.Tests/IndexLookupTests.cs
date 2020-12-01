using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlainBytes.System.Extensions.Tests
{
    [TestClass]
    public class IndexLookupTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void HasIndex_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Act          
            collection.HasIndex(1);
        }

        [TestMethod]
        public void HasIndex_GivenNegativeIndex_ReturnFalse()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(-5);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasIndex_GivenOutOfBoundValue_ReturnFalse()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(collection.Length + 1);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrDefault_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Act          
            var _ = collection.AtIndexOrDefault(2);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrDefaultValueType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Length + 1);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AtIndexOrDefaultReferenceType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            var collection = new[] { new object(), new object(), new object(), new object() };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Length + 1);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrFallback_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            int[] collection = null;

            // Act          
            var _ = collection.AtIndexOrFallback(2, 0);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrFallback_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            var collection = new[] { 1, 2, 1, 3 };
            const int expectedValue = int.MaxValue;

            // Act          
            var result = collection.AtIndexOrFallback(collection.Length - 1, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
