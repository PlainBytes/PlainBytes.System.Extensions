using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace PlainBytes.System.Extensions.Collections
{
    /// <summary>
    /// Contains the extensions for iterating over collections.
    /// </summary>
    public static class Iterators
    {
        /// <summary>
        /// Iterates through the collection while calling the action with the current index and element.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <param name="collection">Collection on which we iterate.</param>
        /// <param name="action">The action that will be executed for each and every element.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void For<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            var index = 0;

            foreach (var item in collection)
            {
                action(index, item);
                index++;
            }
        }

        /// <summary>
        /// Iterates through the collection while calling the function with the current index and element.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <typeparam name="TR">The base type of the collection elements that will be returned</typeparam>
        /// <param name="collection">Collection on which we iterate.</param>
        /// <param name="function">The function that will be executed for each and every element and its result is yielded</param>
        /// <returns>Collection of results</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TR> SelectWithIndex<T, TR>(this IEnumerable<T> collection, Func<int, T, TR> function)
        {
            var index = 0;

            foreach (var item in collection)
            {
                yield return function(index, item);
                index++;
            }
        }

        /// <summary>
        /// Iterates through the collection while calling the action with the current element.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <param name="enumerable">Collection on which we iterate.</param>
        /// <param name="action">The action that will be executed for each and every element.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var result in enumerable)
            {
                action(result);
            }
        }

        /// <summary>
        /// Iterates through the collection while selecting the defined type and yielding it.
        /// </summary>
        /// <typeparam name="TR">The type that should be selected.</typeparam>
        /// <param name="enumerable">Collection on which we iterate.</param>
        /// <returns>Collection of selected elements</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TR> SelectTypeOf<TR>(this IEnumerable enumerable)
        {
            foreach (var element in enumerable)
            {
                if (element is TR typedElement)
                {
                    yield return typedElement;
                }
            }
        }

        /// <summary>
        /// Iterates through the collection while selecting the defined type and yielding it.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <typeparam name="TR">The type that should be selected.</typeparam>
        /// <param name="enumerable">Collection on which we iterate.</param>
        /// <returns>Collection of selected elements</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TR> SelectTypeOf<T, TR>(this IEnumerable<T> enumerable)
        {
            foreach (var element in enumerable)
            {
                if (element is TR typedElement)
                {
                    yield return typedElement;
                }
            }
        }

        /// <summary>
        /// Merges the two collections into a single IEnumerable{T}
        /// </summary>
        /// <typeparam name="T">The generic type of the collections.</typeparam>
        /// <param name="collection">Original source collection.</param>
        /// <param name="addition">Collection of items which will be appended.</param>
        /// <returns>Merged collection of the two inputs.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> Append<T>(this IEnumerable<T> collection, IEnumerable<T> addition)
        {
            foreach (var item in collection)
            {
                yield return item;
            }

            foreach (var item in addition)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Asynchronously enumerates the elements of the source sequence and invokes the specified asynchronous action
        /// for each element.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">The asynchronous sequence whose elements are to be processed.</param>
        /// <param name="action">An asynchronous delegate to invoke for each element in the source sequence.</param>
        /// <param name="token">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task completes when all elements have been processed
        /// or the operation is canceled.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, Func<T, CancellationToken, ValueTask> action, CancellationToken token = default)
        {
            await foreach (var item in source.WithCancellation(token))
            {
                token.ThrowIfCancellationRequested();

                await action(item, token).ConfigureAwait(false);
            }
        }


        /// <summary>
        /// Iterates through the asynchronous sequence while processing the elements.
        /// </summary>
        /// <param name="source">The source asynchronous sequence to process.</param>
        /// <param name="selector">Transformer that processes the iterated items.</param>
        /// <param name="token">A cancellation token that can be used to cancel the asynchronous iteration.</param>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="TR">Type of result item.</typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async IAsyncEnumerable<TR> SelectAsync<T, TR>(this IAsyncEnumerable<T> source, Func<T, TR> selector, [EnumeratorCancellation] CancellationToken token = default)
        {
            await foreach (var item in source.WithCancellation(token))
            {
                token.ThrowIfCancellationRequested();

                yield return selector(item);
            }
        }

        /// <summary>
        /// Filters the elements of an asynchronous sequence based on a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
        /// <param name="source">The source asynchronous sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition. The element is included in the result if the function
        /// returns <see langword="true"/>.</param>
        /// <param name="token">A cancellation token that can be used to cancel the asynchronous iteration.</param>
        /// <returns>An asynchronous sequence that contains elements from the source sequence that satisfy the condition
        /// specified by the predicate.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async IAsyncEnumerable<T> WhereAsync<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate, [EnumeratorCancellation] CancellationToken token = default)
        {
            await foreach (var item in source.WithCancellation(token))
            {
                token.ThrowIfCancellationRequested();

                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
