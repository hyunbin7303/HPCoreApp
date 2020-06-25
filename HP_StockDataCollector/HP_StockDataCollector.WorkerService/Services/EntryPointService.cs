using HP_StockDataCollector.WorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP_StockDataCollector.WorkerService.Services
{
    public class EntryPointService : IEntryPointService
    {

        private readonly ILoggerAdapter<EntryPointService> _logger;
        public EntryPointService(ILoggerAdapter<EntryPointService> logger)
        {
            _logger = logger;
        }

        public async Task ExecAsync()
        {
                _logger.LogInformation("{service} Worker running at: {time}", nameof(EntryPointService), DateTimeOffset.Now);
        }

    }
}
