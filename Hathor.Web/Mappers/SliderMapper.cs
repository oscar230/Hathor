using Hathor.Web.Helpers;
using Hathor.Web.Models;
using Hathor.Web.Models.Slider;

namespace Hathor.Web.Mappers
{
    public static class SliderMapper
    {
        public static Track Map(SliderTrack track, Uri? sourceAsUrl)
        {
            return new Track(
                sourceAsUrl: sourceAsUrl,
                title: SliderHelper.GetTitle(track),
                artists: SliderHelper.GetArtistsFromSliderTrack(sourceAsUrl, track),
                remixers: SliderHelper.GetRemixers(track),
                duration: SliderHelper.GetDuration(track));
        }
    }
}
