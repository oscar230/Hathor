using Hathor.Api.Models;

namespace Hathor.Api.Services.TrackRepositoryServices
{
    public interface ITrackRepositoryService
    {
        Repository Repository { get; }

        Task<IEnumerable<Track>> Query(string? query);

        Task<Stream> StreamTrackFile(Uri uri, CancellationToken cancellationToken);
    }
}
