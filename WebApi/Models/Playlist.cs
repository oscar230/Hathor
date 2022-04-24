namespace HathorCommon.Models
{
    public class Playlist
    {
        Guid Id { get; }

        string? DisplayName { get; }

        string? Description { get; }

        Uri Uri { get; }

        IEnumerable<ITrack> Tracks { get; }
    }
}
