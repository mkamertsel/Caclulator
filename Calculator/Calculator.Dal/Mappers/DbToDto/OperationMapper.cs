using Calculator.Common.Entities;

namespace Calculator.Dal.Mappers.DbToDto
{
    public class OperationMapper : IMapper<Db.Models.Operation, Operation>
    {
        public Operation Map(Db.Models.Operation source)
        {
            if (source == null)
            {
                return null;
            }

            return new Operation
            {
                CalculatorId = source.CalculatorId,
                OperationId = source.OperationId,
                FirstNumber = source.FirstNumber,
                SecondNumber = source.SecondNumber,
                OperationType = source.OperationType
            };
        }
    }
}
