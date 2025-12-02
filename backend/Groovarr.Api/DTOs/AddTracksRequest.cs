using System.ComponentModel.DataAnnotations;

namespace Groovarr.Api.DTOs
{
    public class AddTracksRequest
    {
        [Required]
        public string PlaylistId { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "At least one track must be provided.")]
        public List<string> TrackIds { get; set; } = new();
    }
}
