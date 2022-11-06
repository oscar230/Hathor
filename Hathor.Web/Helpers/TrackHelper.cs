using Hathor.Common.Models;

namespace Hathor.Web.Helpers
{
    public static class TrackHelper
    {
        public static LyricVulgarity GetLyricVulgarity(string fullName)
        {
            if (fullName.Contains('(') || fullName.Contains('['))
            {
                if (fullName.ToLower().Contains("clean"))
                {
                    return LyricVulgarity.Clean;
                }
                else if (fullName.ToLower().Contains("dirty"))
                {
                    return LyricVulgarity.Dirty;
                }
            }
            return LyricVulgarity.Unknown;
        }

        public static string? GetVersion(string fullName)
        {
            if (fullName.Contains('(') || fullName.Contains('['))
            {
                string fullNameLower = fullName.ToLower();
                switch (fullNameLower)
                {
                    case "extended":
                        return "Extended";
                    case "original":
                        return "Original";
                    default:
                        break;
                }
            }
            return null;
        }
    }
}
