using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    public static class IntExtensions
    {
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(this int value, int minimum, int maximum)
        {
            return Math.Min(maximum, Math.Max(value, minimum));
        }
    }
}
