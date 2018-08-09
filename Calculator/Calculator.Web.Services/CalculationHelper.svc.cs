using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Calculator.Common.Entities;
using Calculator.Configurations;
using Calculator.Dal.Repository;
using Calculator.Loggers;
using Calculator.Web.Services.CalculationEngineServices;

namespace Calculator.Web.Services
{
    public class CalculationHelper : ICalculationHelper, IObserver
    {
        private readonly IActivityLogger activityLogger;
        private readonly IConfiguration configuration;
        private readonly IQueueRepository repository;
        private readonly ICalculationAgregator calculationAgregator;
        private readonly IQueueWatcher queueWatcher;

        public CalculationHelper(IActivityLogger activityLogger,
            IQueueRepository repository,
            IConfiguration configuration,
            ICalculationAgregator calculationAgregator,
            IQueueWatcher queueWatcher)
        {
            this.activityLogger = activityLogger;
            this.repository = repository;
            this.configuration = configuration;
            this.calculationAgregator = calculationAgregator;
            this.queueWatcher = queueWatcher;
        }

        public void AddOperationToQueue(Operation operation)
        {
            activityLogger.Info("Add operation to Queue");
            repository.AddToQueue(operation);
            queueWatcher.AddWatcherUser(this);
        }

        private double? TryCalculate(Operation operation)
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
                activityLogger.Info("Timeout Error! Calculation Engine is anavailable ");
                activityLogger.Error(ex);
                client.Abort();
            }
            catch (Exception ex)
            {
                activityLogger.Info("Unknown Error!");
                activityLogger.Error(ex);

                client.Abort();
            }

            return result;
        }

        private void SendResult(Operation operation, double result)
        {
            calculationAgregator.SetCalculationResult(operation, result);
        }

        public void Update(IEnumerable<Operation> queue)
        {
            activityLogger.Info("Operations in the queue are found");

            foreach (var operation in queue)
            {
                var calcResult = TryCalculate(operation);
                if (calcResult == null)
                {
                    continue;
                }
                repository.RemoveOperationFromQueueByOperationId(operation.OperationId);
                SendResult(operation, calcResult.Value);
            }
        }
    }
}