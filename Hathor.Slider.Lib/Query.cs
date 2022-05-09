using Flurl.Http;
using Hathor.Slider.Lib.Helpers;
using Hathor.Slider.Lib.Models.Slider;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Hathor.Slider.Lib
{
    public class Query
    {
        private const string BASE_URL = "https://slider.kz/";
        private static FlurlClient FlurlClient => new(BASE_URL);

        public static async Task<List<Track>> Search(ILogger<Query> logger, string? query)
        {
            TimeSpan timeout = new(0, 0, 10);
            string pathAndQuery = $"vk_auth.php?q={HttpUtility.UrlEncode(query)}";
            try
            {
                TrackList res = await FlurlClient
                    .Request(pathAndQuery)
                    .WithTimeout(timeout)
                    .WithHeader("User-Agent", "APIs-Google (+https://developers.google.com/webmasters/APIs-Google.html)")
                    .WithHeader("Accept", "audio/mpeg")
                    .WithHeader("Accept-Encoding", "gzip, deflate, br")
                    .WithHeader("Accept-Language", "en-US")
                    .WithHeader("Connection", "keep-alive")
                    .WithHeader("Host", "slider.kz")
                    .WithHeader("Upgrade-Insecure-Requests", "1")
                    .GetJsonAsync<TrackList>();
                List<Track> tracks = res?.SearchResponse?.SliderTracks ?? new List<Track>();
                logger.LogDebug($"Slider query found {tracks.Count()} tracks for query {query}.");
                if (tracks.Any())
                {
                    return tracks;
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning($"Search tracks failed!\nError: {ex.Message}");
            }
            return new();
        }
    }
}
