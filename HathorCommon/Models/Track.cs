namespace Hathor.Common.Models
{
    public class Track
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
    }
}
