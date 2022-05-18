using Flurl.Http;
using Hathor.Slider.Lib.Helpers;
using Hathor.Slider.Lib.Models.Slider;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Hathor.Slider.Lib
{
    public class Query : IDisposable
    {
        private const string BASE_URL = "https://slider.kz/";

        private readonly ILogger<Query> _logger;
        private readonly IFlurlClient _flurlClient;

        public Query(ILogger<Query> logger, IFlurlClient flurlClient)
        {
            if (flurlClient.BaseUrl is null)
            {
                throw new ArgumentException($"Parameter {nameof(flurlClient)} is missing the attribute {nameof(IFlurlClient.BaseUrl)}.");
            }
            else
            {
                _logger = logger;
                _flurlClient = flurlClient;
            }
        }

        public async Task<List<Track>> Search(string? query)
        {
            TimeSpan timeout = new(0, 0, 10);
            string pathAndQuery = $"vk_auth.php?q={HttpUtility.UrlEncode(query)}";
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
                List<Track> tracks = res?.SearchResponse?.SliderTracks ?? new List<Track>();
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
            return new();
        }

        public async Task<Stream> Download(Track track, CancellationToken cancellationToken = default) => await Download(track.DownloadPathAndQuery, cancellationToken);

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
