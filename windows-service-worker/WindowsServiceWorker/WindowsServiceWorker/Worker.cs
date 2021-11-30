using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WindowsServiceWorker.Configuration;

namespace WindowsServiceWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ApplicationOptions _applicationOptions;
        private readonly CustomOptions _customOptions;

        public Worker(ILogger<Worker> logger, IOptions<ApplicationOptions> applicationOptions,
            IOptions<CustomOptions> customOptions,
            IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
            _applicationOptions = applicationOptions.Value;
            _customOptions = customOptions.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var delayedStoppingTask = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(_customOptions.StopAfterSeconds), stoppingToken);
                _logger.LogCritical("Application shutdown");
                _applicationLifetime.StopApplication();
            }, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}",
                    DateTimeOffset.Now.ToString(_applicationOptions.DateFormat));
                for (var i = 0; i < _customOptions.RepeatTimes; ++i)
                {
                    await Task.Delay(TimeSpan.FromSeconds(_customOptions.SecondsDelay), stoppingToken);
                    _logger.LogDebug("Debug in loop at: {time}",
                        DateTimeOffset.Now.ToString(_applicationOptions.DateFormat));
                }
            }
        }
    }
}