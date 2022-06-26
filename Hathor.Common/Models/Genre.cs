namespace Hathor.Common.Models
{
    public class Genre
    {
        public Uri? Uri { get; set; }
        public string? Title { get; set; }

        public override string? ToString() => Title;
    }
}