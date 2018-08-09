namespace Calculator.Web.Services
{
    public class Context
    {
        private ICalculationStrategy strategy;

        public void SetCalculationStrategy(ICalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public double Execute(double firstNumber, double secondNumber)
        {
            return strategy.Execute(firstNumber, secondNumber);
        }
    }
}