using CanonicalEquation.Lib.Parsers;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class SummandParserTests
    {
        [TestCase("2abcabc", 2, 2, "a^2b^2c^2")]
        [TestCase("abca^1b^2c^3", 1, 4, "a^2b^3c^4")]
        [TestCase("0a", 0, 1, "a^1")]
        public void Parse_ValidParameters_CorrectParsing(string input, float expectedCoefficient, int expectedMaxExponent, string expectedSummandID)
        {
            var summand = SummandParser.Parse(input);
            Assert.AreEqual(expectedCoefficient, summand.Coefficient);
            Assert.AreEqual(expectedMaxExponent, summand.MaxExponent);
            Assert.AreEqual(expectedSummandID, summand.SummandID);
        }
    }
}
