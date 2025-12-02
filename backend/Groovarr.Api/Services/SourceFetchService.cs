using Groovarr.Api.Models;

namespace Groovarr.Api.Services;

// Stub: fetch songs from online sources (e.g., MusicBrainz, Spotify API, YouTube Music).
public class SourceFetchService
{
    public Task<List<SourceItem>> SearchAsync(string query, string source = "MusicBrainz")
    {
        // TODO: Implement source adapters.
        // Return demo data for now.
        var demo = new List<SourceItem>
        {
            new SourceItem { Title = "Song A", Artist = "Artist X", Source = source, ExternalId = "demo-1" },
            new SourceItem { Title = "Song B", Artist = "Artist Y", Source = source, ExternalId = "demo-2" }
        };
        return Task.FromResult(demo);
    }
}
