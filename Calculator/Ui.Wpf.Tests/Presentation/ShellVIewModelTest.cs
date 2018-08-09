using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common.Entities;
using Calculator.Common.Enums;
using Calculator.Ui.Wpf.Presentation.ViewModels;
using Calculator.Web.Services;
using Caliburn.Micro;
using Moq;
using NUnit.Framework;

namespace Ui.Wpf.Tests.Presentation
{
    [TestFixture]
    internal class ShellVIewModelTest
    {
        private Mock<ICalculationAgregator> calcAgregator;
        private Operation operation;
        private double? result;

        [SetUp]
        public void Setup()
        {
            operation = new Operation
            {
                FirstNumber = 34,
                SecondNumber = 43,
                OperationType = OperationType.Multiplication,
                CalculatorId = 123
            };
            calcAgregator = new Mock<ICalculationAgregator>();
        }

        [Test]
        public void SendOperationTest()
        {
            calcAgregator.Setup(service => service.ApplyCalculation(operation)).Returns(() => result);

            var viewModel = new ShellViewModel(calcAgregator.Object)
            {
                FirstNumberString = operation.FirstNumber.ToString(), SecondNumberString = operation.SecondNumber.ToString()
            };

            viewModel.Addition();
            
            Assert.AreEqual(result, viewModel.Result);
        }
    }
}
