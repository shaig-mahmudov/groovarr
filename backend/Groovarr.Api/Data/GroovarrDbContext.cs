using Microsoft.EntityFrameworkCore;
using Groovarr.Api.Models;

namespace Groovarr.Api.Data
{
    public class GroovarrDbContext : DbContext
    {
        public GroovarrDbContext(DbContextOptions<GroovarrDbContext> options) : base(options) { }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<ShareLink> ShareLinks { get; set; }
        public DbSet<PlexToken> PlexTokens { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
