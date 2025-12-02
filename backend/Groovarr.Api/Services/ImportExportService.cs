using Groovarr.Api.Models;
using System.Collections.Generic;

namespace Groovarr.Api.Services
{
    public class ImportExportService
    {
        public List<Track> ImportPlaylist(Playlist playlist, IEnumerable<(string Title, string Artist)> tracks)
        {
            var importedTracks = new List<Track>();

            foreach (var (title, artist) in tracks)
            {
                // ✅ Required property Playlist is set here
                var track = new Track
                {
                    PlaylistId = playlist.Id,
                    Title = title,
                    Artist = artist,
                    Playlist = playlist
                };

                importedTracks.Add(track);
            }

            return importedTracks;
        }

        public void ExportPlaylist(Playlist playlist)
        {
            // Example export logic
            foreach (var track in playlist.Tracks)
            {
                // Write out or serialize track info
                System.Console.WriteLine($"{track.Title} by {track.Artist}");
            }
        }
    }
}
