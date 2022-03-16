using WebApi.Models;

namespace WebApi.Services.TrackRepositoryServices
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<IPlaylist> Playlists { get; }
    }
}
