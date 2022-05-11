using Flurl.Http;
using Flurl.Http.Configuration;
using Hathor.Api.Exceptions;
using Hathor.Api.Extensions;
using Hathor.Api.Helpers;
using Hathor.Common.Models;

namespace Hathor.Api.Services.TrackRepositoryServices
{
    public class SliderTrackRepositoryService : ITrackRepositoryService
    {
        private const string BASE_URL = "https://slider.kz/";
        private readonly ILogger<SliderTrackRepositoryService> _logger;
        private readonly IFlurlClient _flurlClient;
        private readonly UserAgentService _userAgentService;

        public SliderTrackRepositoryService(ILogger<SliderTrackRepositoryService> logger, IFlurlClientFactory flurlClientFactory, UserAgentService userAgentService)
        {
            _logger = logger;
            _flurlClient = flurlClientFactory.Get(BASE_URL);
            _userAgentService = userAgentService;
        }
        public Repository Repository => RepositoryHelper.GetSliderRepository;

        public Task<IEnumerable<Track>> Query(string? query)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> StreamTrackFile(Uri uri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
