using System.Collections.Generic;
using System.Linq;
using Calculator.Common.Entities;
using Calculator.Configurations;
using Calculator.Dal.Mappers;
using Calculator.Db;
namespace Calculator.Dal.Repository
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IMapper<Operation, Db.Models.Operation> dbOperationMapper;
        private readonly IMapper<Db.Models.Operation, Operation> dtoOperationMapper;
        private readonly IConfiguration configuration;

        public QueueRepository(IConfiguration configuration,
            IMapper<Operation, Db.Models.Operation> dbOperationMapper,
            IMapper<Db.Models.Operation, Operation> dtoOperationMapper)
        {
            this.configuration = configuration;
            this.dbOperationMapper = dbOperationMapper;
            this.dtoOperationMapper = dtoOperationMapper;
        }

        public void AddToQueue(Operation operation)
        {
            using (var db = new CalculatorContext(configuration.DbConnectionString))
            {
                var dbOperation = dbOperationMapper.Map(operation);
                dbOperation.CalculatorId = configuration.CalculatorId;
                db.Operations.Add(dbOperation);
                db.SaveChanges();
            }
        }

        public void RemoveOperationFromQueueByOperationId(int operationId)
        {
            using (var db = new CalculatorContext(configuration.DbConnectionString))
            {
                var dbOperation = db.Operations.FirstOrDefault(x => x.OperationId == operationId);
                if (dbOperation == null)
                {
                    return;
                }
                db.Operations.Remove(dbOperation);
                db.SaveChanges();
            }
        }

        public List<Operation> GetQueue()
        {
            using (var db = new CalculatorContext(configuration.DbConnectionString))
            {
                return db.Operations.AsNoTracking().OrderBy(q => q.OperationId)
                    .ToArray().Select(source => dtoOperationMapper.Map(source)).ToList();
            }
        }
    }
}
