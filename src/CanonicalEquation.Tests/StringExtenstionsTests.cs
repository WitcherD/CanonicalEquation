using System.Linq;
using CanonicalEquation.Lib.Extensions;
using NUnit.Framework;

namespace CanonicalEquation.Tests
{
    public class StringExtenstionsTests
    {
        [TestCase("+a", "+a")]
        [TestCase("a", "a")]
        [TestCase("-a", "-a")]
        [TestCase("-a-b", "-a", "-b")]
        [TestCase("-a+b", "-a", "+b")]
        [TestCase("")]
        public void SplitAndKeepDelimeters_ValidParametes_CorrectSplitting(string input, params string[] expected)
        {
            var strings = input.SplitAndKeepDelimeters(new[] { '+', '-' }).ToArray();
            Assert.AreEqual(expected, strings);
        }
    }
}
