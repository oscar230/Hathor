using Hathor.Api.Models;

namespace WebApi.Services.PlaylistRepositoryServices
{
    public interface IPlaylistRepositoryService
    {
        IEnumerable<Playlist> Playlists { get; }
    }
}
