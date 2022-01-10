using WebApi.Models;

namespace WebApi.Services
{
    public class SliderTrackProviderService : ISliderTrackProviderService
    {
        private const string NAME = "slider";
        private const string BASEURL = "https://slider.kz";
        private const string LOGOURI = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/Simple_Music.svg/600px-Simple_Music.svg.png";
        private readonly ILogger<SliderTrackProviderService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public Uri HomepageUri;
        public Uri LogoUri;

        public SliderTrackProviderService(ILogger<SliderTrackProviderService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            HomepageUri = new(BASEURL);
            LogoUri = new(LOGOURI);
            _logger.LogDebug("Constructing slider track provider service.");
        }

        public List<Track> Index(string query)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode() => NAME.GetHashCode();

        public override string? ToString() => NAME;
    }
}
