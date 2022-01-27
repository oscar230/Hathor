using System.Text.Json.Serialization;
using System.Web;
using WebApi.Helpers;

namespace WebApi.Models.Slider
{
    public class SliderTrack : ITrack
    {
        private const string DOWNLOAD_BASE_URI = "https://slider.kz/download";

        [JsonInclude]
        [JsonPropertyName("id")]
        public string? SliderId { get; set; }

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

        public string InternalId => SliderId ?? throw new Exception("No slider id.");

        public string DisplayName => FullTitle ?? throw new Exception("No full title.");

        public IRepository FromRepository => new SliderRepository();

        public string DownloadUriBase64 => Base64Helper.Encode(DownloadUri.AbsoluteUri);

        public Uri DownloadUri => new ($"{DOWNLOAD_BASE_URI}/{SliderId}/{Duration}/{Url}/{HttpUtility.UrlEncode(FullTitle)}.mp3?extra={(ExtraInformation != null ? HttpUtility.UrlEncode(ExtraInformation.ToString()) : "null")}");
    }
}
