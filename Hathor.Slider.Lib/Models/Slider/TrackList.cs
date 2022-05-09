using Newtonsoft.Json;

namespace Hathor.Slider.Lib.Models.Slider
{
    public class TrackList
    {
        [JsonProperty("audios")]
        public SearchResponse? SearchResponse { get; set; }
    }
}
