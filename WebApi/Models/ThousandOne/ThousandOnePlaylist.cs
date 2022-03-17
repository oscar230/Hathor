using HathorCommon.Models;

namespace WebApi.Models.ThousandOne
{
    public class ThousandOnePlaylist : IPlaylist
    {
        public Guid Id => throw new NotImplementedException();

        public string? DisplayName => throw new NotImplementedException();

        public string? Description => throw new NotImplementedException();

        public Uri Uri => throw new NotImplementedException();

        public IEnumerable<ITrack> Tracks => throw new NotImplementedException();
    }
}
