using Calculator.Common.Entities;
using Calculator.Common.Enums;
using Calculator.Web.Services;
using Caliburn.Micro;

namespace Calculator.Ui.Wpf.Presentation.ViewModels
{
    public class ShellViewModel : Screen
    {
        private const string emptyResultErrorMessage = "The Result will be sent to the mail";
        private const string emptyFieldsErrorMessage = "Аll fields must be filled";
        private const string invalidFieldsErrorMessage = "Аll fields must be filled";

        private readonly ICalculationAgregator calculationAgregator;
        private string error;
        private double? result;

        public ShellViewModel(ICalculationAgregator calculationAgregator)
        {
            this.calculationAgregator = calculationAgregator;
        }

        private double? FirstNumber { get; set; }
        public string FirstNumberString { get; set; }
        private double? SecondNumber { get; set; }
        public string SecondNumberString { get; set; }
        public OperationType OperationType { get; set; }

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                NotifyOfPropertyChange(() => Error);
            }
        }

        public double? Result
        {
            get { return result; }
            set
            {
                result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }

        private bool AreFieldsValid()
        {
            if (string.IsNullOrWhiteSpace(FirstNumberString) || string.IsNullOrWhiteSpace(SecondNumberString))
            {
                Error = emptyFieldsErrorMessage;
                return false;
            }
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
                Error = invalidFieldsErrorMessage;
                return false;
            }
            return true;
        }

        private void PerformCalculation(OperationType operationType)
        {
            Error = null;
            if (!AreFieldsValid())
            {
                return;
            }
            OperationType = operationType;

            Result = calculationAgregator.ApplyCalculation(
                new Operation {FirstNumber = FirstNumber, OperationType = OperationType, SecondNumber = SecondNumber});
            if (Result == null)
            {
                Error = emptyResultErrorMessage;
            }
        }

        public void Addition()
        {
            PerformCalculation(OperationType.Addition);
        }

        public void Multiplication()
        {
            PerformCalculation(OperationType.Multiplication);
        }

        public void Division()
        {
            PerformCalculation(OperationType.Division);
        }

        public void Subtraction()
        {
            PerformCalculation(OperationType.Subtraction);
        }
    }
}