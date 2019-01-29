using System;
using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Lib.Parsers;

namespace CanonicalEquation.Lib
{
    /// <summary>
    /// Algebraic equation with summand and + and - operations
    /// </summary>
    public class Equation
    {
        public List<Summand> Summands { get; set; }

        public Equation(IEnumerable<Summand> summands)
        {
            Summands = summands.ToList();
        }

        public Equation() : this(new List<Summand>()) { }

        public static Equation Parse(string input) => EquationParser.Parse(input);

        /// <summary>
        /// Transforms summands into a canonical string
        /// </summary>
        public string ToCanonicalFormString()
        {
            var summands = Summands.Where(i => Math.Abs(i.Coefficient) > float.Epsilon).ToList();
            if (!summands.Any()) return "0 = 0";

            var summandStrings = summands.Select((summand, index) => index == 0 ? summand.ToString() : Math.Sign(summand.Coefficient) > 0 ? "+" + summand.ToString() : summand.ToString());
            var polinomialString = String.Join(string.Empty, summandStrings).Replace("+", " + ").Replace("-", " - ");
            if (polinomialString.StartsWith(" - ")) polinomialString = "-" + polinomialString.Substring(3);

            return $"{polinomialString} = 0";
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return ToCanonicalFormString();
        }
    }
}

