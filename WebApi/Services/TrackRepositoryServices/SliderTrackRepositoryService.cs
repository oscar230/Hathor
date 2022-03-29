using Flurl.Http;
using Flurl.Http.Configuration;
using HathorCommon.Models;
using System.Web;
using WebApi.Exceptions;
using WebApi.Extensions;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Models.Slider;

namespace WebApi.Services.TrackRepositoryServices
{
    public class SliderTrackRepositoryService : ITrackRepositoryService
    {
        private const string BASE_URL = "https://slider.kz/";
        private readonly ILogger<SliderTrackRepositoryService> _logger;
        private readonly IFlurlClient _flurlClient;
        private readonly UserAgentService _userAgentService;

        public SliderTrackRepositoryService(ILogger<SliderTrackRepositoryService> logger, IFlurlClientFactory flurlClientFactory, UserAgentService userAgentService)
        {
            _logger = logger;
            _flurlClient = flurlClientFactory.Get(BASE_URL);
            _userAgentService = userAgentService;
        }

        public Repository Repository => RepositoryHelper.GetSliderRepository;

        public async Task<Stream> StreamTrackFile(Uri uri, CancellationToken cancellationToken)
        {
            Stream stream = await _flurlClient.Request(uri).AtSlider(_userAgentService).GetStreamAsync(cancellationToken);
            if (stream is not null && !stream.Length.Equals(0))
            {
                return stream;
            }
            throw new TrackStreamTrackFileRepositoryException(uri);
        }

        public async Task<IEnumerable<Track>> Query(string? query)
        {
            string pathAndQuery = $"vk_auth.php?q={HttpUtility.UrlEncode(query)}";
            SliderTrackQueryResult trackQueryResult = await _flurlClient.Request(pathAndQuery).AtSlider(_userAgentService).Deserialize<SliderTrackQueryResult>(logger: _logger);
            if (trackQueryResult is not null && trackQueryResult.SliderTrackList is not null && trackQueryResult.SliderTrackList.SliderTracks is not null && trackQueryResult.SliderTrackList.SliderTracks.Any()) 
            {
                IEnumerable<Track> tracks = trackQueryResult.SliderTrackList.SliderTracks.Select(sliderTrack => new Track(sliderTrack));
                _logger.LogDebug($"Slider query found {tracks.Count()} tracks for query {query}.");
                return tracks;
            }
            throw new TrackQueryNotFoundInThisRepositoryException(query, Repository);
        }
    }
}
