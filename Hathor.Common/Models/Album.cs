namespace Hathor.Common.Models
{
    public class Album
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public Uri? Artwork { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public IEnumerable<Label>? Labels { get; set; }
    }
}