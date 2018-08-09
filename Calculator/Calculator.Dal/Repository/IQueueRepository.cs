using System.Collections.Generic;
using Calculator.Common.Entities;

namespace Calculator.Dal.Repository
{
    public interface IQueueRepository
    {
        void AddToQueue(Operation operation);
        void RemoveOperationFromQueueByOperationId(int operationId);
        List<Operation> GetQueue();
    }
}
