using System.Diagnostics;
using System.Text.Json;
using System.Web;
using WebApi.Exceptions;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Models.Common;
using WebApi.Models.Slider;

namespace WebApi.Services.TrackRepositoryServices
{
    public class SliderTrackRepositoryService : ITrackRepositoryService
    {
        public const string DIRECT_SLIDER_HTTP_CLIENT_NAME = "DirectSliderKzHttpClient";
        public const string PROXIED_SLIDER_HTTP_CLIENT_NAME = "ProxiedSliderKzHttpClient";

        private readonly ILogger<SliderTrackRepositoryService> _logger;
        private readonly HttpClient _httpClientDirectSlider;
        private readonly HttpClient _httpClientProxiedSlider;
        private readonly UserAgentService _userAgentService;
        private readonly DbService _dbService;

        public SliderTrackRepositoryService(ILogger<SliderTrackRepositoryService> logger, IHttpClientFactory httpClientFactory, UserAgentService userAgentService, DbService dbService)
        {
            _logger = logger;
            _httpClientDirectSlider = httpClientFactory.CreateClient(DIRECT_SLIDER_HTTP_CLIENT_NAME);
            _httpClientProxiedSlider = httpClientFactory.CreateClient(PROXIED_SLIDER_HTTP_CLIENT_NAME);
            _userAgentService = userAgentService;
            _dbService = dbService;
        }

        public Repository Repository => RepositoryHelper.GetSliderRepository;

        public async Task<Stream> StreamTrackFile(Uri uri, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            httpRequestMessage.Headers.Add("Accept", "audio/mpeg");
            httpRequestMessage.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            httpRequestMessage.Headers.Add("Accept-Language", "en-US");
            httpRequestMessage.Headers.Add("Connection", "keep-alive");
            httpRequestMessage.Headers.Add("Host", "slider.kz");
            httpRequestMessage.Headers.Add("Upgrade-Insecure-Requests", "1");
            httpRequestMessage.Headers.Add("User-Agent", _userAgentService.RandomOne());
            stopWatch.Start();
            using (var httpResponseMessage = await _httpClientDirectSlider.SendAsync(httpRequestMessage))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    _logger.LogDebug($"Stream track file took {ts.TotalSeconds} seconds (total {ts.Milliseconds} ms).");
                }
                else
                {
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    _logger.LogWarning($"Stream track file failed! uri: {httpRequestMessage.RequestUri}, status: {httpResponseMessage.StatusCode} ({((int)httpResponseMessage.StatusCode)}), took {ts.TotalSeconds} seconds.");
                }
            }
            throw new TrackStreamTrackFileRepositoryException(uri);
        }

        public async Task<IEnumerable<Track>> Query(string? query)
        {
            var stopWatch = new Stopwatch();
            HttpRequestMessage httpRequestMessage;
            if (query == null)
            {
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, string.Empty);
            }
            else
            {
                query = HttpUtility.UrlEncode(query);
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query);
            }
            stopWatch.Start();
            using (var httpResponseMessage = await _httpClientProxiedSlider.SendAsync(httpRequestMessage))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    var sliderTrackQueryResult = JsonSerializer.Deserialize<SliderTrackQueryResult>(content);
                    if (sliderTrackQueryResult?.SliderTrackList?.SliderTracks?.Count() > 0 && sliderTrackQueryResult?.SliderTrackList?.SliderTracks?.FirstOrDefault()?.Id is not null)
                    {
                        stopWatch.Stop();
                        var ts = stopWatch.Elapsed;
                        _logger.LogDebug($"Query took {ts.TotalSeconds} seconds (total {ts.Milliseconds} ms).");
                        var sliderTracks = sliderTrackQueryResult.SliderTrackList.SliderTracks;
                        _dbService.AddSliderTracks(sliderTracks);
                        return sliderTracks.Select(sliderTrack => new Track(sliderTrack));
                    }
                }
                else
                {
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    _logger.LogWarning($"Query failed! uri: {httpRequestMessage.RequestUri}, status: {httpResponseMessage.StatusCode} ({((int)httpResponseMessage.StatusCode)}), took {ts.TotalSeconds} seconds.");
                }
            }
            throw new TrackQueryNotFoundInThisRepositoryException(query, Repository);
        }
    }
}
