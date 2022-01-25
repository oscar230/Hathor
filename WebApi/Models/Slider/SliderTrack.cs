using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class SliderTrack : ITrack
    {
        [JsonInclude]
        [JsonPropertyName("id")]
        public string? SliderId { get; set; }

        [JsonInclude]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonInclude]
        [JsonPropertyName("tit_art")]
        public string? FullTitle { get; set; }

        [JsonInclude]
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonInclude]
        [JsonPropertyName("extra")]
        public object? ExtraInformation { get; set; }

        public string InternalId => SliderId ?? throw new Exception("No slider id.");

        public string DisplayName => FullTitle ?? throw new Exception("No full title.");
    }
}
