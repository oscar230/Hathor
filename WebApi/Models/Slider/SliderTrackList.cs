using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class SliderTrackList
    {
        [JsonPropertyName("")]
        public IEnumerable<SliderTrack>? SliderTracks { get; set; }
    }
}
