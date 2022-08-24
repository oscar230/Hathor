using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Hathor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    //[Authorize]
    public class RekordboxLibraryController : ControllerBase
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UploadLibraries([FromForm] IFormFile file)
        {
            long size = file.Length;

            if (file.Length.Equals(0))
            {
                return BadRequest("File is of zero size.");
            }
            else
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok($"Uploaded file of size {size}");
            }
        }
    }
}
