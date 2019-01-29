namespace CanonicalEquation.Lib
{
    /// <summary>
    /// Variable in equation e.g. x^2
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// The name of variable (e.g., x in x^2 )
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A quantity representing the power to which a given number or expression is to be raised (e.g., 2 in x^2)
        /// </summary>
        public int Exponent { get; }

        /// <inheritdoc />
        public Variable(string name, int exponent)
        {
            Name = name;
            Exponent = exponent;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Exponent == 1 ? Name : $"{Name}^{Exponent}";
        }
    }
}