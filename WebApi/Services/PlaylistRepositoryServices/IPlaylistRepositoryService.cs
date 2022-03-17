using HathorCommon.Models;

namespace WebApi.Services.PlaylistRepositoryServices
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<IPlaylist> Playlists { get; }
    }
}
