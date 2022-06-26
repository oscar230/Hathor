namespace Hathor.Common.Models
{
    public class Playlist
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public Uri? Artwork { get; set; }
    }
}
