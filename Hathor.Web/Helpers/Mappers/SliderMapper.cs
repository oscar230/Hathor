using Hathor.Web.Helpers;
using Hathor.Web.Models;
using Hathor.Web.Models.Slider;

namespace Hathor.Web.Mappers
{
    public static class SliderMapper
    {
        public static Track MapToTrack(SliderTrack track, Uri? sourceAsUrl)
        {
            return new Track(
                sourceAsUrl: sourceAsUrl,
                title: SliderHelper.GetTitle(track),
                artists: SliderHelper.GetArtistsFromSliderTrack(sourceAsUrl, track),
                remixers: SliderHelper.GetRemixers(track),
                duration: SliderHelper.GetDuration(track));
        }

        public static IEnumerable<SliderTrack> MapToSliderTracks(TrackList trackList)
        {
            IEnumerable<SliderTrack> tracks;
            if (trackList?.SearchResponse?.SliderTracks is not null && trackList.SearchResponse.SliderTracks.Any())
            {
                tracks = trackList.SearchResponse.SliderTracks;
            }
            else
            {
                tracks = Enumerable.Empty<SliderTrack>();
            }
            return tracks;
        }
    }
}
