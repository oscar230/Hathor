using Hathor.Api.Models;

namespace Hathor.Api.Services.PlaylistRepositoryServices
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<Playlist> Playlists { get; }
    }
}
