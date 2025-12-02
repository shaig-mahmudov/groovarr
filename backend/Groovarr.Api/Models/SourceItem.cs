namespace Groovarr.Api.Models
{
    public class SourceItem
    {
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string Source { get; set; }
        public required string ExternalId { get; set; }
    }
}
