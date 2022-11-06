namespace Hathor.Web.Models
{
    public class Track
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public IEnumerable<Artist>? Remixers { get; set; }
        public short? Year { get; set; }
        public TimeSpan Duration { get; set; }
        public long FileSizeInBytes { get; set; }
        public int SampleRateInHz { get; set; }
        public int BitRateInBitsPerSecond { get; set; }
        public LyricVulgarity LyricVulgarity { get; set; } = LyricVulgarity.Unknown;
        public Album? InAlbum { get; set; }
        public string? Comments { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public float? Bpm { get; set; }
        public string? Key { get; set; }
        public string? Version { get; set; }

        public override string? ToString()
        {
            string artists = Artists is not null && Artists.Any() ? string.Join(", ", Artists) : "NO ARTIST";
            string remixers = Remixers is not null && Remixers.Any() ? $" ({string.Join(' ', Remixers)} Remix)" : string.Empty;
            string version = !string.IsNullOrWhiteSpace(Version) ? $" ({Version})" : string.Empty;
            string lyricVulgarity = LyricVulgarity.Equals(LyricVulgarity.Unknown) ? string.Empty : $" ({LyricVulgarity})";
            return $"{artists} - {Title}{remixers}{version}{lyricVulgarity}";
        }
    }
}
