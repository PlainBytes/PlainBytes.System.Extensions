using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
    }
}
