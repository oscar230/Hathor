using System.Diagnostics;
using System.Text.Json;
using System.Web;
using WebApi.Exceptions;
using WebApi.Models;
using WebApi.Models.Slider;

namespace WebApi.Services
{
    public class SliderTrackRepositoryService : ISliderTrackRepositoryService
    {
        private const string SLIDER_API_QUERY = "https://slider.wonky.se/";
        private readonly ILogger<SliderTrackRepositoryService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IUserAgentService _userAgentService;

        public SliderTrackRepositoryService(ILogger<SliderTrackRepositoryService> logger, HttpClient httpClient, IUserAgentService userAgentService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _userAgentService = userAgentService;
            _logger.LogDebug($"SliderTrackRepositoryService constructed, got HttpClient with timeout of {_httpClient.Timeout.Seconds} seconds.");
            var a = _userAgentService.RandomOne();
        }

        public IRepository Repository => new SliderRepository();

        public Task<byte[]> GetTrackAsFile(Uri uri)
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
            return null;
        }

        public async Task<List<ITrack>> Query(string? query)
        {
            var stopWatch = new Stopwatch();
            query = query ?? string.Empty;
            query = HttpUtility.UrlEncode(query);
            var uri = new Uri($"{SLIDER_API_QUERY}{query}");
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            stopWatch.Start();
            using (var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage))
            {
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    var tracks = JsonSerializer.Deserialize<SliderTrackQueryResult>(content);
                    if (tracks?.SliderTrackList?.SliderTracks?.Count > 0 && tracks?.SliderTrackList?.SliderTracks?.FirstOrDefault()?.SliderId != null)
                    {
                        stopWatch.Stop();
                        var ts = stopWatch.Elapsed;
                        _logger.LogDebug($"Query took {ts.TotalSeconds} seconds (total {ts.Milliseconds} ms).");
                        return tracks.SliderTrackList.SliderTracks.ToList<ITrack>();
                    }
                }
                else
                {
                    stopWatch.Stop();
                    var ts = stopWatch.Elapsed;
                    _logger.LogWarning($"Query failed! uri: {uri}, status: {httpResponseMessage.StatusCode} ({((int)httpResponseMessage.StatusCode)}), took {ts.TotalSeconds} seconds.");
                }
            }
            throw new TrackQueryNotFoundInThisRepositoryException(query, Repository);
        }
    }
}
