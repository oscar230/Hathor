using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Helpers
{
    internal class RekordboxHelper
    {
        /// <summary>
        /// Creates a Rekordbox library from a HTTP form file.
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        internal static Library CreateLibrary(IFormFile formFile)
        {
            Stream stream = formFile.OpenReadStream();
            return XmlHelper.Deserialize<Library>(stream);
        }
    }
}
