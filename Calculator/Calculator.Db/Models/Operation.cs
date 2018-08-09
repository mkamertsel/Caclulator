using Calculator.Common.Enums;

namespace Calculator.Db.Models
{
    public class Operation
    {
        public int OperationId { get; set; }
        public int CalculatorId { get; set; }
        public OperationType OperationType { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
    }
}