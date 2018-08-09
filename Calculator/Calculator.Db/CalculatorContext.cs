using System.Data.Entity;
using Calculator.Db.Models;

namespace Calculator.Db
{
    public class CalculatorContext : DbContext
    {
        static CalculatorContext()
        {
            Database.SetInitializer<CalculatorContext>(null);
        }
        public CalculatorContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<LogRecord> LogRecords { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("calc");

            modelBuilder.Entity<Operation>().ToTable("Operation");
            modelBuilder.Entity<LogRecord>().ToTable("Log");
        }
    }
}
