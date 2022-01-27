using WebApi.Models;

namespace WebApi.Services
{
    public interface ITrackRepositoryService
    {
        IRepository Repository { get; }

        Task<List<ITrack>> Query(string? query);

        Task<Stream> StreamTrackFile(Uri uri, CancellationToken cancellationToken);
    }
}
