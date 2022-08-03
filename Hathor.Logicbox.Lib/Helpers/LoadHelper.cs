using Hathor.Common.Helpers;
using Hathor.Common.Models.Rekordbox;

namespace Hathor.Logicbox.Lib.Helpers
{
    internal class LoadHelper
    {
        internal static Library LoadLibrary(FileInfo libraryFileInfo)
        {
            return XmlHelper.Deserialize<Library>(libraryFileInfo);
        }
    }
}
