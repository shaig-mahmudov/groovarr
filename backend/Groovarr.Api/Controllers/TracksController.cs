using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;
using Groovarr.Api.Models;

namespace Groovarr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly PlaylistService _service;

        public TracksController(PlaylistService service) => _service = service;

        [HttpPost("{playlistId}")]
        public IActionResult AddTrack(int playlistId, [FromBody] Track track)
        {
            var added = _service.AddTrack(playlistId, track);
            return added ? Ok(track) : NotFound();
        }
    }
}
