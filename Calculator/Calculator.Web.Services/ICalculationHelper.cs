using System.ServiceModel;
using Calculator.Common.Entities;

namespace Calculator.Web.Services
{
    [ServiceContract]
    public interface ICalculationHelper
    {
        [OperationContract]
        void AddOperationToQueue(Operation operation);
    }
}
