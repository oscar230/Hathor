namespace HathorCommon.Models
{
    public interface IPlaylist
    {
        Guid Id { get; }

        string? DisplayName { get; }

        string? Description { get; }

        Uri Uri { get; }

        IEnumerable<ITrack> Tracks { get; }
    }
}
