using WebApi.Models;

namespace Hathor.Api.Models
{
    public class Playlist
    {
        public Guid Id { get; }
        public string? DisplayName { get; }
        public string? Description { get; }
        public Uri? Uri { get; }
        public IEnumerable<Track>? Tracks { get; }
    }
}
