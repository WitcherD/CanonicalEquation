using CanonicalEquation.Lib.Parsers;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class EquationParserTests
    {
        [TestCase("x^2 + 3.5xy + y = y^2 - xy + y", 4)]
        [TestCase("x = 1", 2)]
        [TestCase("x - (y^2 - x) = 0", 3)]
        [TestCase("x - (0 - (0 - x)) = 0", 2)]
        public void Parse_ValidEquation_CorrectAmountOfSummands(string input, int expected)
        {
            var equation = EquationParser.Parse(input);
            Assert.AreEqual(expected, equation.Summands.Count);
        }
    }
}
