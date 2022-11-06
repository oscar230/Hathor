using Hathor.Web.Models.Rekordbox;

namespace Hathor.Web.Helpers
{
    internal class RekordboxHelper
    {
        internal static Library LoadLibrary(FileInfo libraryFileInfo)
        {
            return XmlHelper.Deserialize<Library>(libraryFileInfo);
        }
    }
}
