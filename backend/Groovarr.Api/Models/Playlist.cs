namespace Groovarr.Api.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsLinkedToPlex { get; set; }
        public string? PlexLibraryId { get; set; }

        public List<Track> Tracks { get; set; } = new();
        public List<ShareLink> ShareLinks { get; set; } = new();
    }
}
