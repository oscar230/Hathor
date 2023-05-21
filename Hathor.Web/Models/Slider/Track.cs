using Hathor.Web.Helpers;
using Newtonsoft.Json;

namespace Hathor.Web.Models.Slider
{
    public class SliderTrack
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("tit_art")]
        public string? TitArt { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("extra")]
        public object? ExtraInformation { get; set; }

        public override string? ToString() => $"[{new TimeSpan(0, 0, (int)Duration).ToString(@"mm\:ss")}] {TitArt}";

        public string DownloadAudioUrl => SliderHelper.DownloadAudioUrl(this);
        public string PreviewAudioUrl => SliderHelper.PreviewAudioUrl(this);
    }
}
