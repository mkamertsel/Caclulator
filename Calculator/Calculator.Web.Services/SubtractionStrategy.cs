namespace Calculator.Web.Services
{
    public class SubtractionStrategy : ICalculationStrategy
    {
        public double Execute(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}