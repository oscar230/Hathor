namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportLabel
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal Uri? ArtworkUrl { get; set; }
        internal IEnumerable<Uri>? TopTenTrackUrls { get; set; }
        internal IEnumerable<Uri>? LatestReleasesUrls { get; set; }

        public BeatportLabel(string html)
        {
        }
    }
}
