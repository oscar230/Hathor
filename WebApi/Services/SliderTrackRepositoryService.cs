using System.Text.Json;
using System.Web;
using WebApi.Exceptions;
using WebApi.Models;
using WebApi.Models.Slider;

namespace WebApi.Services
{
    public class SliderTrackRepositoryService : ITrackRepositoryService
    {
        private const string SLIDER_API_QUERY = "https://slider.wonky.se/";
        private readonly ILogger<SliderTrackRepositoryService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderTrackRepositoryService(ILogger<SliderTrackRepositoryService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IRepository Repository => new SliderRepository();

        public async Task<List<ITrack>> Query(string? query)
        {
            query = query ?? string.Empty;
            query = HttpUtility.UrlEncode(query);
            var uri = new Uri($"{SLIDER_API_QUERY}{query}");
            using (var client = _httpClientFactory.CreateClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
                using (var httpResponseMessage = await client.SendAsync(httpRequestMessage))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var content = await httpResponseMessage.Content.ReadAsStreamAsync();
                        var tracks = JsonSerializer.Deserialize<SliderTrackQueryResult>(content);
                        if (tracks?.SliderTrackList?.SliderTracks?.Count > 0)
                        {
                            return tracks.SliderTrackList.SliderTracks.ToList<ITrack>();
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"Query failed (status: {httpResponseMessage.StatusCode})! uri: {uri}");
                    }
                }
            }
            throw new TrackQueryNotFoundInThisRepositoryException(query, Repository);
        }
    }
}
