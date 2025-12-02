namespace Groovarr.Api.Models
{
    public class AuditLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Action { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public string? PlaylistId { get; set; }
        public string? ShareLinkToken { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }
    }
}
