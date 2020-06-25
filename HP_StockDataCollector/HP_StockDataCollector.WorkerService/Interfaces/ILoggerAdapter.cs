using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.WorkerService.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string msg, params object[] args);
        void LogError(Exception ex, string msg, params object[] args);

    }

}
