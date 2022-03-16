using WebApi.Models.Common;

namespace WebApi.Models.ThousandOne
{
    public class ThousandOnePlaylist : IPlaylist
    {
        public Guid Guid => throw new NotImplementedException();

        public string? DisplayName => throw new NotImplementedException();

        public string? Description => throw new NotImplementedException();

        public Uri Uri => throw new NotImplementedException();

        public IEnumerable<Track> Tracks => throw new NotImplementedException();
    }
}
