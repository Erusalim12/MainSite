using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.Counters;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.BackgroundTask
{
    public class UpdateCountersInDb : BackgroundService
    {

        private readonly IServiceScopeFactory _factory;
#if RELEASE
        const int interval = 60 * 60 * 1000;
#else
        const int interval = 5 * 1000; //every 5 sec
#endif
        public UpdateCountersInDb(IServiceScopeFactory factory)
        {
            _factory = factory;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _factory.CreateScope();
            var service = scope.ServiceProvider.GetService<CountersService>();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(interval, stoppingToken);
                service.SaveCounters();
                Console.WriteLine("Counters has been saved!");
          
            }
        }
    }
}