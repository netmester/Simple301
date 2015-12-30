using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple301.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Short hand extension for Is Null or White Space
        /// </summary>
        /// <param name="s">string to check if set</param>
        /// <returns>true if string is set</returns>
        public static bool IsSet(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Ensures that the string starts with one 
        /// of the provided prefixes
        /// </summary>
        /// <param name="s">Current string</param>
        /// <param name="primaryPrefix">used if præfix is missing</param>
        /// <param name="alternatePrefix"></param>
        public static string EnsurePrefix(this string s, string primaryPrefix, params string[] alternatePrefix)
        {
            return s.EnsurePrefix(StringComparison.InvariantCulture, primaryPrefix, alternatePrefix);
        }


        /// <summary>
        /// Ensures that the string starts with one 
        /// of the provided prefixes
        /// </summary>
        /// <param name="s">Current string</param>
        /// <param name="comparison">way to compare</param>
        /// <param name="primaryPrefix">used if præfix is missing</param>
        /// <param name="alternatePrefix"></param>
        public static string EnsurePrefix(this string s, StringComparison comparison, string primaryPrefix, params string[] alternatePrefix)
        {
            if (!s.IsSet()) return string.Empty;
            if (!primaryPrefix.IsSet()) { return s; }
            var all = new[] { primaryPrefix }.Concat(alternatePrefix);
            return all.Any(px => s.StartsWith(px, comparison)) ? s : primaryPrefix + s;
        }
    }
}
