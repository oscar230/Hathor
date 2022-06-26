namespace Hathor.Common.Models
{
    public class Playlist
    {
        public Uri? Uri { get; set; }
        public string? Title { get; }
        public string? Description { get; }
        public IEnumerable<Track>? Tracks { get; }
        public Uri? Artwork { get; set; }
    }
}
