using Calculator.Common.Entities;
using Calculator.Loggers;

namespace Calculator.Web.Services
{
    public class ResultSenderService : IResultSenderService
    {
        private readonly IActivityLogger activityLogger;
        public ResultSenderService(IActivityLogger logger)
        {
            activityLogger = logger;
        }
        public void SendResultByEmail(Operation operation, double? result)
        {
            activityLogger.Info($"SendResultByEmail: your operation '{operation.OperationString()}' was calculated, result = {result}");
        }
    }
}