using WebApi.Models;

namespace WebApi.Services
{
    public class BtdigTrackProviderService : ITrackProviderService
    {
        private const string NAME = "btdig";
        private const string BASEURI = "https://btdig.com";
        private const string LOGOURI = "https://upload.wikimedia.org/wikipedia/commons/3/3b/BTDigg_logo.png";
        private readonly ILogger<BtdigTrackProviderService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Uri homepageUri;
        public Uri logoUri;

        public BtdigTrackProviderService(ILogger<BtdigTrackProviderService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            homepageUri = new(BASEURI);
            logoUri = new(LOGOURI);
            _logger.LogDebug("Constructing btdig track provider service.");
        }
        public Task<List<Track>> Index(string? query = null)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode() => NAME.GetHashCode();

        public override string? ToString() => NAME;
    }
}
