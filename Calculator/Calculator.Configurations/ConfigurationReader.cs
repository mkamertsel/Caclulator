using System;
using System.IO;

namespace Calculator.Configurations
{
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IUpdateConfiguration updateConfiguration;

        public ConfigurationReader(IUpdateConfiguration updateConfiguration)
        {
            this.updateConfiguration = updateConfiguration;
        }
        public void ReadConfiguration()
        {
            CalculatorConfigurations calcConfiguration;

            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "calc.config");

                calcConfiguration = Serializer.Deserialize<CalculatorConfigurations>(File.ReadAllText(path));
            }
            catch (Exception)
            {
                calcConfiguration = null;
            }

            updateConfiguration.Set(calcConfiguration);
        }
    }
}
