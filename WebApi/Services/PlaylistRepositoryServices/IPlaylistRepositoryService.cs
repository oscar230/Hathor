using WebApi.Models.Common;

namespace WebApi.Services.PlaylistRepositoryServices
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<IPlaylist> Playlists { get; }
    }
}
