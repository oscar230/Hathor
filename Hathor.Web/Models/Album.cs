namespace Hathor.Web.Models
{
    public class Album
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public Uri? Artwork { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public IEnumerable<Label>? Labels { get; set; }

        public Album()
        {
        }

        public Album(string? title)
        {
            Title = title;
        }

        public Album(string? title, IEnumerable<Track>? tracks, IEnumerable<Artist>? artists)
        {
            Title = title;
            Tracks = tracks;
            Artists = artists;
        }
    }
}