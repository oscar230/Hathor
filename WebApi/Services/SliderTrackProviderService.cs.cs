using WebApi.Models;

namespace WebApi.Services
{
    public class SliderService : ISliderTrackProviderService
    {
        private const IConfiguration _configuration;
        public Uri HomepageUri => throw new NotImplementedException();

        public Uri LogoSmallUri => throw new NotImplementedException();

        public Uri LogoLargeUri => throw new NotImplementedException();

        public List<Track> TracksFromSearchQuery(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
