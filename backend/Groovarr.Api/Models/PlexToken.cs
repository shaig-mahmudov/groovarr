namespace Groovarr.Api.Models
{
    public class PlexToken
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
    }
}
