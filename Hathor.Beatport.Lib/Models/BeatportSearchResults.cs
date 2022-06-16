namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportSearchResults
    {
        internal Uri? Url { get; set; }
        internal string? SearchQuery => Helpers.BeatportModelHelper.SearchResultFromUrl(Url);
    }
}
