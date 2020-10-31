﻿namespace BriskBytes.System.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Negation of <see cref="string.IsNullOrEmpty(string)"/>
        /// </summary>
        public static bool HasValue(this string value) => !value.IsNullOrEmpty();

        /// <summary>
        /// Negation of <see cref="string.IsNullOrWhiteSpace(string)"/>
        /// </summary>
        public static bool HasActualValue(this string value) => !value.IsNullOrWhiteSpace();

        /// <summary>
        /// <inheritdoc cref="string.IsNullOrEmpty(string)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.IsNullOrEmpty(string)"/></param>
        /// <returns><inheritdoc cref="string.IsNullOrEmpty(string)"/></returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// <inheritdoc cref="string.IsNullOrWhiteSpace(string)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.IsNullOrWhiteSpace(string)"/></param>
        /// <returns><inheritdoc cref="string.IsNullOrWhiteSpace(string)"/></returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// <inheritdoc cref="string.Format(string, object[])"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="string.Format(string, object[])"/></param>
        /// <param name="arguments"><inheritdoc cref="string.Format(string, object[])"/></param>
        /// <returns><inheritdoc cref="string.Format(string, object[])"/></returns>
        public static string FormatWith(this string value, params object[] arguments) => string.Format(value, arguments);
    }
}
