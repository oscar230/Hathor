using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportStartpage
    {
        internal IEnumerable<BeatportGenre>? AllGenres { get; set; }

        public BeatportStartpage(HtmlDocument htmlDocument, Uri uri)
        {
            List<BeatportGenre> genres = new();
            HtmlNodeCollection listHtmlNodeCollection = htmlDocument.DocumentNode.SelectNodes(".//ul[@class='genre-drop-list__col']");
            foreach (HtmlNode listHtmlNode in listHtmlNodeCollection)
            {
                foreach (HtmlNode genreHtmlNode in listHtmlNode.SelectNodes(".//li[@class='genre-drop-list__item']/a"))
                {
                    string href = genreHtmlNode.Attributes["href"].Value;
                    string genreId = href.Split('/').Last();
                    string name = genreHtmlNode.Attributes["data-name"].Value;

                    genres.Add(new BeatportGenre()
                    {
                        Id = int.Parse(genreId),
                        Name = name,
                        Url = new Uri(uri, href)
                    });
                }
            }
            AllGenres = genres;
        }
    }
}
