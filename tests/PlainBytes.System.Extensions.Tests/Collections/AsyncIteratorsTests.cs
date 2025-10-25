using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlainBytes.System.Extensions.Collections;
using Xunit;

namespace PlainBytes.System.Extensions.Tests.Collections
{
    public class AsyncIteratorsTests
    {
        private static async IAsyncEnumerable<T> ToAsync<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                yield return item;
                await Task.Yield(); // ensure asynchronous execution path
            }
        }

        [Fact]
        public async Task ForEachAsync_GivenNullSource_ShouldThrow()
        {
            // Arrange
            IAsyncEnumerable<int> source = null;

            // Act / Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await source.ForEachAsync((i, ct) => ValueTask.CompletedTask));
        }

        [Fact]
        public async Task ForEachAsync_GivenSource_ActionIsExecutedForEachElement()
        {
            // Arrange
            var source = Enumerable.Range(0, 10).ToArray();
            var results = new List<int>();

            // Act
            await ToAsync(source).ForEachAsync((item, ct) =>
            {
                results.Add(item);
                return ValueTask.CompletedTask;
            });

            // Assert
            Assert.Equal(source, results);
        }

        [Fact]
        public async Task ForEachAsync_GivenCancellation_ShouldThrowOperationCanceled()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            var source = Enumerable.Range(0, 20);

            ValueTask Action(int item, CancellationToken token)
            {
                if (item == 3)
                {
                    cts.Cancel();
                }
                return ValueTask.CompletedTask;
            }

            // Act / Assert
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await ToAsync(source).ForEachAsync(Action, cts.Token));
        }

        [Fact]
        public async Task SelectAsync_GivenNullSource_ShouldThrow()
        {
            // Arrange
            IAsyncEnumerable<int> source = null;

            // Act / Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await foreach (var _ in source.SelectAsync(i => i)) { }
            });
        }

        [Fact]
        public async Task SelectAsync_GivenSelector_ProjectsAllElements()
        {
            // Arrange
            var source = Enumerable.Range(0, 15).ToArray();
            var results = new List<string>();

            // Act
            await foreach (var item in ToAsync(source).SelectAsync(i => $"#{i}"))
            {
                results.Add(item);
            }

            // Assert
            Assert.Equal(source.Length, results.Count);
            for (int i = 0; i < source.Length; i++)
            {
                Assert.Equal($"#{source[i]}", results[i]);
            }
        }

        [Fact]
        public async Task WhereAsync_GivenNullSource_ShouldThrow()
        {
            // Arrange
            IAsyncEnumerable<int> source = null;

            // Act / Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await foreach (var _ in source.WhereAsync(i => true)) { }
            });
        }

        [Fact]
        public async Task WhereAsync_GivenPredicate_FiltersElements()
        {
            // Arrange
            var source = Enumerable.Range(0, 30).ToArray();
            var result = new List<int>();

            // Act
            await foreach (var item in ToAsync(source).WhereAsync(i => i % 2 == 0))
            {
                result.Add(item);
            }

            // Assert
            Assert.All(result, x => Assert.True(x % 2 == 0));
            Assert.Equal(source.Where(i => i % 2 == 0), result);
        }
    }
}
