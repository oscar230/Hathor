using Hathor.Common.Helpers;
using Hathor.Common.Models.Rekordbox;

namespace Hathor.Logicbox.Lib.Helpers
{
    public class RekordboxHelper
    {
        public static Library GetLibrary(FileInfo libraryFileInfo) => XmlHelper.Deserialize<Library>(libraryFileInfo);
        public static Library GetLibrary(string libraryFileName) => XmlHelper.Deserialize<Library>(libraryFileName);
    }
}
