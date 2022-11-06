using Flurl.Http;
using Flurl.Http.Configuration;
using Hathor.Web.Models.Slider;
using System.Web;

namespace Hathor.Web.Services
{
    public class SliderService : IDisposable
    {
        private const string BaseUrl = "https://slider.kz/";

        private readonly ILogger<SliderService> _logger;
        private readonly IFlurlClient _flurlClient;

        public SliderService(ILogger<SliderService> logger, IFlurlClientFactory flurlClientFactory)
        {
            Uri baseUrl = new(BaseUrl);
            _flurlClient = flurlClientFactory.Get(baseUrl);
            _logger = logger;
        }

        public async Task<IEnumerable<SliderTrack>> Search(string? query)
        {
            TimeSpan timeout = new(0, 0, 10);
            string pathAndQuery = $"vk_auth.php?q={HttpUtility.UrlEncode(query ?? string.Empty)}";
            try
            {
                TrackList res = await _flurlClient
                    .Request(pathAndQuery)
                    .WithTimeout(timeout)
                    .WithHeader("User-Agent", "APIs-Google (+https://developers.google.com/webmasters/APIs-Google.html)")
                    .WithHeader("Accept", "application/json")
                    .WithHeader("Accept-Encoding", "gzip, deflate, br")
                    .WithHeader("Accept-Language", "en-US")
                    .WithHeader("Connection", "keep-alive")
                    .WithHeader("Host", "slider.kz")
                    .WithHeader("Upgrade-Insecure-Requests", "1")
                    .GetJsonAsync<TrackList>();
                IEnumerable<SliderTrack> tracks = res?.SearchResponse?.SliderTracks ?? new List<SliderTrack>();
                _logger.LogDebug($"Slider query found {tracks.Count()} tracks for query {query}.");
                if (tracks.Any())
                {
                    return tracks;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Search tracks failed!\nError: {ex.Message}");
            }
            return Enumerable.Empty<SliderTrack>();
        }

        public async Task<Stream> Download(SliderTrack track, CancellationToken cancellationToken = default) => await Download(track.DownloadPathAndQuery, cancellationToken);

        public async Task<Stream> Download(string pathAndQuery, CancellationToken cancellationToken = default)
        {
            TimeSpan timeout = new(0, 1, 0);
            return await _flurlClient
                .Request(pathAndQuery)
                .WithTimeout(timeout)
                .WithHeader("User-Agent", "APIs-Google (+https://developers.google.com/webmasters/APIs-Google.html)")
                .WithHeader("Accept", "audio/mpeg")
                .WithHeader("Accept-Encoding", "gzip, deflate, br")
                .WithHeader("Accept-Language", "en-US")
                .WithHeader("Connection", "keep-alive")
                .WithHeader("Host", "slider.kz")
                .WithHeader("Upgrade-Insecure-Requests", "1")
                .GetStreamAsync(cancellationToken);
        }

        public void Dispose()
        {
            _flurlClient.Dispose();
        }
    }
}
