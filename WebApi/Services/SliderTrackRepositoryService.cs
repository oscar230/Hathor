using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class SliderTrackRepositoryService : ITrackRepositoryService
    {
        private const string SLIDER_API_QUERY = "https://slider.wonky.se/";
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderTrackRepositoryService(ILogger logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public Task<List<ITrack>> Query(string? query)
        {
            query = query ?? string.Empty;
            query = HttpUtility.UrlEncode(query);
            var uri = new Uri($"{SLIDER_API_QUERY}{query}");
            using (var client = _httpClientFactory.CreateClient())
            {

            }
        }


    }
}
