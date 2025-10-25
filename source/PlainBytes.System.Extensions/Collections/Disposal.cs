using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.Collections
{
    /// <summary>
    /// Contains the extensions for disposing objects and collection of disposable objects.
    /// </summary>
    public static class Disposal
    {
        /// <summary>
        /// Disposes all elements from the provided collection that implement the <see cref="IDisposable"/>
        /// </summary>
        /// <param name="items">Source collection of disposable items.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Dispose<T>(this IEnumerable<T> items)
        {
            ArgumentNullException.ThrowIfNull(items);
            
            foreach (var item in items)
            {
                if (item is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}