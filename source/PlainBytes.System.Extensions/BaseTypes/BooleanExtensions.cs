using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Contains bool extension methods.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// <inheritdoc cref="Convert.ToInt32(bool)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToInt32(bool)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool value) => Convert.ToInt32(value);

        /// <summary>
        /// <inheritdoc cref="Convert.ToUInt32(bool)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToUInt32(bool)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt(this bool value) => Convert.ToUInt32(value);

        /// <summary>
        /// <inheritdoc cref="Convert.ToUInt64(bool)"/>
        /// </summary>
        /// <returns><inheritdoc cref="Convert.ToUInt64(bool)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ToUlong(this bool value) => Convert.ToUInt64(value);
    }
}