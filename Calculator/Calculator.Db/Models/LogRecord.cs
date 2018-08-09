using System;

namespace Calculator.Db.Models
{
    public class LogRecord
    {
        public int LogRecordId { get; set; }
        public string Message { get; set; }
        public DateTime OperationTime { get; set; }
        public string MessageSource { get; set; }
        public string StackTrace { get; set; }
    }
}