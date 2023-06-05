using Hathor.Web.Models.Rekordbox;
using Hathor.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hathor.Web.Controllers
{
    [ApiController]
    [Route("RekordboxLibrary")]
    public class RekordboxLibraryImportController : ControllerBase
    {
        private readonly ILogger<RekordboxLibraryImportController> _logger;
        private readonly RekordboxService _rekordboxService;

        public RekordboxLibraryImportController(ILogger<RekordboxLibraryImportController> logger, RekordboxService rekordboxService)
        {
            _logger = logger;
            _rekordboxService = rekordboxService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/xml", "text/xml")]
        public ActionResult Post()
        {
            foreach (var file in Request.Form.Files)
            {
                Library? library = null;

                try
                {
                    library = _rekordboxService.ParseAndAdd(file);
                }
                catch (Exception)
                {
                    return StatusCode(500, "An unexpected problem accoured");
                }

                if (library is not null)
                {
                    return Ok(library);
                }
                else
                {
                    return BadRequest("Could not parse the library");
                }
            }
            return BadRequest("No files supplied in the request");
        }
    }
}
