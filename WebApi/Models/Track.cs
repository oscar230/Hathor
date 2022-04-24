using HathorCommon.Models;

namespace WebApi.Models
{
    public abstract class Track
    {
        public Guid? Id { get; }
        public string? Title { get; }
        public IEnumerable<Artist>? Artists { get; }
        public string? RepositoryInternalId { get; }
        public Repository? Repository { get; }
    }
}
