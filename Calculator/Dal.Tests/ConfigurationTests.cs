using System;
using System.IO;
using Calculator.Configurations;
using NUnit.Framework;

namespace Dal.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void ReadDefault()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "calc.config");

            var configuration = Serializer.Deserialize<CalculatorConfigurations>(File.ReadAllText(path));

            Assert.AreNotEqual(configuration, null);
        }
    }
}
