namespace Calculator.Configurations
{
    public class Configuration : IConfiguration, IUpdateConfiguration
    {
        private static CalculatorConfigurations configuration;

        public string DbConnectionString => configuration.Db.Sql.ConnectionString;

        public int CalculatorId => configuration.App.CalculatorId;
        public int CheckingPeriod => configuration.Watcher.CheckingPeriodInMs;
        public void Set(CalculatorConfigurations calcConfiguration)
        {
            configuration = calcConfiguration;
        }
    }
}
