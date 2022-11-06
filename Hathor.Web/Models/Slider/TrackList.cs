using Newtonsoft.Json;

namespace Hathor.Web.Models.Slider
{
    public class TrackList
    {
        [JsonProperty("audios")]
        public SearchResponse? SearchResponse { get; set; }
    }
}
