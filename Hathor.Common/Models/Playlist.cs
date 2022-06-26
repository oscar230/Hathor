namespace Hathor.Common.Models
{
    public class Playlist
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public Uri? Artwork { get; set; }

        public Playlist()
        {
        }

        public Playlist(Uri? uri, string? title, IEnumerable<Track>? tracks, string? description = null, Uri? artwork = null)
        {
            Uri=uri;
            Title=title;
            Description=description;
            Tracks=tracks;
            Artwork=artwork;
        }

        public override string? ToString() => Title;
    }
}
