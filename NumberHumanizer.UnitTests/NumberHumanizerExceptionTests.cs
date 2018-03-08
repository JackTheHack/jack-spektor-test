using System;
using NumberHumanizer.BusinessLogic;
using NUnit.Framework;

namespace NumberHumanizer.UnitTests
{
    [TestFixture]
    public class NumberHumanizerExceptionTests
    {
        private INumberHumanizer _humanizer;

        [SetUp]
        public void Setup()
        {
            _humanizer = new DecimalNumberHumanizer();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("abc")]
        [TestCase("0fc")]
        [TestCase("0.d0")]
        [TestCase("0.")]

        public void NumberHumanizer_ThrowsException_WhenNumberIsNotValid(string input)
        {
            Assert.Catch<ArgumentException>(() => _humanizer.Transform(input));
        }

    }
}
