namespace WebApi.Models
{
    public interface IPlaylist
    {
        Guid Guid { get; }

        string? DisplayName { get; }

        string? Description { get; }

        Uri Uri { get; }

        IEnumerable<ITrack> Tracks { get; }
    }
}
