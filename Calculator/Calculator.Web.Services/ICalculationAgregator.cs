using System.ServiceModel;
using Calculator.Common.Entities;

namespace Calculator.Web.Services
{
    [ServiceContract]
    public interface ICalculationAgregator
    {
        [OperationContract]
        double? ApplyCalculation(Operation operation);

        [OperationContract]
        void SetCalculationResult(Operation operation, double result);
    }
}
