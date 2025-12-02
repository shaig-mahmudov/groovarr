using System.ComponentModel.DataAnnotations;

namespace Groovarr.Api.DTOs
{
    public class ImportPlaylistRequest
    {
        [Required]
        [Url]
        public string SourceUrl { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(m3u|json)$", ErrorMessage = "Format must be 'm3u' or 'json'.")]
        public string Format { get; set; } = string.Empty;
    }
}
