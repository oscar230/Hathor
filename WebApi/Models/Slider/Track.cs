using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public abstract class Track
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("tit_art")]
        public string? TitArt { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("extra")]
        public object? ExtraInformation { get; set; }
    }
}
