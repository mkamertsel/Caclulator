namespace Calculator.Web.Services
{
    public interface ICalculationStrategy
    {
        double Execute(double firstNumber, double secondNumber);
    }
}
