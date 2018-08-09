using Calculator.Common.Entities;

namespace Calculator.Dal.Mappers.DtoToDb
{
    public class OperationMapper : IMapper<Operation, Db.Models.Operation>
    {
        public Db.Models.Operation Map(Operation source)
        {
            if (source == null)
            {
                return null;
            }

            return new Db.Models.Operation
            {
                CalculatorId = source.CalculatorId,
                FirstNumber = source.FirstNumber.Value,
                SecondNumber = source.SecondNumber.Value,
                OperationType = source.OperationType,
                OperationId = source.OperationId
            };
        }
    }
}
