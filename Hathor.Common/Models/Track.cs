namespace Hathor.Common.Models
{
    public class Track
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public IEnumerable<Artist>? Remixers { get; set; }
        public short Year { get; set; }
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
    }
}
