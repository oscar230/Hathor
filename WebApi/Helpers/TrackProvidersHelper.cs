using WebApi.Models;
using WebApi.Services;

namespace WebApi.Helpers
{
    public static class TrackProvidersHelper
    {
        public static List<Track> Index(List<ITrackProviderService> trackProviders, string? query = null)
        {
            var tracks = new List<Track>();
            trackProviders.ForEach(async trackProvider =>
            {
                var t = await trackProvider.Index(query);
                t.ForEach(track => tracks.Add(track));
            });
            return tracks;
        }
    }
}
