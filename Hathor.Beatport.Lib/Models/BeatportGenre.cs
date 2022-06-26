using HtmlAgilityPack;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportGenre
    {
        internal int Id { get; set; }
        internal string? Name { get; set; }
        internal Uri? Url { get; set; }

        public BeatportGenre(HtmlDocument htmlDocument)
        {
        }
    }
}
