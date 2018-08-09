using System;
using Calculator.Common.Entities;
using Calculator.Common.Enums;
using Calculator.Loggers;

namespace Calculator.Web.Services
{
    public class CalculationEngine : ICalculationEngine
    {
        private readonly IActivityLogger activityLogger;
        public CalculationEngine(IActivityLogger activityLogger)
        {
            this.activityLogger = activityLogger;
        }
        public double? ApplyCalculation(Operation operation)
        {
            activityLogger.Info("start calculation by calculation engine...");
            if (!IsServerAvailable())
            {
                activityLogger.Error(new Exception("Error! Calculation engine service unavaliable"));
                throw new TimeoutException();
            }
            var calculationContext = new Context();
            switch (operation.OperationType)
            {
                case OperationType.Addition:
                    activityLogger.Info("applying Addition...");
                    calculationContext.SetCalculationStrategy(new AdditionStrategy());
                    break;
                case OperationType.Division:
                    activityLogger.Info("applying Division...");
                    calculationContext.SetCalculationStrategy(new DivisionStrategy());

                    break;
                case OperationType.Multiplication:
                    activityLogger.Info("applying Multiplication...");
                    calculationContext.SetCalculationStrategy(new MultiplicationStrategy());

                    break;
                case OperationType.Subtraction:
                    activityLogger.Info("applying Subtraction...");
                    calculationContext.SetCalculationStrategy(new SubtractionStrategy());

                    break;
                default:
                    throw new ArgumentException("Invalid operation");
            }
            return calculationContext.Execute(operation.FirstNumber.Value, operation.SecondNumber.Value);
        }


        private bool IsServerAvailable()
        {
            var rand = new Random();
            return rand.Next(0, 5) != 0;
        }
    }
}
