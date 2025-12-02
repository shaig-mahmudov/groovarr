using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Groovarr.Api.Services.Jobs
{
    public class CleanupShareLinksJob : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // TODO: implement cleanup logic
                Console.WriteLine("Cleaning up expired share links...");

                // Run every hour
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
