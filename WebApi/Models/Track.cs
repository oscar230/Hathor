using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Track
    {
        [JsonPropertyName("Id")]
        public int Id { get; private set; }

        [JsonPropertyName("DisplayName")]
        public string DisplayName { get; private set; }

        [JsonPropertyName("DownloadUri")]
        public Uri DownloadUri { get; private set; }

        public Track(int id, string displayName, Uri downloadUri)
        {
            Id = id;
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            DownloadUri = downloadUri ?? throw new ArgumentNullException(nameof(downloadUri));
        }
    }
}
