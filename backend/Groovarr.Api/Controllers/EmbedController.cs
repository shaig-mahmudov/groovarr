using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;

namespace Groovarr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbedController : ControllerBase
    {
        private readonly PlaylistService _playlistService;

        public EmbedController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        // GET api/embed/{playlistId}
        [HttpGet("{playlistId}")]
        public IActionResult GetEmbed(string playlistId)
        {
            var playlist = _playlistService.Get(playlistId);
            if (playlist == null)
                return NotFound();

            // Return JSON payload only
            return Ok(new
            {
                playlist.Id,
                playlist.Name,
                playlist.Description,
                Tracks = playlist.Tracks.Select(t => new
                {
                    t.Title,
                    t.Artist,
                    t.Album,
                    t.Year
                })
            });
        }
    }
}
