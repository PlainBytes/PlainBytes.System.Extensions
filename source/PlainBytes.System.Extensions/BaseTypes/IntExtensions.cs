using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Contains int and uint extension methods.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(this int value, int minimum, int maximum) => Math.Min(maximum, Math.Max(value, minimum));

        /// <summary>
        /// <inheritdoc cref="Convert.ToBoolean(int)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToBoolean(int)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this int value) => Convert.ToBoolean(value);

        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Clamp(this uint value, uint minimum, uint maximum) => Math.Min(maximum, Math.Max(value, minimum));

        /// <summary>
        /// <inheritdoc cref="Convert.ToBoolean(uint)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToBoolean(uint)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this uint value) => Convert.ToBoolean(value);
    }
}
