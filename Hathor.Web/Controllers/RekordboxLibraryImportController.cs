using Hathor.Web.Pages;
using Hathor.Web.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;
using System.Web;
using Hathor.Web.Models.Rekordbox;
using Microsoft.Extensions.DependencyModel;

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
        //[ValidateAntiForgeryToken]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Consumes("application/xml", "text/xml")]
        public ActionResult Post()
        {
            if (Request.Form.Files.Any())
            {
                IFormFile file = Request.Form.Files.First();
                try
                {
                    _rekordboxService.AddLibrary(file);
                    return Ok();
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Failed to upload file {file.FileName}";
                    _logger.LogWarning(ex, errorMessage);
                    return BadRequest(errorMessage);
                }
            }
            else
            {
                return BadRequest("No file");
            }
        }
        //public ActionResult Upload(HttpRequest request)
        //{
        //    if (request.Form.Files.Any())
        //    {
        //        int uploadedFiles = request.Form.Files.Count;
        //        foreach (IFormFile file in request.Form.Files)
        //        {
        //            try
        //            {
        //                _rekordboxService.AddLibrary(file);
        //            }
        //            catch (Exception ex)
        //            {
        //                _logger.LogWarning(ex, $"File upload of {file.FileName} failed");
        //                uploadedFiles -= 1;
        //            }
        //        }
        //        if (request.Form.Files.Count == uploadedFiles)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            return BadRequest($"{uploadedFiles} files uploaded succesfully and {request.Form.Files.Count - uploadedFiles} uploads failed");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("No or incorrect data provided");
        //    }
        //}
    }
}
