using CanonicalEquation.Lib;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class VariableTests
    {
        [TestCase("a", 1, "a")]
        [TestCase("b", 2, "b^2")]
        public void ToString_ValidParameters_CorrectRepresentation(string name, int exponent, string expected)
        {
            var variable = new Variable(name, exponent);
            Assert.AreEqual(expected, variable.ToString());
        }
    }
}
