using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Helpers
{
    internal class RekordboxHelper
    {
        internal static Library? ParseLibrary(IFormFile formFile, DateTimeOffset? uploaded = null)
        {
            Stream stream = formFile.OpenReadStream();
            return ParseLibrary(stream, uploaded);
        }
        internal static Library? ParseLibrary(Stream stream, DateTimeOffset? uploaded = null)
        {
            var library = XmlHelper.Deserialize<Library>(stream);
            library.UploadDateTimeOffset = uploaded ?? DateTimeOffset.UtcNow;
            return library;
        }
    }
}
