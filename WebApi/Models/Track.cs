namespace Hathor.Api.Models
{
    public class Track
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public string? RepositoryInternalId { get; set; }
        public Repository? Repository { get; set; }
    }
}
