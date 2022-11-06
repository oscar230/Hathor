using Hathor.Web.Helpers;
using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Services
{
    public class RekordboxService
    {
        private readonly Library _library;

        public RekordboxService(FileInfo fileInfo)
        {
            _library = RekordboxHelper.LoadLibrary(fileInfo);
        }

        public List<Track> Tracks => _library.Collection?.Tracks ?? new List<Track>();

        public List<Track> TracksNeverPlayed => Tracks.Where(t => t.PlayCount is not null && t.PlayCount.Equals("0")).ToList();

        public PlaylistNode? RootPlaylistNode => _library.Playlists?.PlaylistNode;

        public override string ToString() => $"The library is from {_library.Product?.Name} version {_library.Product?.Version} and contains {_library.Collection?.Entries} tracks.";
    }
}
