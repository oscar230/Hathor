using WebApi.Models;

namespace WebApi.Services
{
    public interface ITrackRepositoryService
    {
        Task<List<ITrack>> Query(string? query);
    }
}
