using NumberHumanizer.BusinessLogic;
using NUnit.Framework;

namespace NumberHumanizer.UnitTests
{
    [TestFixture]
    public class NumberHumanizerNumberTests
    {
        private INumberHumanizer _humanizer;

        [SetUp]
        public void Setup()
        {
            _humanizer = new DecimalNumberHumanizer();
        }

        [TestCase("0", "zero dollars")]
        [TestCase("1", "one dollar")]
        [TestCase("2", "two dollars")]
        [TestCase("3", "three dollars")]
        [TestCase("4", "four dollars")]
        [TestCase("5", "five dollars")]
        [TestCase("6", "six dollars")]
        [TestCase("7", "seven dollars")]
        [TestCase("8", "eight dollars")]
        [TestCase("9", "nine dollars")]        
        public void NumberHumanizerOneDigit(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("10", "ten dollars")]
        [TestCase("11", "eleven dollars")]
        [TestCase("12", "twelve dollars")]
        [TestCase("20", "twenty dollars")]
        [TestCase("35", "thirty-five dollars")]
        [TestCase("72", "seventy-two dollars")]
        [TestCase("93", "ninety-three dollars")]
        public void NumberHumanizerTwoDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("100", "one hundred dollars")]
        [TestCase("200", "two hundred dollars")]
        [TestCase("420", "four hundred and twenty dollars")]
        [TestCase("542", "five hundred and forty-two dollars")]
        public void NumberHumanizerThreeDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("1000", "one thousand dollars")]
        [TestCase("2005", "two thousand and five dollars")]
        [TestCase("3500", "three thousand five hundred dollars")]
        [TestCase("4250", "four thousand two hundred and fifty dollars")]
        [TestCase("5872", "five thousand eight hundred and seventy-two dollars")]
        public void NumberHumanizerFourDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("10000", "ten thousand dollars")]
        [TestCase("20501", "twenty thousand five hundred and one dollars")]
        [TestCase("31523", "thirty-one thousand five hundred and twenty-three dollars")]
        public void NumberHumanizerFiveDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("1000000", "one million dollars")]
        [TestCase("2005000", "two million five thousand dollars")]
        [TestCase("3015020", "three million fifteen thousand and twenty dollars")]
        public void NumberHumanizerSevenDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }

        [TestCase("10.12", "ten dollars and twelve cents")]
        [TestCase("10.125", "ten dollars and twelve cents")]
        [TestCase("10.1", "ten dollars and ten cents")]
        [TestCase("0.21", "zero dollars and twenty-one cents")]
        public void NumberHumanizerDecimalDigits(string input, string output)
        {
            Assert.AreEqual(output, _humanizer.Transform(input));
        }



    }
}
