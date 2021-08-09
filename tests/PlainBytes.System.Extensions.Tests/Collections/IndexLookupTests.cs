using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlainBytes.System.Extensions.Collections;

namespace PlainBytes.System.Extensions.Tests.Collections
{
    [TestClass]
    public class IndexLookupTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void HasIndex_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IList<int> collection = null;

            // Act          
            collection.HasIndex(1);
        }

        [TestMethod]
        public void HasIndex_GivenNegativeIndex_ReturnFalse()
        {
            // Arrange
            IList<int> collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(-5);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasIndex_GivenOutOfBoundValue_ReturnFalse()
        {
            // Arrange
            IList<int> collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(collection.Count);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrDefault_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IList<int> collection = null;

            // Act          
            var _ = collection.AtIndexOrDefault(2);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrDefaultValueType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            IList<int> collection = new[] { 1, 2, 1, 3 };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Count);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AtIndexOrDefaultReferenceType_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            IList<object> collection = new[] { new object(), new object(), new object(), new object() };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Count);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrFallback_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IList<int> collection = null;

            // Act          
            var _ = collection.AtIndexOrFallback(2, 0);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrFallback_GivenInvalidIndex_ReturnFallback()
        {
            // Arrange
            IList<int> collection = new[] { 1, 2, 1, 3 };
            const int expectedValue = int.MaxValue;

            // Act          
            var result = collection.AtIndexOrFallback(collection.Count, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
        
               [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void HasIndex_ReadOnly_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IReadOnlyList<int> collection = null;

            // Act          
            collection.HasIndex(1);
        }

        [TestMethod]
        public void HasIndex_ReadOnly_GivenNegativeIndex_ReturnFalse()
        {
            // Arrange
            IReadOnlyList<int> collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(-5);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasIndex_ReadOnly_GivenOutOfBoundValue_ReturnFalse()
        {
            // Arrange
            IReadOnlyList<int> collection = new[] { 1, 2, 1, 3 };

            // Act
            var result = collection.HasIndex(collection.Count + 1);

            // Assert          
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrDefault_ReadOnly_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IReadOnlyList<int> collection = null;

            // Act          
            var _ = collection.AtIndexOrDefault(2);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrDefaultValueType_ReadOnly_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            IReadOnlyList<int> collection = new[] { 1, 2, 1, 3 };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Count + 1);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AtIndexOrDefaultReferenceType_ReadOnly_GivenInvalidIndex_ReturnDefault()
        {
            // Arrange
            IReadOnlyList<object> collection = new[] { new object(), new object(), new object(), new object() };

            // Act          
            var result = collection.AtIndexOrDefault(collection.Count + 1);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AtIndexOrFallback_ReadOnly_GivenNullCollection_ThrowsNullReferenceException()
        {
            // Arrange
            IReadOnlyList<int> collection = null;

            // Act          
            var _ = collection.AtIndexOrFallback(2, 0);

            // Assert          
        }

        [TestMethod]
        public void AtIndexOrFallback_ReadOnly_GivenInvalidIndex_ReturnFallback()
        {
            // Arrange
            IReadOnlyList<int> collection = new[] { 1, 2, 1, 3 };
            const int expectedValue = int.MaxValue;

            // Act          
            var result = collection.AtIndexOrFallback(collection.Count, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestMethod]
        public void AtKeyOrFallback_ReadOnly_GivenValidKey_ReturnValue()
        {
            // Arrange
            const int expectedValue = 2;
            const int fallback = -1;
            
            var dictionary = (IReadOnlyDictionary<int,int>)new Dictionary<int, int>
            {
                {1,1},
                {2,expectedValue},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(2, fallback);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestMethod]
        public void AtKeyOrFallback_GivenValidKey_ReturnValue()
        {
            // Arrange
            const int expectedValue = 2;
            const int fallback = -1;
            
            var dictionary = (IDictionary<int,int>)new Dictionary<int, int>
            {
                {1,1},
                {2,expectedValue},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(2, fallback);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestMethod]
        public void AtKeyOrFallback_ReadOnly_GivenValidKey_ReturnFallback()
        {
            // Arrange
            const int expectedValue = -1;
            
            var dictionary = (IReadOnlyDictionary<int,int>)new Dictionary<int, int>
            {
                {1,1},
                {2,2},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(4, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
        
        [TestMethod]
        public void AtKeyOrFallback_GivenValidKey_ReturnFallback()
        {
            // Arrange
            const int expectedValue = -1;
            
            var dictionary = (IDictionary<int,int>)new Dictionary<int, int>
            {
                {1,1},
                {2,2},
                {3,3}
            };

            // Act
            var result = dictionary.AtKeyOrFallback(4, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
