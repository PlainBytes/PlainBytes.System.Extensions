using System;
using System.IO;
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

        /// <summary>
        /// Converts the provided ints into bytes.
        /// </summary>
        /// <param name="value">Values which should be converted into bytes.</param>
        /// <returns>Collection of <see langword="byte"/>s.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided value is <see langword="null"/></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes(this int[] value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var numArray = new byte[value.Length * 4];
            Buffer.BlockCopy(value, 0, numArray, 0, numArray.Length);
            return numArray;
        }

        /// <summary>
        /// Converts the provided bytes into ints.
        /// </summary>
        /// <param name="value">Values which should be converted into ints.</param>
        /// <returns>Collection of <see langword="int"/>s.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided value is <see langword="null"/>.</exception>
        /// <exception cref="InvalidDataException">Thrown if the number of bytes does not align with the value type.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] ToIntArray(this byte[] value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value.Length % 4 != 0)
            {
                throw new InvalidDataException("Byte Object length must be a multiple of 4");
            }

            var result = new int[value.Length / 4];

            for (var i = 0; i < value.Length; i += 4)
            {
                result[i / 4] = BitConverter.ToInt32(value[i..(i + 4)]);
            }

            return result;
        }
    }
}
