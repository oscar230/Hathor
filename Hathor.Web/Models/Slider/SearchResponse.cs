using Newtonsoft.Json;

namespace Hathor.Web.Models.Slider
{
    public class SearchResponse
    {
        [JsonProperty("")]
        public IEnumerable<SliderTrack>? SliderTracks { get; set; }
    }
}
