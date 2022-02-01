using WebApi.Models;

namespace WebApi.Services
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<IPlaylist> Playlists { get; }
    }
}
