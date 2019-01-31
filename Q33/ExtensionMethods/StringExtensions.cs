using System;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string instance, string substring)
        {
            return instance.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool Contains(this string instance, string substring)
        {
            // use case insensitive comparison instead of case sensitive
            return instance.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }

}
