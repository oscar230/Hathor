using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hathor.Common.Models.Rekordbox;
using Hathor.Logicbox.Lib.Helpers;

namespace Hathor.Logicbox.Lib
{
    public class RekordboxLibrary
    {
        private readonly Library _library;

        public RekordboxLibrary(FileInfo fileInfo)
        {
            _library = LoadHelper.LoadLibrary(fileInfo);
        }

        public List<Track> Tracks => _library.Collection?.Tracks ?? new List<Track>();

        public List<Track> TracksNeverPlayed => Tracks.Where(t => t.PlayCount is not null && t.PlayCount.Equals("0")).ToList();

        public PlaylistNode? RootPlaylistNode => _library.Playlists?.PlaylistNode;

        public override string ToString() => $"The library is from {_library.Product?.Name} version {_library.Product?.Version} and contains {_library.Collection?.Entries} tracks.";
    }
}
