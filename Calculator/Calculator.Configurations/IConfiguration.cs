namespace Calculator.Configurations
{
    public interface IConfiguration
    {
        string DbConnectionString { get; }
        int CalculatorId { get; }
        int CheckingPeriod { get; }
    }
}