using Calculator.Common.Entities;

namespace Calculator.Web.Services
{
    public interface IResultSenderService
    {
        void SendResultByEmail(Operation operation, double? result);
    }
}
