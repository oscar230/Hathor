using Hathor.Web.Data;
using Hathor.Web.Helpers;
using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Services
{
    public class RekordboxService
    {
        private readonly ILogger<RekordboxService> _logger;
        private readonly HathorContext _context;

        public RekordboxService(ILogger<RekordboxService> logger, HathorContext hathorContext)
        {
            _logger = logger;
            _context = hathorContext;
        }

        public void AddLibrary(IFormFile formFile)
        {
            Library library = RekordboxHelper.CreateLibrary(formFile);
            library.UploadDateTimeOffset = DateTimeOffset.UtcNow;
            _context.Libraries.Add(library);
            _context.SaveChanges();
        }

        public List<Library> Libraries(int pageSize, DateTimeOffset? latestDateTime = null)
        {
            latestDateTime ??= DateTimeOffset.UtcNow;
            IQueryable<Library> libraries = _context.Libraries
                .OrderBy(e => e.UploadDateTimeOffset)
                .Where(e => e.UploadDateTimeOffset <= latestDateTime);
            if (libraries.Any() && libraries.Count() >= pageSize)
            {
                libraries = libraries.Take(pageSize);
            }
            return libraries.ToList();
        }

        //public List<Track> Tracks => _library.Collection?.Tracks ?? new List<Track>();

        //public List<Track> TracksNeverPlayed => Tracks.Where(t => t.PlayCount is not null && t.PlayCount.Equals("0")).ToList();

        //public PlaylistNode? RootPlaylistNode => _library.Playlists?.PlaylistNode;

        //public override string ToString() => $"The library is from {_library.Product?.Name} version {_library.Product?.Version} and contains {_library.Collection?.Entries} tracks.";
    }
}
