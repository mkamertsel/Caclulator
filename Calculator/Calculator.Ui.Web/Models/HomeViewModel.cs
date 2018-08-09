using System.Globalization;
using Calculator.Common.Entities;
using Calculator.Common.Enums;
using Calculator.Services;

namespace Calculator.Ui.Web.Models
{
    public class HomeViewModel
    {
        private readonly ICalculationAgregator calculationAgregator;
        private double? FirstNumber { get; set; }
        public string FirstNumberString { get; set; }
        private double? SecondNumber { get; set; }
        public string SecondNumberString { get; set; }
        public OperationType OperationType { get; set; }
        public string Error { get; set; }
        public double? Result { get; set; }

        public HomeViewModel(ICalculationAgregator calculationAgregator)
        {
            this.calculationAgregator = calculationAgregator;
            FirstNumberString = string.Empty;
            SecondNumberString = string.Empty;
        }

        public void PerformCalculation()
        {
            double number;
            if (double.TryParse(FirstNumberString, out number))
            {
                FirstNumber = number;
            }
            if (double.TryParse(SecondNumberString, out number))
            {
                SecondNumber = number;
            }
            if (!FirstNumber.HasValue || !SecondNumber.HasValue)
            {
                Error = "all fields must be filled";
                return;
            }
            Result = calculationAgregator.ApplyCalculation(
                new Operation { FirstNumber = FirstNumber, OperationType = OperationType, SecondNumber = SecondNumber });
        }
    }
}