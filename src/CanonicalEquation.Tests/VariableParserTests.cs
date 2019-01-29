using CanonicalEquation.Lib.Parsers;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class VariableParserTests
    {
        [TestCase("a", "a", 1)]
        [TestCase("b^2", "b", 2)]
        public void Parse_ValidParameters_CorrectParsing(string input, string expectedName, int expectedExponent)
        {
            var variable = VariableParser.Parse(input);
            Assert.AreEqual(expectedName, variable.Name);
            Assert.AreEqual(expectedExponent, variable.Exponent);
        }
    }
}
