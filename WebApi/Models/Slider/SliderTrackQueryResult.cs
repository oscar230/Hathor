using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class SliderTrackQueryResult
    {
        [JsonInclude]
        [JsonPropertyName("audios")]
        public SliderTrackList? SliderTrackList { get; set; }
    }
}
