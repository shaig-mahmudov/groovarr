using Groovarr.Api.Models;

namespace Groovarr.Api.Services;

// Placeholder for Plex auth + playlist operations.
public class PlexService
{
    public bool TryConnect(string token) => !string.IsNullOrWhiteSpace(token);

    public Task<bool> CreateOrUpdatePlaylistAsync(Playlist playlist)
    {
        // TODO: Implement Plex API calls to create/update playlist entries
        // Strategy: Resolve tracks by title/artist to library items; then write playlist.
        return Task.FromResult(true);
    }

    public Task<bool> AppendTracksAsync(string playlistId, IEnumerable<Track> tracks)
    {
        // TODO: Append tracks to an existing Plex playlist
        return Task.FromResult(true);
    }
}
