using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class TrackList
    {
        [JsonPropertyName("")]
        public IEnumerable<Track>? SliderTracks { get; set; }
    }
}
