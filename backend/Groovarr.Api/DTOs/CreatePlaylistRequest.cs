using System.ComponentModel.DataAnnotations;

namespace Groovarr.Api.DTOs
{
    public class CreatePlaylistRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
