namespace Calculator.Web.Services
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}