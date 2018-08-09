using System;
using NLog;

namespace Calculator.Loggers
{
    public class ActivityLogger : IActivityLogger
    {
        private readonly Logger logger;

        public ActivityLogger()
        {
            logger = LogManager.GetLogger("activityLogger");
        }

        public void Error(Exception exception)
        {
            logger.Error(exception);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
    }

}
