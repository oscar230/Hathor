using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class QueryResultTrackList
    {
        [JsonPropertyName("")]
        public IEnumerable<QueriedTrack>? SliderTracks { get; set; }
    }
}
