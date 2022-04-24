using Newtonsoft.Json;

namespace Hathor.Api.Models.Slider
{
    public class QueryResultTrackList
    {
        [JsonProperty("")]
        public IEnumerable<QueriedTrack>? SliderTracks { get; set; }
    }
}
