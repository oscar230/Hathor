using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportArtist
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Name { get; set; }
        internal string? Description { get; set; }
        internal BeatportArtwork? Artwork { get; set; }
        internal IEnumerable<BeatportTrack>? TopTenTracks { get; set; }
        internal IEnumerable<BeatportRelease> LatestReleases { get; set; }
        internal IEnumerable<BeatportDjChart> djCharts { get; set; }

        internal BeatportArtist(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        internal BeatportArtist(HtmlNode node, Uri uri)
        {
            string href = node.Attributes["href"].Value;
            string artistId = href.Split('/').Last();
            Id = int.Parse(artistId);
            Name = node.InnerHtml;
            Url = new(uri, href);
        }

        internal Artist ToArtist()
        {
            return new Artist()
            {
                Name = Name,
                SourceAsUrl = Url
            };
        }

        public override string? ToString() => Name;
    }
}