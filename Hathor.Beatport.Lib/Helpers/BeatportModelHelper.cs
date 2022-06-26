using System.Web;

namespace Hathor.Beatport.Lib.Helpers
{
    internal static class BeatportModelHelper
    {
        internal static string? SearchResultFromUrl(Uri? Url)
        {
            if (Url is not null)
            {
                string fullQuery = Url.Query;
                var quries = HttpUtility.ParseQueryString(fullQuery);
                string? searchQuery = quries["search"];
                if (searchQuery is not null)
                {
                    return HttpUtility.UrlDecode(searchQuery);
                }
            }
            return null;
        }
        internal static Uri BuildSearchQuery(Uri baseUrl, string searchQuery)
        {
            searchQuery = HttpUtility.UrlEncode(searchQuery) ?? string.Empty;
            string relativeUri = new($"/search?q={searchQuery}");
            return new(baseUrl, relativeUri);
        }

        internal static DateTime StringToDateTime(string date)
        {
            string[] dates = date.Split('-');
            int year = int.Parse(dates[0]);
            int month = int.Parse(dates[1]);
            int day = int.Parse(dates[2]);
            return new DateTime(year, month, day);
        }
    }
}
