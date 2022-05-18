using Flurl.Http;
using Hathor.Common;
using Hathor.Common.Helpers;
using Hathor.Slider.Lib;
using Hathor.Slider.Lib.Models.Slider;

const string NAME = "Hathor Slider";
List<Track> _trackDownloadQueue = new();
FlurlClient _flurlClient = new("https://slider.kz");
Query _query = new(new LoggerToConsole<Query>(nameof(Query)), _flurlClient);

async Task<bool> MainMenu()
{
    string[] menuItems =
    {
        $"Quit {NAME}.",
        "Help.",
        "Search.",
        "Download.",
        "Display download queue.",
        "Clear download queue.",
    };
    string menuSelection = ConsoleHelper.Selection(menuItems.ToList(), "What do you want to do?");
    switch (menuSelection)
    {
        case $"Quit {NAME}.":
            // Quit
            return false;
        case "Help.":
            // Help
            ShowHelp();
            break;
        case "Search.":
            // Search
            ConsoleHelper.Write("Enter search term: ");
            var searchTerm = Console.ReadLine();
            List<Track> tracks = await _query.Search(searchTerm);
            if (tracks.Any())
            {
                const string IdAll = "A_L_L";
                const string IdNone = "N_O_N_E";
                tracks.Add(new Track() { Duration = 0, Id = IdAll, TitArt = $"Select all {tracks.Count} tracks." });
                tracks.Add(new Track() { Duration = 0, Id = IdNone, TitArt = "Select no tracks (quit)." });
                Track selection = ConsoleHelper.Selection(tracks, "Select for later download: ");
                if (selection.Id is not null)
                {
                    if (selection.Id.Equals(IdAll))
                    {
                        tracks = tracks.GetRange(0, tracks.Count - 2);
                        ConsoleHelper.WriteLine($"All {tracks} tracks selected for download");
                        _trackDownloadQueue.AddRange(tracks);
                    }
                    else if (selection.Id.Equals(IdNone))
                    {
                        ConsoleHelper.WriteLine("No tracks selected for download");
                    }
                    else
                    {
                        _trackDownloadQueue.Add(selection);
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteLine($"Found no tracks from the search term: {searchTerm}");
            }
            break;
        case "Download.":
            // Download
            ConsoleHelper.WriteLine($"Downloading {_trackDownloadQueue.Count} tracks.");
            foreach (Track track in _trackDownloadQueue)
            {
                const string mpegExt = ".mp3";
                string safeTitArtForFileInfo = FilesystemHelper.MakePathSafe(track.TitArt ?? throw new ArgumentNullException(nameof(track.TitArt)));
                FileInfo trackFileInfo = FilesystemHelper.NextAvailableFilename(new FileInfo($"{FilesystemHelper.DownloadsDirectory}/{safeTitArtForFileInfo}{mpegExt}"));
                ConsoleHelper.WriteLine($"Downloading track: {track.TitArt} (to file: {trackFileInfo.FullName})");
                Stream trackStream = await _query.Download(track);
                ConsoleHelper.WriteLine($"Writing track to disk: {track.TitArt}");
                using (var fileStream = File.Create(trackFileInfo.FullName))
                {
                    await trackStream.CopyToAsync(fileStream);
                }
                ConsoleHelper.WriteLine($"Done with: {track.TitArt}");
            }
            _trackDownloadQueue = new();
            break;
        case "Display download queue.":
            // Display download queue
            ConsoleHelper.WriteList(_trackDownloadQueue);
            ConsoleHelper.WriteLine($"There are {_trackDownloadQueue.Count} tracks in the download queue.");
            break;
        case "Clear download queue.":
            // Clear download queue
            ConsoleHelper.WriteLine($"Do you wanna clear/remove/delete {_trackDownloadQueue.Count} tracks from the download queue? Then type YES in all caps, otherwise type anything else.");
            string? answer = Console.ReadLine();
            if (answer is not null && answer.Equals("YES"))
            {
                ConsoleHelper.WriteLine($"Cleared {_trackDownloadQueue.Count} tracks from the download queue.");
                _trackDownloadQueue = new List<Track>();
            }
            else
            {
                ConsoleHelper.WriteLine($"Did NOT clear {_trackDownloadQueue.Count} tracks from the download queue.");
            }
            break;
        default:
            return false;
    }
    return true;
}

void ShowHelp()
{
    throw new NotImplementedException();
}

ConsoleHelper.WriteLine($"Welcome to {NAME}.");
while (await MainMenu()) { }
ConsoleHelper.WriteLine("Bye! :)");