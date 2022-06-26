using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportDjChart
    {
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal string? CreatedByUserName { get; set; }
        internal Uri? CreatedByUserImage { get; set; }
        internal Uri? Artwork { get; set; }
        internal string? DateCreated { get; set; }
        internal IEnumerable<Uri>? Genres { get; set; }
        internal string? Description { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<Uri>? TrackUris { get; set; }

        public BeatportDjChart(HtmlDocument htmlDocument)
        {
        }
    }
}
