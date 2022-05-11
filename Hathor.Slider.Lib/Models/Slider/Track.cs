using Hathor.Slider.Lib.Helpers;
using Newtonsoft.Json;

namespace Hathor.Slider.Lib.Models.Slider
{
    public class Track
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

        public override int GetHashCode()
        {
            if (Id is not null)
            {
                return Id.GetHashCode();
            }
            else
            {
                throw new ArgumentNullException(nameof(Id));
            }
        }

        public override string? ToString() => $"[{new TimeSpan(0, 0, (int)Duration).ToString(@"mm\:ss")}] {TitArt}";

        public string DownloadPathAndQuery => SliderHelper.DownloadPathAndQuery(this);
    }
}
