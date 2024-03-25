using System;
using System.Linq;
using PlainBytes.System.Extensions.Collections;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.Collections;

public class CompositeDisposableTests
{
    private class DisposableTest : IDisposable
    {
        public int DisposedCount { get; private set; }

        public void Dispose()
        {
            DisposedCount++;
        }
    }

    [Fact]
    public void Constructor_GivenNullValue_Throws()
    {
        // Assert
        Assert.Throws<ArgumentNullException>(() => new CompositeDisposable(null));
    }

    [Fact]
    public void Disposed_Always_DisposesProvidedItems()
    {
        // Arrange
        var items = Enumerable.Range(0, 5).Select(_ => new DisposableTest()).ToArray();
        var sut = new CompositeDisposable(items);

        // Act
        sut.Dispose();
         // Assert
        Assert.All(items, item => Assert.Equal(1, item.DisposedCount));
    }
}