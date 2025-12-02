using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;

namespace Groovarr.Api.Controllers;

[ApiController]
[Route("api/sources")]
public class SourcesController : ControllerBase
{
    private readonly SourceFetchService _sources;

    public SourcesController(SourceFetchService sources) => _sources = sources;

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string q, [FromQuery] string source = "MusicBrainz")
    {
        var results = await _sources.SearchAsync(q, source);
        return Ok(results);
    }
}
