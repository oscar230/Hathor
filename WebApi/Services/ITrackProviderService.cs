using WebApi.Models;

namespace WebApi.Services
{
    public interface ITrackProviderService
    {
        public Task<List<Track>> Index(string? query = null);
    }
}
