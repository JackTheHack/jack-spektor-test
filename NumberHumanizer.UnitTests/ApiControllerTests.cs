using System;
using NumberHumanizer.BusinessLogic;
using NumberHumanizer.Controllers;
using NumberHumanizer.Models;
using NUnit.Framework;

namespace NumberHumanizer.UnitTests
{
    [TestFixture]
    public class ApiControllerTests
    {
        private NumberController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new NumberController();
        }
   
        [TestCase()]
        public void WhenRequestIsEmpty_ApiThrowsException()
        {
            Assert.Catch<ArgumentNullException>(()=> _controller.Transform(null));
        }

        [TestCase()]
        public void WhenRequestIsValid_ApiReturnsCorrectText()
        {
            var result = _controller.Transform(new NumberTransformRequest()
            {
                Name = "Jack",
                Number = "25"
            });
            
            Assert.AreEqual(result.IsSuccess, true);
            Assert.AreEqual(result.Result.Text, "twenty-five dollars");
        }

        [TestCase()]
        public void WhenRequestIsInvalid_ApiReturnsError()
        {
            var result = _controller.Transform(new NumberTransformRequest()
            {
                Name = "Jack",
                Number = "1351246246246246"
            });

            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsFalse(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.IsNull(result.Result);
        }




    }
}
