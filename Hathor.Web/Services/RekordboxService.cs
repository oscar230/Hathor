using Hathor.Web.Helpers;
using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Services
{
    public class RekordboxService
    {
        private readonly List<Library> _libraries = new();

        public Library? ParseAndAdd(IFormFile formFile)
        {
            var library = RekordboxHelper.ParseLibrary(formFile);
            if (library is not null)
            {
                Add(library);
                return library;
            }
            else
            {
                return null;
            }
        }

        public void Add(Library library) => _libraries.Add(library);

        public IEnumerable<Library> GetAll(int pageSize, DateTimeOffset? from = null, DateTimeOffset? to = null)
        {
            bool filterByDate = from is not null || to is not null;
            from ??= DateTimeOffset.MinValue;
            to ??= DateTimeOffset.MaxValue;
            return _libraries.Where(l => filterByDate && l.UploadDateTimeOffset >= from && l.UploadDateTimeOffset <= to).Take(pageSize);
        }

        public bool Any() => _libraries.Any();
    }
}
