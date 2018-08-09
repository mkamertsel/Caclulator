using System;
using System.ServiceModel;
using Calculator.Common.Entities;
using Calculator.Loggers;
using Calculator.Web.Services.CalculationEngineServices;
using Calculator.Web.Services.CalculationHelperServices;

namespace Calculator.Web.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single,
       IncludeExceptionDetailInFaults = true)]
    public class CalculationAgregator : ICalculationAgregator
    {
        private readonly IActivityLogger activityLogger;
        private readonly IResultSenderService resultSenderService;

        public CalculationAgregator(IActivityLogger activityLogger, IResultSenderService resultSenderService)
        {
            this.activityLogger = activityLogger;
            this.resultSenderService = resultSenderService;
        }

        public double? ApplyCalculation(Operation operation)
        {
            activityLogger.Info($"start calculation with operation: '{operation.OperationString()}'...calling calculation engine..");
            var result = Calculate(operation);
            if (result == null)
            {
                activityLogger.Info("result is empty..adding operation to queue..");

                AddOperationToQueue(operation);
            }
            else
            {
                activityLogger.Info($"result = '{result}' is recieved..sending result to UI..");
            }

            return result;
        }

        public void SetCalculationResult(Operation operation, double result)
        {
            activityLogger.Info($"result = '{result}' is recieved..sending result to email..");

            resultSenderService.SendResultByEmail(operation, result);
        }

        private double? Calculate(Operation operation)
        {
            var client = new CalculationEngineClient();
            double? result = null;
            try
            {
                result = client.ApplyCalculation(operation);
                client.Close();
            }
            catch (TimeoutException ex)
            {
                activityLogger.Error(ex);
                activityLogger.Info("Timeout Error! Calculation Engine is anavailable.");
                client.Abort();
            }
            catch (Exception ex)
            {
                activityLogger.Error(ex);
                activityLogger.Info("Unknown Error!");

                client.Abort();
            }

            return result;
        }

        private void AddOperationToQueue(Operation operation)
        {
            var helper = new CalculationHelperClient();
            try
            {
                helper.AddOperationToQueue(operation);
            }
            catch (Exception ex)
            {
                activityLogger.Error(ex);
                activityLogger.Info("Unknown Error! ");

                helper.Abort();
            }
        }
    }
}
