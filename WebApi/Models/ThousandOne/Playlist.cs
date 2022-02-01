namespace WebApi.Models.ThousandOne
{
    public class Playlist : IPlaylist
    {
        public Guid Guid => throw new NotImplementedException();

        public string? DisplayName => throw new NotImplementedException();

        public string? Description => throw new NotImplementedException();

        public Uri Uri => throw new NotImplementedException();

        public IEnumerable<ITrack> Tracks => throw new NotImplementedException();
    }
}
