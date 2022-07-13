namespace Hathor.Common.Models
{
    public class Genre
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }

        public override string? ToString() => Title;

        public Genre()
        {
        }

        public Genre(string? title)
        {
            Title = title;
        }
    }
}