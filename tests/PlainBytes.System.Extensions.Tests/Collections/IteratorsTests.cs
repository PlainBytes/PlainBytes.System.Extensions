using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlainBytes.System.Extensions.Collections;

namespace PlainBytes.System.Extensions.Tests.Collections
{
    [TestClass]
    public class IteratorsTests
    {
        private IList<int> _collection;

        [TestInitialize]
        public void Initialize()
        {
            _collection = Enumerable.Range(0, 100).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void For_GivenNullCollection_ShouldThrow()
        {
            // Arrange 
            _collection = null;

            // Act 
            _collection.For((index, element) => { });

            // Assert           
        }

        [TestMethod]
        [DataRow(new []{1,2,3,4,5,6})]
        [DataRow(new []{11,12,13,14,15,16})]
        public void For_GivenAnEnumerable_ActionIsCalledWithTheCorrectIndexAndElement(IEnumerable<int> collection)
        {
            // Arrange 
            var evaluatedCollection = collection.ToList();

            void AssertStatement(int index, int element)
            {
                var expectedIndex = evaluatedCollection.IndexOf(element);

                Assert.AreEqual(expectedIndex, index);
            }

            // Act 
            // Assert
            collection.For(AssertStatement);
        }
        
        [TestMethod]
        [DataRow(new []{1,2,3,4,5,6})]
        [DataRow(new []{11,12,13,14,15,16})]
        public void For_GivenACollection_ActionIsCalledWithTheCorrectIndexAndElement(IList<int> collection)
        {
            // Arrange 
            void AssertStatement(int index, int element)
            {
                var expectedIndex = collection.IndexOf(element);

                Assert.AreEqual(expectedIndex, index);
            }

            // Act 
            // Assert
            collection.For(AssertStatement);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SelectWithIndex_GivenNullCollection_ShouldThrow()
        {
            // Arrange 
            _collection = null;

            // Act 
            var _ = _collection.SelectWithIndex((index, element) => element.ToString()).ToList();

            // Assert           
        }

        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new[] { 11, 12, 13, 14, 15, 16 })]
        public void SelectWithIndex_GivenAList_FunctionIsCalledWithTheCorrectIndexAndElement(IList<int> collection)
        {
            // Arrange 
            int AssertStatement(int index, int element)
            {
                var expectedIndex = collection.IndexOf(element);

                Assert.AreEqual(expectedIndex, index);

                return index;
            }

            // Act 
            // Assert
            var _ = collection.SelectWithIndex(AssertStatement).ToList();
        }

        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new[] { 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void SelectWithIndex_GivenAList_ReturnsAllElements(IList<int> collection)
        {
            // Arrange 
            var evaluatedCollection = collection.ToList();

            // Act 
            var result = evaluatedCollection.SelectWithIndex((i,e)=>i).ToList();
            
            // Assert
            Assert.AreEqual(evaluatedCollection.Count, result.Count);
        }
        
        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new[] { 11, 12, 13, 14, 15, 16 })]
        public void SelectWithIndex_GivenACollection_FunctionIsCalledWithTheCorrectIndexAndElement(IEnumerable<int> collection)
        {
            // Arrange 
            var evaluatedCollection = collection.ToList();

            int AssertStatement(int index, int element)
            {
                var expectedIndex = evaluatedCollection.IndexOf(element);

                Assert.AreEqual(expectedIndex, index);

                return index;
            }

            // Act 
            // Assert
            var _ = collection.SelectWithIndex(AssertStatement).ToList();
        }

        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new[] { 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void SelectWithIndex_GivenACollection_ReturnsAllElements(IEnumerable<int> collection)
        {
            // Arrange 
            var evaluatedCollection = collection.ToList();

            // Act 
            var result = collection.SelectWithIndex((i,e)=>i).Count();
            
            // Assert
            Assert.AreEqual(evaluatedCollection.Count, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ForEach_GivenNullCollection_ShouldThrow()
        {
            // Arrange 
            _collection = null;

            // Act 
            _collection.ForEach(element => { });

            // Assert           
        }

        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new[] { 11, 12, 13, 14, 15, 16 })]
        public void ForEach_GivenACollection_ActionIsCalledWithTheCorrectElement(IEnumerable<int> collection)
        {
            // Arrange 
            var evaluatedCollection = collection.ToList();
            var results = new List<int>();

            // Act 
            Iterators.ForEach(evaluatedCollection, element => results.Add(element));

            // Assert
            for (int i = 0; i < evaluatedCollection.Count; i++)
            {
                Assert.AreEqual(evaluatedCollection[i], results[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SelectTypeOf_GivenNullCollection_ShouldThrow()
        {
            // Arrange 
            IEnumerable collection = null;

            // Act 
            var _ = collection.SelectTypeOf<int>().ToList();

            // Assert           
        }

        [TestMethod]
        public void SelectTypeOf_GivenCollection_ShouldSelectTheRequestedType()
        {
            // Arrange 
            IEnumerable collection = new object[] {1, "test", 2, 3, 4m};

            // Act 
            var result = collection.SelectTypeOf<int>();

            // Assert
            foreach (var i in result)
            {
                Assert.IsInstanceOfType(i, typeof(int));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SelectTypeOfGeneric_GivenNullCollection_ShouldThrow()
        {
            // Arrange 
            _collection = null;

            // Act 
            var _ = _collection.SelectTypeOf<int>().ToList();

            // Assert           
        }

        [TestMethod]
        public void SelectTypeOfGeneric_GivenCollection_ShouldSelectTheRequestedType()
        {
            // Arrange 
            IEnumerable<object> collection = new object[] { 1, "test", 2, 3, 4m };

            // Act 
            var result = collection.SelectTypeOf<int>();

            // Assert
            foreach (var i in result)
            {
                Assert.IsInstanceOfType(i, typeof(int));
            }
        }
        
        [TestMethod]
        public void Append_GivenCollection_ResultingCollectionShouldContainAllOftheElements()
        {
            // Arrange 
            var collection = new object[] { 1, "test", 2, 3, 4m };
            var secondCollection = new object[] { 5, "test2", 6, 7, 8m };

            var expected = new List<object>();
            expected.AddRange(collection);
            expected.AddRange(secondCollection);
            
            // Act 
            var result = collection.Append(secondCollection).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
