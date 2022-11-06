using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportDjChartListingsPage
    {
        internal Uri? Url { get; set; }
        internal int ResultsPerPage { get; set; }
        internal int CurrentPage { get; set; }
        internal IEnumerable<BeatportDjChart>? DjCharts { get; set; }

        internal BeatportDjChartListingsPage(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
