using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CanonicalEquation.Lib.Parsers
{
    /// <summary>
    /// Summands factory
    /// </summary>
    public static class SummandParser
    {
        private static readonly Regex CoefficientRegex = new Regex(@"^[+-]?\d*\.?\d*", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex VariablesRegex = new Regex(@"[a-zA-Z](\^\d+)?", RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Parse a summand string e.g. 2x^2y^2
        /// </summary>
        public static Summand Parse(string input)
        {
            var coefficientString = CoefficientRegex.Match(input).Value;
            var coefficient = String.IsNullOrEmpty(coefficientString) || coefficientString.Equals("+")
                ? 1
                : coefficientString.Equals("-")
                    ? -1
                    : float.Parse(coefficientString);

            var variables = VariablesRegex
                .Matches(input)
                .Select(i => VariableParser.Parse(i.Value))
                .GroupBy(i => i.Name)
                .Select(i => new Variable(i.Key, i.Sum(j => j.Exponent)))
                .OrderBy(i => i.Name)
                .ToList();

            var result = new Summand(coefficient, variables);
            return result;
        }
    }
}
