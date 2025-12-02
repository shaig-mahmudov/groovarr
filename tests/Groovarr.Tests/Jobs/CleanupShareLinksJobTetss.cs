using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Groovarr.Api.Data;
using Groovarr.Api.Models;
using Groovarr.Api.Jobs;

public class CleanupShareLinksJobTests
{
    private GroovarrDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<GroovarrDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new GroovarrDbContext(options);
    }

    [Fact]
    public async Task Cleanup_RemovesExpiredLinks_AndKeepsValidLinks()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddDbContext<GroovarrDbContext>(opt =>
            opt.UseInMemoryDatabase("GroovarrTestDb"));

        var provider = services.BuildServiceProvider();

        using (var scope = provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<GroovarrDbContext>();

            db.ShareLinks.Add(new ShareLink
            {
                Id = Guid.NewGuid().ToString(),
                PlaylistId = "playlist1",
                Token = "expired-token",
                ExpiresAt = DateTime.UtcNow.AddMinutes(-10) // expired
            });

            db.ShareLinks.Add(new ShareLink
            {
                Id = Guid.NewGuid().ToString(),
                PlaylistId = "playlist2",
                Token = "valid-token",
                ExpiresAt = DateTime.UtcNow.AddMinutes(30) // still valid
            });

            db.SaveChanges();
        }

        var job = new CleanupShareLinksJob(provider);

        // Act
        // Run one iteration manually
        await job.StartAsync(CancellationToken.None);
        await Task.Delay(100); // give EF time to process
        await job.StopAsync(CancellationToken.None);

        // Assert
        using (var scope = provider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<GroovarrDbContext>();
            var links = db.ShareLinks.ToList();

            Assert.Single(links); // only one should remain
            Assert.Equal("valid-token", links.First().Token);
        }
    }
}
