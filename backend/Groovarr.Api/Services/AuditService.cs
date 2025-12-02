using Groovarr.Api.Data;
using Groovarr.Api.Models;

namespace Groovarr.Api.Services
{
    public class AuditService
    {
        private readonly GroovarrDbContext _db;
        public AuditService(GroovarrDbContext db) => _db = db;

        public void Log(string action, string? userId = null, string? playlistId = null, string? token = null)
        {
            var log = new AuditLog
            {
                Action = action,
                UserId = userId,
                PlaylistId = playlistId,
                ShareLinkToken = token,
                IpAddress = null
            };
            _db.AuditLogs.Add(log);
            _db.SaveChanges();
        }

        public IEnumerable<AuditLog> GetRecentLogs() =>
            _db.AuditLogs.OrderByDescending(l => l.Timestamp).Take(100).ToList();
    }
}
