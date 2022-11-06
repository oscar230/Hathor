using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportSearchResults
    {
        internal Uri? Url { get; set; }
        internal string? SearchQuery => Helpers.BeatportModelHelper.SearchResultFromUrl(Url);
        internal IEnumerable<BeatportTrack>? Tracks { get; set; }

        public BeatportSearchResults(HtmlDocument htmlDocument, Uri uri)
        {
            Url = uri;
            List<BeatportTrack> tracks = new();
            HtmlNode? trackListNode = htmlDocument.DocumentNode.SelectSingleNode(".//ul[@class='bucket-items  ec-bucket']");
            if (trackListNode is not null)
            {
                HtmlNode[] trackNodes = trackListNode.SelectNodes(".//li[@class='bucket-item ec-item track']").ToArray();
                foreach (HtmlNode trackNode in trackNodes)
                {
                    tracks.Add(new BeatportTrack(trackNode, uri));
                }
            }
            Tracks = tracks;
        }
    }
}
