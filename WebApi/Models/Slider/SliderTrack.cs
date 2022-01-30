using System.Text.Json.Serialization;
using System.Web;
using WebApi.Helpers;

namespace WebApi.Models.Slider
{
    public class SliderTrack : ITrack
    {
        private const string DOWNLOAD_BASE_URI = "https://slider.kz/download";
        private readonly Guid _guid;

        public SliderTrack()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Guid { get => _guid; }

        [JsonInclude]
        [JsonPropertyName("id")]
        public string? SliderId { get; }

        [JsonInclude]
        [JsonPropertyName("duration")]
        public long Duration { get; }

        [JsonInclude]
        [JsonPropertyName("tit_art")]
        public string? FullTitle { get; }

        [JsonInclude]
        [JsonPropertyName("url")]
        public string? Url { get; }

        [JsonInclude]
        [JsonPropertyName("extra")]
        public object? ExtraInformation { get; }

        public string InternalId => SliderId ?? throw new Exception("No slider id.");

        public string DisplayName => FullTitle ?? throw new Exception("No full title.");

        public IRepository FromRepository => new SliderRepository();

        public string DownloadUriBase64 => Base64Helper.Encode(DownloadUri.AbsoluteUri);

        public Uri DownloadUri => new ($"{DOWNLOAD_BASE_URI}/{SliderId}/{Duration}/{Url}/{HttpUtility.UrlEncode(FullTitle)}.mp3?extra={(ExtraInformation != null ? HttpUtility.UrlEncode(ExtraInformation.ToString()) : "null")}");
    }
}
