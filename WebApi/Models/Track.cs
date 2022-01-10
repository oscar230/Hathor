using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Track
    {
        [JsonPropertyName("Guid")]
        public Guid Guid { get; private set; }

        [JsonPropertyName("TrackProviderId")]
        public int TrackProviderId { get; private set; }

        [JsonPropertyName("DisplayName")]
        public string DisplayName { get; private set; }

        [JsonPropertyName("DownloadUri")]
        public Uri DownloadUri { get; private set; }

        [JsonPropertyName("TrackProviderName")]
        public string TrackProviderName { get;}

        public Track(int trackProviderId, string displayName, Uri downloadUri, string trackProviderName)
        {
            Guid = Guid.NewGuid();
            TrackProviderId = trackProviderId;
            DisplayName = displayName;
            DownloadUri = downloadUri;
            TrackProviderName = trackProviderName;
        }

        public override string? ToString() => $"Track {DisplayName} ({Guid})";

        public override int GetHashCode() => Guid.GetHashCode();
    }
}
