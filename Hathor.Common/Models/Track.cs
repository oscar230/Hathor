namespace Hathor.Common.Models
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
        public bool IsLyricsClean { get; set; }
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
            string clean = IsLyricsClean ? $" (Clean)" : string.Empty;
            return $"{artists} - {Title}{remixers}{version}{clean}";
        }
    }
}
