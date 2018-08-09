using System.ServiceModel;
using Calculator.Common.Entities;

namespace Calculator.Web.Services
{
    [ServiceContract]
    public interface ICalculationEngine
    {
        [OperationContract]
        double? ApplyCalculation(Operation operation);
    }
}
