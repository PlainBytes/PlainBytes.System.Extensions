﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.Collections
{
    /// <summary>
    /// Contains the extensions for validation and accessing collection indexes.
    /// </summary>
    public static class IndexLookup
    {
        /// <summary>
        /// Checks if the index is valid for the collection
        /// </summary>
        /// <typeparam name="T">The generic type of the collection</typeparam>
        /// <param name="source">The collection that is being checked on</param>
        /// <param name="index">The index that is being evaluated</param>
        /// <returns>True if the index is valid</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIndex<T>(this IList<T> source, int index)
        {
            return index > -1 && index < source.Count;
        }

        /// <summary>
        /// Tries to get the value from the given index.
        /// </summary>
        /// <typeparam name="T">The generic type of the collection</typeparam>
        /// <param name="source">The collection that is being accessed</param>
        /// <param name="index">The index that is being evaluated</param>
        /// <returns>The value if the index is valid, otherwise the default of the collection type</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AtIndexOrDefault<T>(this IList<T> source, int index)
        {
            if (source.HasIndex(index))
            {
                return source[index];
            }

            Debug.WriteLine($"Index is out of bounds should have been in range of 0 and {source.Count}");

            return default;
        }

        /// <summary>
        /// Tries to get the value from the given index.
        /// </summary>
        /// <typeparam name="T">The generic type of the collection</typeparam>
        /// <param name="source">The collection that is being accessed</param>
        /// <param name="index">The index that is being evaluated</param>
        /// <param name="fallback">The fallback value</param>
        /// <returns>The value if the index is valid, otherwise the provided fallback</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AtIndexOrFallback<T>(this IList<T> source, int index, T fallback)
        {
            if (source.HasIndex(index))
            {
                return source[index];
            }

            Debug.WriteLine($"Index is out of bounds should have been in range of 0 and {source.Count}");

            return fallback;
        }
    }
}
