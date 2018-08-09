using System.Data.Entity;

namespace Calculator.Db
{
    public class CalculatorDbConfiguration : DbConfiguration
    {
        public CalculatorDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}
