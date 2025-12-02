using Microsoft.AspNetCore.Mvc;
using Groovarr.Api.Services;

namespace Groovarr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditController : ControllerBase
    {
        private readonly AuditService _service;

        public AuditController(AuditService service) => _service = service;

        [HttpGet]
        public IActionResult GetLogs() => Ok(_service.GetRecentLogs());
    }
}
