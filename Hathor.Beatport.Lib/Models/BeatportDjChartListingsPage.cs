namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportDjChartListingsPage
    {
        internal Uri? Url { get; set; }
        internal int ResultsPerPage { get; set; }
        internal int CurrentPage { get; set; }
        internal IEnumerable<Uri>? DjChartUrls { get; set; }

        public BeatportDjChartListingsPage(string html)
        {
        }
    }
}
