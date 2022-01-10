using WebApi.Models;

namespace WebApi.Services
{
    public interface ITrackProvider
    {
        public List<Track> Index(string? query = null);
        public Uri HomepageUri { get; }
        public Uri LogoUri { get; }
    }
}
