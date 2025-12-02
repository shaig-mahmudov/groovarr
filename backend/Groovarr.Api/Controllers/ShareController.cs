using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;

namespace Groovarr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShareController : ControllerBase
    {
        private readonly ShareService _service;

        public ShareController(ShareService service)
        {
            _service = service;
        }

        [HttpPost("{playlistId}")]
        public IActionResult CreateShareLink(int playlistId)
        {
            try
            {
                var link = _service.CreateShareLink(playlistId);
                return Ok(link);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{token}")]
        public IActionResult GetSharedPlaylist(string token)
        {
            var playlist = _service.GetSharedPlaylist(token);
            return playlist == null ? NotFound() : Ok(playlist);
        }
    }
}
