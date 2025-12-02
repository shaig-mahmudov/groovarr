using Groovarr.Api.Data;
using Groovarr.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Groovarr.Api.Services
{
    public class ShareService
    {
        private readonly GroovarrDbContext _dbContext;

        public ShareService(GroovarrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShareLink CreateShareLink(int playlistId)
        {
            var playlist = _dbContext.Playlists
                .Include(p => p.Tracks) // optional, if you want tracks loaded
                .FirstOrDefault(p => p.Id == playlistId);

            if (playlist == null)
            {
                throw new ArgumentException($"Playlist with ID {playlistId} not found.");
            }

            var link = new ShareLink
            {
                PlaylistId = playlist.Id,          // ✅ required property set
                Playlist = playlist,               // ✅ required property set
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            _dbContext.ShareLinks.Add(link);
            _dbContext.SaveChanges();

            return link;
        }
        public Playlist? GetSharedPlaylist(string token)
        {
            var link = _dbContext.ShareLinks
                .Include(l => l.Playlist)
                .ThenInclude(p => p.Tracks)
                .FirstOrDefault(l => l.Token == token && l.ExpiresAt > DateTime.UtcNow);

            return link?.Playlist;
        }
    }
}
