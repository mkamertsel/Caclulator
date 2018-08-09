using System.Collections.Generic;
using Calculator.Common.Entities;

namespace Calculator.Web.Services
{
    public interface IObserver
    {
        void Update(IEnumerable<Operation> operation);
    }
}
