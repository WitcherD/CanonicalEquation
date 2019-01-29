using System;

namespace CanonicalEquation.Lib.Parsers
{
    /// <summary>
    /// Variables factory
    /// </summary>
    public class VariableParser
    {
        /// <summary>
        /// Parse a variable string e.g. x^2
        /// </summary>
        public static Variable Parse(string input)
        {
            var parts = input.Split(new[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
            return new Variable(parts[0], parts.Length > 1 ? Convert.ToInt32(parts[1]) : 1);
        }
    }
}
