using System;
using CanonicalEquation.Lib;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class EquationTests
    {
        [TestCase("3abca^2b^2c^2 - a^3b^3c^3 + a^4 + abc + 2b + c^1 + d^0 = -a-(a-(a-a)) + abc + b", "a^4 + 2a^3b^3c^3 + 2a + b + c + 1 = 0")]
        [TestCase("x^2 + 3.5xy + y = y^2 - xy + y", "x^2 - y^2 + 4.5xy = 0")]
        [TestCase("x = 1", "x - 1 = 0")]
        [TestCase("x - (y^2 - x) = 0", "-y^2 + 2x = 0")]
        [TestCase("x - (0 - (0 - x)) = 0", "0 = 0")]
        [TestCase("+1.1x = +1.0x", "0.1x = 0")]
        [TestCase("1.0x = 0.9x", "0.1x = 0")]
        [TestCase("1-(2-3) = 0", "2 = 0")]
        public void ToCanonicalForm_ValidEquation_CorrectForm(string input, string expected)
        {
            var equation = Equation.Parse(input);
            Assert.AreEqual(expected, equation.ToString());
        }

        [TestCase("", "")]
        [TestCase("a=", "")]
        [TestCase("a+", "")]
        public void ToCanonicalForm_InvalidInputString_ThrowsArgumentException(string input, string expected)
        {
            Assert.Throws<ArgumentException>(() => Equation.Parse(input));
        }
    }
}
