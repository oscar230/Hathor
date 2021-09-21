using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace hathor.Data
{
    public class ResponseSliderSearch
    {
        [JsonInclude]
        [JsonPropertyName("audios")]
        public ResponseSliderSearchAudios responseSliderSearchAudios { get; set; }
    }

    public class ResponseSliderSearchAudios
    {
        [JsonInclude]
        [JsonPropertyName("")]
        public List<ResponseSliderSearchTrack> responseSliderSearchTracks { get; set; }
    }

    public class ResponseSliderSearchTrack
    {
        [JsonInclude]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonInclude]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonInclude]
        [JsonPropertyName("tit_art")]
        public string TitArt { get; set; }

        [JsonInclude]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonInclude]
        [JsonPropertyName("extra")]
        public string Extra { get; set; }
    }
}