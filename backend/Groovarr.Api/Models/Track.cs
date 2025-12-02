namespace Groovarr.Api.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public int? Year { get; set; }
        public string? Source { get; set; }
        public string? ExternalId { get; set; }

        public required int PlaylistId { get; set; }
        public required Playlist Playlist { get; set; }
    }
}
