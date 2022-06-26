namespace Hathor.Common.Models
{
    public class Artist
    {
        public Uri? Uri { get; set; }
        public string? Name { get; set; }

        public Artist()
        {
        }

        public Artist(string? name)
        {
            Name = name;
        }

        public override string? ToString() => Name;
    }
}
