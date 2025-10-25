using System.Collections.Concurrent;
using System;
using System.Linq;

namespace PlainBytes.System.Extensions.BaseTypes
{
    /// <summary>
    /// Defines extensions for the <see cref="Type"/> type.
    /// </summary>
    public static class TypeExtensions
    {
        private static readonly ConcurrentDictionary<Type, string> FormattedNameCache = new();

        /// <summary>
        /// Returns the name of the type, if generic than with the generic types.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        public static string GetFormattedName<T>() => GetFormattedName(typeof(T));

        /// <summary>
        /// Returns the name of the type, if generic than with the generic types.
        /// </summary>
        /// <param name="type">Source type.</param>
        public static string GetFormattedName(this Type? type)
        {
            if (type == null)
            {
                return "null";
            }
            
            return FormattedNameCache.GetOrAdd(type, static t =>
            {
                if (t.IsGenericType)
                {
                    var arguments = t.GetGenericArguments();
                    var trimmed = $"`{arguments.Length}".ToArray();
                    return $"{t.Name.TrimEnd(trimmed)}<{string.Join(',', arguments.Select(x => x.GetFormattedName()))}>";
                }
                return t.Name;
            });
        }
    }
}