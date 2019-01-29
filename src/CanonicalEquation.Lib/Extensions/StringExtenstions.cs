using System.Collections.Generic;

namespace CanonicalEquation.Lib.Extensions
{
    /// <summary>
    /// Extension methods over <see cref="string"/>
    /// </summary>
    public static class StringExtenstions
    {
        /// <summary>
        /// Splits the given string and keeps the delimeter in the beginning of each word.
        /// </summary>
        public static IEnumerable<string> SplitAndKeepDelimeters(this string input, char[] delimeters)
        {
            int start = 0, index;

            while ((index = input.IndexOfAny(delimeters, start)) != -1)
            {
                if (index - start > 0)
                    if (start - 1 >= 0)
                        yield return input.Substring(start - 1, index - start + 1);
                    else
                        yield return input.Substring(start, index - start);

                start = index + 1;
            }

            if (start < input.Length)
                yield return input.Substring(start > 0 ? start - 1 : 0);
        }
    }
}
