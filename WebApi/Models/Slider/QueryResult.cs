using System.Text.Json.Serialization;

namespace WebApi.Models.Slider
{
    public class QueryResult
    {
        [JsonPropertyName("audios")]
        public QueryResultTrackList? TrackList { get; set; }
    }
}
