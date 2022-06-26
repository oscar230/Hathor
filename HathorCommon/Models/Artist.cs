namespace Hathor.Common.Models
{
    public class Artist
    {
        public Uri? Uri { get; set; }
        public string? Name { get; }
        
        public Artist(string? name)
        {
            Name = name;
        }
    }
}
