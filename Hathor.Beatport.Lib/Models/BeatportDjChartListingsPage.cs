using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
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
