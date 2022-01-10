using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public class SliderTrackProviderService : ITrackProviderService
    {
        private const string NAME = "slider";
        private const string BASEURL = "https://slider.kz";
        private const string LOGOURI = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/Simple_Music.svg/600px-Simple_Music.svg.png";
        private readonly ILogger<SliderTrackProviderService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Uri homepageUri;
        public Uri logoUri;

        public SliderTrackProviderService(ILogger<SliderTrackProviderService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            homepageUri = new(BASEURL);
            logoUri = new(LOGOURI);
            _logger.LogDebug("Constructing slider track provider service.");
        }

        public async Task<List<Track>> Index(string? query = null)
        {
            if (query != null)
            {
                query = HttpHelper.UrlEncode(query);
            }
            else
            {
                query = string.Empty;
            }
            using var httpClient = _httpClientFactory.CreateClient(NAME);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri($"{BASEURL}//vk_auth.php?q={query}"));
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var tracks = JsonToTracks(json);
            return tracks;
        }

        public override int GetHashCode() => NAME.GetHashCode();

        public override string? ToString() => NAME;

        private List<Track> JsonToTracks(string json)
        {
            throw new NotImplementedException();
        }
    }
}
