using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Groovarr.Api.Data;

namespace Groovarr.Api.Jobs
{
    public class CleanupShareLinksJob : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly TimeSpan _interval = TimeSpan.FromHours(1);

        public CleanupShareLinksJob(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_interval, stoppingToken);

                using var scope = _services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<GroovarrDbContext>();

                var now = DateTime.UtcNow;
                var expiredLinks = db.ShareLinks.Where(s => s.ExpiresAt < now).ToList();

                if (expiredLinks.Any())
                {
                    db.ShareLinks.RemoveRange(expiredLinks);
                    await db.SaveChangesAsync(stoppingToken);
                }
            }
        }
    }
}