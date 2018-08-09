namespace Calculator.Web.Services
{
    public class AdditionStrategy : ICalculationStrategy
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}