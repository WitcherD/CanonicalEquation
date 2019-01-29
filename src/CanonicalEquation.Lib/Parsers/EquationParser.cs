using System;
using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Lib.Extensions;

namespace CanonicalEquation.Lib.Parsers
{
    /// <summary>
    /// Equation factory
    /// </summary>
    public static class EquationParser
    {
        /// <summary>
        /// Parse an equation string e.g. x^2 + 3.5xy + y = y^2 - xy + y
        /// </summary>
        public static Equation Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException(nameof(input));

            var polinomials = input.Split('=');
            if (polinomials.Length != 2 || String.IsNullOrEmpty(polinomials[0]) || String.IsNullOrEmpty(polinomials[1]))
                throw new ArgumentException(nameof(input));

            var leftSummands = ParsePolinomialIntoSummands(polinomials[0]).ToList();
            var rightSummands = ParsePolinomialIntoSummands(polinomials[1]).ToList();

            rightSummands.ForEach(i => i.Coefficient *= -1);
            leftSummands.AddRange(rightSummands);

            var equation = new Equation();
            foreach (var summand in leftSummands)
            {
                var found = equation.Summands.Find(x => x.SummandID.Equals(summand.SummandID));
                if (found != null)
                    found.Coefficient += summand.Coefficient;
                else
                    equation.Summands.Add(summand);
            }

            equation.Summands = equation.Summands.OrderByDescending(s => s.MaxExponent).ThenBy(i => i.SummandID).ToList();
            return equation;
        }

        private static IEnumerable<Summand> ParsePolinomialIntoSummands(string input)
        {
            return input.GetRidOfBrackets().SplitAndKeepDelimeters(new[] {'+', '-'}).Select(SummandParser.Parse);
        }
    }
}
