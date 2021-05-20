using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Contains long and ulong extension methods.
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Clamp(this long value, long minimum, long maximum) => Math.Min(maximum, Math.Max(value, minimum));

        /// <summary>
        /// <inheritdoc cref="Convert.ToBoolean(long)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToBoolean(long)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this long value) => Convert.ToBoolean(value);
        
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Clamp(this ulong value, ulong minimum, ulong maximum) => Math.Min(maximum, Math.Max(value, minimum));

        /// <summary>
        /// <inheritdoc cref="Convert.ToBoolean(ulong)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToBoolean(ulong)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this ulong value) => Convert.ToBoolean(value);
    }
}