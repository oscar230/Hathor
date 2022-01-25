using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class SliderTrackList
    {
        [JsonInclude]
        [JsonPropertyName("")]
        public List<SliderTrack>? SliderTracks { get; set; }
    }
}
