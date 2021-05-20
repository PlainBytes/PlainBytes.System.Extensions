using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Contains byte extension methods.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> if larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Clamp(this byte value, byte minimum, byte maximum) => Math.Min(maximum, Math.Max(value, minimum));

        /// <summary>
        /// <inheritdoc cref="Convert.ToBoolean(byte)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToBoolean(byte)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBool(this byte value) => Convert.ToBoolean(value);
    }
}