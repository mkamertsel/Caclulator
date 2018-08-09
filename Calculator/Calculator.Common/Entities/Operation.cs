using Calculator.Common.Enums;

namespace Calculator.Common.Entities
{
    public class Operation
    {
        public int OperationId { get; set; }
        public int CalculatorId { get; set; }

        public double? FirstNumber { get; set; }
        public double? SecondNumber { get; set; }
        public OperationType OperationType { get; set; }
        public string OperationTypeString => GetOperationTypeString();
        public string OperationString() => FirstNumber + OperationTypeString + SecondNumber;
        private string GetOperationTypeString()
        {
            switch (OperationType)
            {
                case OperationType.Addition:
                    return "+";
                case OperationType.Division:
                    return "/";
                case OperationType.Multiplication:
                    return "*";
                case OperationType.Subtraction:
                    return "-";
            }
            return string.Empty;
        }
    }
}
