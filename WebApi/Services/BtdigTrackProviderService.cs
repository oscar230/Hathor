using WebApi.Models;

namespace WebApi.Services
{
    public class BtdigTrackProviderService : IBtdigTrackProviderService
    {
        private const string NAME = "btdig";
        private const string BASEURI = "https://btdig.com";
        private const string LOGOURI = "https://upload.wikimedia.org/wikipedia/commons/3/3b/BTDigg_logo.png";
        private readonly ILogger<BtdigTrackProviderService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public Uri HomepageUri;
        public Uri LogoUri;

        public BtdigTrackProviderService(ILogger<BtdigTrackProviderService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            HomepageUri = new(BASEURL);
            LogoUri = new(LOGOURI);
            _logger.LogDebug("Constructing btdig track provider service.");
        }
        public List<Track> Index(string query)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode() => Name.GetHashCode();

        public override string? ToString() => Name;
    }
}
