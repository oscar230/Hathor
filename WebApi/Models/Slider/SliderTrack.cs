using System.Text.Json.Serialization;
using System.Web;

namespace WebApi.Models.Slider
{
    public class SliderTrack : ITrack
    {
        private const string DOWNLOAD_BASE_URI = "https://slider.kz/download";

        [JsonIgnore]
        public Guid Guid { get; } = Guid.NewGuid();

        [JsonInclude]
        [JsonPropertyName("id")]
        public string? SliderID { get; set;  }

        [JsonInclude]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonInclude]
        [JsonPropertyName("tit_art")]
        public string? FullTitle { get; set; }

        [JsonInclude]
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonInclude]
        [JsonPropertyName("extra")]
        public object? ExtraInformation { get; set; }

        public string InternalID => SliderID ?? throw new Exception("No slider id.");

        public string DisplayName => FullTitle ?? throw new Exception("No full title.");

        public IRepository FromRepository => new SliderRepository();

        public Uri DownloadUri => new ($"{DOWNLOAD_BASE_URI}/{SliderID}/{Duration}/{Url}/{HttpUtility.UrlEncode(FullTitle)}.mp3?extra={(ExtraInformation != null ? HttpUtility.UrlEncode(ExtraInformation.ToString()) : "null")}");

        public SliderTrack()
        {
        }
    }
}
