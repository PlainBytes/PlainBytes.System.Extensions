using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Contains the string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Negation of <see cref="string.IsNullOrEmpty(string)"/>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue([NotNullWhen(true)] this string? value) => !value.IsNullOrEmpty();

        /// <summary>
        /// Negation of <see cref="string.IsNullOrWhiteSpace(string)"/>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasActualValue([NotNullWhen(true)] this string? value) => !value.IsNullOrWhiteSpace();

        /// <summary>
        /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.IsNullOrEmpty(string)"/></param>
        /// <returns><inheritdoc cref="string.IsNullOrEmpty(string)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.IsNullOrWhiteSpace(string)"/></param>
        /// <returns><inheritdoc cref="string.IsNullOrWhiteSpace(string)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrWhiteSpace([NotNullWhen(false)]this string? value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// <inheritdoc cref="string.Format(string, object[])"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.Format(string, object[])"/></param>
        /// <param name="arguments"><inheritdoc cref="string.Format(string, object[])"/></param>
        /// <returns><inheritdoc cref="string.Format(string, object[])"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FormatWith(this string? value, params object[] arguments)
        {
            ArgumentNullException.ThrowIfNull(value);
            
            return string.Format(value, arguments);
        }
    }
}
