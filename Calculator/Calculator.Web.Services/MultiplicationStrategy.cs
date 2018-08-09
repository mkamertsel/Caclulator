namespace Calculator.Web.Services
{
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}