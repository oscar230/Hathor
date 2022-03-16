namespace WebApi.Models.Common
{
    public interface IPlaylist
    {
        Guid Guid { get; }

        string? DisplayName { get; }

        string? Description { get; }

        Uri Uri { get; }

        IEnumerable<Track> Tracks { get; }
    }
}
