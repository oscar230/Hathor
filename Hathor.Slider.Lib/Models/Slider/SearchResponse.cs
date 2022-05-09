using Newtonsoft.Json;

namespace Hathor.Slider.Lib.Models.Slider
{
    public class SearchResponse
    {
        [JsonProperty("")]
        public List<Track>? SliderTracks { get; set; }
    }
}
