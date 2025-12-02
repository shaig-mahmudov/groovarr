using System;

namespace Groovarr.Api.Models
{
    public class ShareLink
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string Id { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        // ✅ Required foreign key to Playlist
        public required int PlaylistId { get; set; }

        // ✅ Required navigation property
        public required Playlist Playlist { get; set; }

        // Unique token for the share link
        public string Token { get; set; } = string.Empty;

        // Expiration timestamp for cleanup job
        public DateTime ExpiresAt { get; set; }
    }
}
