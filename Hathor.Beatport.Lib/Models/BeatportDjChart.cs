using Hathor.Common.Models;
using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportDjChart
    {
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal Artist? CreatedByArtist { get; set; }
        internal Uri? CreatedByUserImage { get; set; }
        internal BeatportArtwork? Artwork { get; set; }
        internal string? DateCreated { get; set; }
        internal IEnumerable<BeatportGenre>? Genres { get; set; }
        internal string? Description { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<BeatportTrack>? Tracks { get; set; }

        internal BeatportDjChart(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        internal Playlist ToPlaylist()
        {
            return new Playlist()
            {
                Uri = Url,
                Title = Title,
                Description = $"Beatport DJ Chart by {CreatedByArtist?.Name ?? "NO NAME"} at date {DateCreated}.",
                Tracks = Tracks?.Select(t => t.ToTrack()),
                Artwork = Artwork?.GetFullSize() ?? null,
            };
        }

        public override string? ToString() => Title;
    }
}
