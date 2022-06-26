using System.Runtime.InteropServices;

namespace Hathor.Common.Helpers
{
    public static class FilesystemHelper
    {
        private const string NumberPattern = " ({0})";
        private static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        private static readonly bool IsLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private static readonly bool IsOsx = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        private static readonly bool IsFreeBsd = RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
        private static DirectoryInfo HomeDirectory
        {
            get
            {
                if (IsWindows)
                {
                    const string homeDriveVar = "HOMEDRIVE";
                    const string homePathVar = "HOMEPATH";
                    string homeDrive = Environment.GetEnvironmentVariable(homeDriveVar) ?? throw new Exception($"Could not load enviorment variable {homeDriveVar}.");
                    string homePath = Environment.GetEnvironmentVariable(homePathVar) ?? throw new Exception($"Could not load enviorment variable {homePathVar}.");
                    return new(Path.Combine(homeDrive, homePath));
                }else if (IsLinux || IsOsx)
                {
                    const string homeVar = "HOME";
                    string home = Environment.GetEnvironmentVariable(homeVar) ?? throw new Exception($"Could not load enviorment variable {homeVar}.");
                    return new(home);
                }else if (IsFreeBsd)
                {
                    throw new NotImplementedException("Free BSD is not yet supported.");
                }
                else
                {
                    throw new Exception("This OS is not recognized and thereby not supported.");
                }
            }
        }
        public static DirectoryInfo DownloadsDirectory
        {
            get
            {
                const string path = "Downloads";
                return new DirectoryInfo(Path.Combine(HomeDirectory.FullName, path));
            }
        }
        public static FileInfo NextAvailableFilename(FileInfo fileInfo) => new FileInfo(NextAvailableFilename(fileInfo.FullName));

        // Credit: https://stackoverflow.com/a/1078898/4961901
        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), NumberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + NumberPattern);
        }

        // Credit: https://stackoverflow.com/a/1078898/4961901
        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }

        public static string MakePathSafe(string path)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                path = path.Replace(c, '-');
            }
            return path;
        }
    }
}
