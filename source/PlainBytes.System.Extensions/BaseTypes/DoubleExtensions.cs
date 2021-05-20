using System;
using System.Runtime.CompilerServices;

namespace PlainBytes.System.Extensions.BaseTypes
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Assures that the <paramref name="value"/> is in between <paramref name="minimum"/> and <paramref name="maximum"/>
        /// </summary>
        /// <returns><paramref name="value"/> if it is in between <paramref name="minimum"/> and  <paramref name="maximum"/>.
        /// Otherwise <paramref name="minimum"/> if smaller, <paramref name="maximum"/> larger.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Clamp(this double value, double minimum, double maximum)
        {
            return Math.Min(maximum, Math.Max(value, minimum));
        }

        /// <summary>
        /// <inheritdoc cref="double.IsInfinity(double)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="double.IsInfinity(double)"/></param>
        /// <returns><inheritdoc cref="double.IsInfinity(double)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity(this double value) => double.IsInfinity(value);

        /// <summary>
        /// <inheritdoc cref="double.IsNaN(double)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="double.IsNaN(double)"/></param>
        /// <returns><inheritdoc cref="double.IsNaN(double)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(this double value) => double.IsNaN(value);

        /// <summary>
        /// <inheritdoc cref="double.IsNegativeInfinity(double)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="double.IsNegativeInfinity(double)"/></param>
        /// <returns><inheritdoc cref="double.IsNegativeInfinity(double)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity(this double value) => double.IsNegativeInfinity(value);

        /// <summary>
        /// <inheritdoc cref="double.IsPositiveInfinity(double)"/>
        /// </summary>
        /// <param name="value"><inheritdoc cref="double.IsPositiveInfinity(double)"/></param>
        /// <returns><inheritdoc cref="double.IsPositiveInfinity(double)"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity(this double value) => double.IsPositiveInfinity(value);

        /// <summary>
        /// Compares two double values with the provided tolerance
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="compared">Compared value</param>
        /// <param name="tolerance">Maximum allowed difference</param>
        /// <returns>True if they are equal, including if both of them are NaN, false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqual(this double value, double compared, double tolerance = 0)
        {
            if (value.IsNaN() && compared.IsNaN())
            {
                return true;
            }

            return Math.Abs(value - compared) < tolerance;
        }
    }
}
