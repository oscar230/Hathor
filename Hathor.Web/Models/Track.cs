using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;

namespace Hathor.Web.Models
{
    public class Track : SourcedFromWeb
    {
        private const int TitleMaxLength = 300;
        private const int CommentsMaxLength = 1000;
        private const int KeyMaxLength = 10;
        private const int VersionMaxLength = 100;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        public IEnumerable<Artist>? Artists { get; set; }

        public IEnumerable<Artist>? Remixers { get; set; }
        
        public short? Year { get; set; }
        
        public TimeSpan? Duration { get; set; }
        
        public long? FileSizeInBytes { get; set; }

        public int? SampleRateInHz { get; set; }
        
        public int? BitRateInBitsPerSecond { get; set; }

        public LyricVulgarity LyricVulgarity { get; set; }

        public Album? InAlbum { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string? Comments { get; set; }

        public IEnumerable<Genre>? Genres { get; set; }
        
        public float? Bpm { get; set; }
        
        public string? Key { get; set; }

        [MaxLength(VersionMaxLength)]
        public string? Version { get; set; }

        public Track(
            Uri? sourceAsUrl,
            string? title,
            IEnumerable<Artist>? artists,
            IEnumerable<Artist>? remixers,
            short? year,
            TimeSpan duration,
            long fileSizeInBytes,
            int sampleRateInHz,
            int bitRateInBitsPerSecond,
            LyricVulgarity? lyricVulgarity,
            Album? inAlbum,
            string? comments,
            IEnumerable<Genre>? genres,
            float? bpm,
            string? key,
            string? version) : base(sourceAsUrl)
        {
            Title = StringHelpers.Shorten(title, TitleMaxLength);
            Artists = artists;
            Remixers = remixers;
            Year = year;
            Duration = duration;
            FileSizeInBytes = fileSizeInBytes;
            SampleRateInHz = sampleRateInHz;
            BitRateInBitsPerSecond = bitRateInBitsPerSecond;
            LyricVulgarity = lyricVulgarity ?? LyricVulgarity.Unknown;
            InAlbum = inAlbum;
            Comments = StringHelpers.Shorten(comments, CommentsMaxLength);
            Genres = genres;
            Bpm = bpm;
            Key = StringHelpers.Shorten(key, KeyMaxLength);
            Version = StringHelpers.Shorten(version, VersionMaxLength);
        }

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
