using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using Quartz;
using Microsoft.Extensions.Logging;

namespace CSGO
{
    [DisallowConcurrentExecution]
    public class DataJob : IJob
    {
        private readonly ILogger<DataJob> _logger;
        public DataJob(ILogger<DataJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            Debug.WriteLine("Hello world!");
            return Task.CompletedTask;
        }
    }
}