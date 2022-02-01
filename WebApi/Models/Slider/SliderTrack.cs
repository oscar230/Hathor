using System.Text.Json.Serialization;
using System.Web;

namespace WebApi.Models.Slider
{
    public class SliderTrack : ITrackAtRepository
    {
        private const string DOWNLOAD_BASE_URI = "https://slider.kz/download";

        [JsonIgnore]
        public Guid Guid { get; } = Guid.NewGuid();

        [JsonInclude]
        [JsonPropertyName("id")]
        public string? SliderID { get; set; }

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

        public Uri DownloadUri => new($"{DOWNLOAD_BASE_URI}/{SliderID}/{Duration}/{Url}/{HttpUtility.UrlEncode(FullTitle)}.mp3?extra={(ExtraInformation != null ? HttpUtility.UrlEncode(ExtraInformation.ToString()) : "null")}");

        public string Title => FullTitle?.Split(Artist.ARTIST_TRACK_SEPARATOR).LastOrDefault() ?? throw new Exception("No track title.");

        public IEnumerable<IArtist> Artists => FullTitle != null ? Artist.ParseArtistsFromFullTitle(FullTitle) : throw new Exception("No FullTitle set, cannot get artists.");
    }
}
