using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class QueryResult
    {
        [JsonPropertyName("audios")]
        public TrackList? TrackList { get; set; }
    }
}
