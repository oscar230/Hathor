using Newtonsoft.Json;

namespace Hathor.Api.Models.Slider
{
    public abstract class QueriedTrack
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("tit_art")]
        public string? TitArt { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("extra")]
        public object? ExtraInformation { get; set; }
    }
}
