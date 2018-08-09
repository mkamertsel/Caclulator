using System;

namespace Calculator.Loggers
{
    public interface IActivityLogger
    {
        void Error(Exception exception);
        void Info(string message);
    }
}
