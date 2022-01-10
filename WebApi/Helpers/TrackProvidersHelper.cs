using WebApi.Models;
using WebApi.Services;

namespace WebApi.Helpers
{
    public static class TrackProvidersHelper
    {
        public static List<Track> Index(List<ITrackProvider> trackProviders, string? query = null)
        {
            var tracks = new List<Track>();
            trackProviders.ForEach(trackProvider => trackProvider.Index(query).ForEach(track => tracks.Add(track)));
            return tracks;
        }
    }
}
