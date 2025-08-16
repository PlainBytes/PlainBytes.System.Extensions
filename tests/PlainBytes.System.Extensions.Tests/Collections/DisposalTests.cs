using System;
using System.Collections.Generic;
using PlainBytes.System.Extensions.Collections;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.Collections
{
    public class DisposalTests
    {
        [Fact]
        public void Dispose_DisposesAllDisposableItems()
        {
            // Arrange
            var disposed = new List<int>();
            var items = new List<IDisposable>
            {
                new TestDisposable(1, disposed),
                new TestDisposable(2, disposed),
                new TestDisposable(3, disposed)
            };

            // Act
            items.Dispose();

            // Assert
            Assert.Equal(new[] { 1, 2, 3 }, disposed);
        }

        [Fact]
        public void Dispose_IgnoresNonDisposableItems()
        {
            // Arrange
            var items = new [] { new object(), new object() };

            // Act & Assert
            // Should not throw
            items.Dispose();
        }

        private class TestDisposable(int id, List<int> disposed) : IDisposable
        {
          public void Dispose()
            {
                disposed.Add(id);
            }
        }
    }
}
