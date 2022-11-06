using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportLabel
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal BeatportArtwork? Artwork { get; set; }
        internal IEnumerable<Uri>? TopTenTrackUrls { get; set; }
        internal IEnumerable<Uri>? LatestReleasesUrls { get; set; }

        public BeatportLabel(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        public BeatportLabel(HtmlNode node, Uri uri)
        {
            string href = node.Attributes["href"].Value;
            string labelId = href.Split('/').Last();
            Id = int.Parse(labelId);
            Url = new Uri(uri, href);
            Title = node.InnerText;
        }
    }
}
