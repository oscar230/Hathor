namespace WebApi.Models
{
    public interface ITrack
    {
        Guid Guid { get; }

        string Title { get; }

        IEnumerable<IArtist> Artists { get; }
    }
}
