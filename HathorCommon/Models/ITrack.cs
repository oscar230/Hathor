namespace HathorCommon.Models
{
    public interface ITrack
    {
        public Guid Id { get; }

        public string? Title { get; }

        public IEnumerable<Artist>? Artists { get; }

        public string? RepositoryInternalId { get; }

        public Repository? Repository { get; }
    }
}
