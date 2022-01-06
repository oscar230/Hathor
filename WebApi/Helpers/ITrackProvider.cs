using WebApi.Models;

namespace WebApi.Services
{
    public interface ITrackProvider
    {
        public List<Track> TracksFromSearchQuery(string searchQuery);
        public Uri HomepageUri { get; }
        public Uri LogoSmallUri { get; }
        public Uri LogoLargeUri { get; }
    }
}
