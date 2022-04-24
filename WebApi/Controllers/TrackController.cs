using Hathor.Api.Exceptions;
using Hathor.Api.Services.TrackRepositoryServices;
using Hathor.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Hathor.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private readonly List<ITrackRepositoryService> _trackRepositoryServices;

        public TrackController(ILogger<TrackController> logger, SliderTrackRepositoryService sliderTrackRepositoryService)
        {
            _logger = logger;
            _trackRepositoryServices = new List<ITrackRepositoryService>();
            _trackRepositoryServices.Add(sliderTrackRepositoryService);
        }

        [HttpGet("Download"), DisableRequestSizeLimit]
        public async Task<ActionResult<HttpResponseMessage>> Download([FromQuery] Guid repositoryGuid, [FromQuery] string downloadUriBase64)
        {   
            var cancellationToken = new CancellationToken();
            var repository = _trackRepositoryServices.Find(r => r.Repository.Guid.Equals(repositoryGuid));
            if (repository != null)
            {
                Uri uri;
                try
                {
                    var downloadUriAsString = Base64Helper.Decode(downloadUriBase64);
                    uri = new Uri(downloadUriAsString);
                }
                catch (TrackStreamTrackFileRepositoryException ex)
                {
                    _logger.LogDebug($"{ex}");
                    return NotFound(ex.UserMessage);
                }
                catch (Exception)
                {
                    return BadRequest("The download uri was badly formatted.");
                }
                var httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage.Content = new StreamContent(await repository.StreamTrackFile(uri, cancellationToken));
                httpResponseMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");
                httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = $"{DateTime.Now}.mp3";
                return Ok(httpResponseMessage);
            }
            else
            {
                return BadRequest($"The repository does not exist. (from guid: {repositoryGuid})");
            }
        }
    }
}
