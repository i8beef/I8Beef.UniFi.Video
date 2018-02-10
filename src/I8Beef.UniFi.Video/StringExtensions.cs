using System;
using System.Linq;

namespace I8Beef.UniFi.Video
{
    /// <summary>
    /// String extensions.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts the first character of a string to lower case.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <returns>Original string with first character lower case.</returns>
        public static string FirstCharToLower(this string value)
        {
            return value.First().ToString().ToLower() + value.Substring(1);
        }
    }
}
