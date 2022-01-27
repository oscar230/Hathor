using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private readonly List<ITrackRepositoryService> _trackRepositoryServices;

        public TrackController(ILogger<TrackController> logger, ISliderTrackRepositoryService sliderTrackRepositoryService)
        {
            _logger = logger;
            _trackRepositoryServices = new List<ITrackRepositoryService>();
            _trackRepositoryServices.Add(sliderTrackRepositoryService);
        }

        [HttpGet("Download")]
        public async Task<ActionResult> Download([FromQuery] Guid repositoryGuid, [FromQuery] string downloadUriBase64)
        {
            const string contentType = "audio/mpeg";
            var repository = _trackRepositoryServices.Find(r => r.Repository.Guid.Equals(repositoryGuid));
            if (repository != null)
            {
                Uri uri;
                try
                {
                    var downloadUriAsString = Base64Helper.Decode(downloadUriBase64);
                    uri = new Uri(downloadUriAsString);
                }
                catch (Exception)
                {
                    return BadRequest("The download uri was badly formatted.");
                }
                return File(await repository.GetTrackAsFile(uri), contentType);
            }
            else
            {
                return BadRequest($"The repository does not exist. (from guid: {repositoryGuid})");
            }
        }
    }
}
