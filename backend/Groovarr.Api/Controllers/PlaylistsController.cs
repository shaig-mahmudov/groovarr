using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;
using Groovarr.Api.Models;

namespace Groovarr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly PlaylistService _service;

        public PlaylistsController(PlaylistService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var playlist = _service.Get(id);
            return playlist == null ? NotFound() : Ok(playlist);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Playlist playlist)
        {
            _service.Create(playlist);
            return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
