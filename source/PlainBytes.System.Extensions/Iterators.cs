using System;
using System.Collections;
using System.Collections.Generic;

namespace PlainBytes.System.Extensions
{
    public static class Iterators
    {
        /// <summary>
        /// Iterates through the collection while calling the action with the current index and element.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <param name="collection">Collection on which we iterate.</param>
        /// <param name="action">The action that will be executed for each and every element.</param>
        public static void For<T>(this IList<T> collection, Action<int, T> action)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                action(i, collection[i]);
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
        public static IEnumerable<TR> SelectWithIndex<T, TR>(this IList<T> collection, Func<int, T, TR> function)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                yield return function(i, collection[i]);
            }
        }

        /// <summary>
        /// Iterates through the collection while calling the action with the current element.
        /// </summary>
        /// <typeparam name="T">The base type of the source collection elements.</typeparam>
        /// <param name="enumerable">Collection on which we iterate.</param>
        /// <param name="action">The action that will be executed for each and every element.</param>
        public static void Foreach<T>(this IEnumerable<T> enumerable, Action<T> action)
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
    }
}
