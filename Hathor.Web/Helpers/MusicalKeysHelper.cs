using Hathor.Common.Models.MusicalKeys;

namespace Hathor.Web.Helpers
{
    public static class MusicalKeysHelper
    {
        private const string NoKey = "No key";

        public static string AddLeadingZero(string key) => key.First().Equals('0') ? key : $"0{key}";

        public static string ToString(Camelot camelotKey)
        {
            switch (camelotKey)
            {
                case Camelot.K1A:
                    return "1A";
                case Camelot.K2A:
                    return "2A";
                case Camelot.K3A:
                    return "3A";
                case Camelot.K4A:
                    return "4A";
                case Camelot.K5A:
                    return "5A";
                case Camelot.K6A:
                    return "6A";
                case Camelot.K7A:
                    return "7A";
                case Camelot.K8A:
                    return "8A";
                case Camelot.K9A:
                    return "9A";
                case Camelot.K10A:
                    return "10A";
                case Camelot.K11A:
                    return "11A";
                case Camelot.K12A:
                    return "12A";
                case Camelot.K1B:
                    return "1B";
                case Camelot.K2B:
                    return "2B";
                case Camelot.K3B:
                    return "3B";
                case Camelot.K4B:
                    return "4B";
                case Camelot.K5B:
                    return "5B";
                case Camelot.K6B:
                    return "6B";
                case Camelot.K7B:
                    return "7B";
                case Camelot.K8B:
                    return "8B";
                case Camelot.K9B:
                    return "9B";
                case Camelot.K10B:
                    return "10B";
                case Camelot.K11B:
                    return "11B";
                case Camelot.K12B:
                    return "12B";
                case Camelot.None:
                    return NoKey;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Camelot));
            }
        }

        public static string ToString(OpenKey openKey)
        {
            switch (openKey)
            {
                case OpenKey.K1m:
                    return "1m";
                case OpenKey.K2m:
                    return "2m";
                case OpenKey.K3m:
                    return "3m";
                case OpenKey.K4m:
                    return "4m";
                case OpenKey.K5m:
                    return "5m";
                case OpenKey.K6m:
                    return "6m";
                case OpenKey.K7m:
                    return "7m";
                case OpenKey.K8m:
                    return "8m";
                case OpenKey.K9m:
                    return "9m";
                case OpenKey.K10m:
                    return "10m";
                case OpenKey.K11m:
                    return "11m";
                case OpenKey.K12m:
                    return "12m";
                case OpenKey.K1d:
                    return "1d";
                case OpenKey.K2d:
                    return "2d";
                case OpenKey.K3d:
                    return "3d";
                case OpenKey.K4d:
                    return "4d";
                case OpenKey.K5d:
                    return "5d";
                case OpenKey.K6d:
                    return "6d";
                case OpenKey.K7d:
                    return "7d";
                case OpenKey.K8d:
                    return "8d";
                case OpenKey.K9d:
                    return "9d";
                case OpenKey.K10d:
                    return "10d";
                case OpenKey.K11d:
                    return "11d";
                case OpenKey.K12d:
                    return "12d";
                case OpenKey.None:
                    return NoKey;
                default:
                    throw new ArgumentOutOfRangeException(nameof(OpenKey));
            }
        }

        public static string ToString(CircleOfFifths circleOfFifthsKey)
        {
            switch (circleOfFifthsKey)
            {
                case CircleOfFifths.AMajor:
                    return "";
                case CircleOfFifths.AMinor:
                    return "";
                case CircleOfFifths.BFlatMajor:
                    return "";
                case CircleOfFifths.BFlatMinor:
                    return "";
                case CircleOfFifths.BMajor:
                    return "";
                case CircleOfFifths.BMinor:
                    return "";
                case CircleOfFifths.CMajor:
                    return "";
                case CircleOfFifths.CMinor:
                    return "";
                case CircleOfFifths.DFlatMajor:
                    return "";
                case CircleOfFifths.DFlatMinor:
                    return "";
                case CircleOfFifths.DMajor:
                    return "";
                case CircleOfFifths.DMinor:
                    return "";
                case CircleOfFifths.EFlatMajor:
                    return "";
                case CircleOfFifths.EFlatMinor:
                    return "";
                case CircleOfFifths.EMajor:
                    return "";
                case CircleOfFifths.EMinor:
                    return "";
                case CircleOfFifths.FMajor:
                    return "";
                case CircleOfFifths.FMinor:
                    return "";
                case CircleOfFifths.GFlatMajor:
                    return "";
                case CircleOfFifths.GFlatMinor:
                    return "";
                case CircleOfFifths.GMajor:
                    return "";
                case CircleOfFifths.GMinor:
                    return "";
                case CircleOfFifths.AFlatMajor:
                    return "";
                case CircleOfFifths.AFlatMinor:
                    return "";
                case CircleOfFifths.None:
                    return NoKey;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CircleOfFifths));
            }
        }
    }
}
