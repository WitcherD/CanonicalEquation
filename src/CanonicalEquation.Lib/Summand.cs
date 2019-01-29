using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CanonicalEquation.Lib
{
    /// <summary>
    /// A summand in the given equation e.g. 4x^2y^3
    /// </summary>
    public class Summand
    {
        /// <summary>
        /// A quantity placed before variable in an algebraic expression (e.g., 4 in 4xy )
        /// </summary>
        public float Coefficient { get; set; }

        /// <summary>
        /// Variables of the summand e.g. x^2 or y^3 in 4x^2y^3
        /// </summary>
        public List<Variable> Variables { get; }

        /// <summary>
        /// Unique code of the summand. Summands with the same ID must be merged.
        /// </summary>
        public string SummandID => String.Join("", Variables.OrderBy(i => i.Name).Select(i => $"{i.Name}^{i.Exponent}"));

        /// <summary>
        /// Max exponent of all variables
        /// </summary>
        public int MaxExponent => Variables.Any() ? Variables.Max(i => i.Exponent) : 0;
        
        /// <inheritdoc />
        public Summand(float coefficient, IEnumerable<Variable> variables)
        {
            Coefficient = coefficient;
            Variables = variables.ToList();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            // If the coefficient equals 1 we need to skip the coefficient and keep sign
            var signString = Coefficient < 0 ? "-" : "";

            var variables = Variables.Where(i => i.Exponent > 0).ToList();
            var unsignCoefficient = Math.Abs(Coefficient);
            var unsignCoefficientString = variables.Any() && Math.Abs(unsignCoefficient - 1) < float.Epsilon
                ? String.Empty
                : unsignCoefficient.ToString(CultureInfo.InvariantCulture);

            var variablesString = String.Join(String.Empty, variables);
            return $"{signString}{unsignCoefficientString}{variablesString}";
        }
    }
}
