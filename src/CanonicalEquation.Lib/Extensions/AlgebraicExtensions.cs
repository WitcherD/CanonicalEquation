using System;
using System.Collections.Generic;

namespace CanonicalEquation.Lib.Extensions
{
    /// <summary>
    /// Helper methods for algebraic strings
    /// </summary>
    public static class AlgebraicExtensions
    {
        /// <summary>
        /// Remove brackets from an algebraic string containing + and – operators
        /// http://naaspati-java.blogspot.com/2017/09/remove-brackets-from-algebraic-string.html
        /// </summary>
        public static string GetRidOfBrackets(this string str)
        {
            var chars = str.Replace(" ", "").ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                {
                    FindBracket(i, chars);
                    break;
                }
            }
            var result = new String(chars).Replace(" ", "");
            return result;
        }

        private static void FindBracket(int open, char[] chars)
        {
            for (var i = open + 1; i < chars.Length; i++)
            {
                if (chars[i] == '(')
                {
                    FindBracket(i, chars);
                }
                
                else if (chars[i] == ')')
                {
                    RemoveBrackets(chars, open, i);

                    for (var j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] == '(')
                        {
                            FindBracket(j, chars);
                            break;
                        }
                    }
                }
            }
        }

        private static void RemoveBrackets(IList<char> chars, int open, int close)
        {
            var op = '+';
            for (var i = open - 1; i >= 0; i--)
            {
                if (chars[i] == '+' || chars[i] == '-')
                {
                    op = chars[i];
                    break;
                }
            }

            chars[open] = ' ';
            chars[close] = ' ';

            if (op == '+')
                return;

            for (var i = open + 1; i < chars.Count; i++)
            {
                var c = chars[i];
                chars[i] = c == '+' ? '-' : c == '-' ? '+' : c;
            }
        }
    }
}
