using Newtonsoft.Json;

namespace Hathor.Api.Models.Slider
{
    public class QueryResult
    {
        [JsonProperty("audios")]
        public QueryResultTrackList? TrackList { get; set; }
    }
}
