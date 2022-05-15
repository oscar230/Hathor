using Hathor.Common;
using Hathor.Common.Helpers;
using Hathor.Slider.Lib;
using Hathor.Slider.Lib.Models.Slider;

const string NAME = "Hathor Slider";
List<Track> trackDownloadQueue = new List<Track>();

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
    string menuSelection = ConsoleHelper.Selection<string>(menuItems.ToList(), "What do you want to do?");
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
            var logger = new LoggerToConsole<Query>("Search and download");
            ConsoleHelper.Write("Enter search term: ");
            var searchTerm = Console.ReadLine();
            List<Track> tracks = await Query.Search(logger, searchTerm);
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
                        trackDownloadQueue.AddRange(tracks);
                    }
                    else if (selection.Id.Equals(IdNone))
                    {
                        ConsoleHelper.WriteLine("No tracks selected for download");
                    }
                    else
                    {
                        trackDownloadQueue.Add(selection);
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
            ConsoleHelper.WriteLine($"Downloading {trackDownloadQueue.Count} tracks.");
            foreach (Track track in trackDownloadQueue)
            {
                const string mpegExt = ".mp3";
                string safeTitArtForFileInfo = FilesystemHelper.MakePathSafe(track.TitArt ?? throw new ArgumentNullException(nameof(track.TitArt)));
                FileInfo trackFileInfo = FilesystemHelper.NextAvailableFilename(new FileInfo($"{FilesystemHelper.DownloadsDirectory}/{safeTitArtForFileInfo}{mpegExt}"));
                ConsoleHelper.WriteLine($"Downloading track: {track.TitArt} (to file: {trackFileInfo.FullName})");
                Stream trackStream = await Query.Download(track);
                ConsoleHelper.WriteLine($"Writing track to disk: {track.TitArt}");
                using (var fileStream = File.Create(trackFileInfo.FullName))
                {
                    await trackStream.CopyToAsync(fileStream);
                }
                ConsoleHelper.WriteLine($"Done with: {track.TitArt}");
            }
            trackDownloadQueue = new();
            break;
        case "Display download queue.":
            // Display download queue
            ConsoleHelper.WriteList(trackDownloadQueue);
            ConsoleHelper.WriteLine($"There are {trackDownloadQueue.Count} tracks in the download queue.");
            break;
        case "Clear download queue.":
            // Clear download queue
            ConsoleHelper.WriteLine($"Do you wanna clear/remove/delete {trackDownloadQueue.Count} tracks from the download queue? Then type YES in all caps, otherwise type anything else.");
            string? answer = Console.ReadLine();
            if (answer is not null && answer.Equals("YES"))
            {
                ConsoleHelper.WriteLine($"Cleared {trackDownloadQueue.Count} tracks from the download queue.");
                trackDownloadQueue = new List<Track>();
            }
            else
            {
                ConsoleHelper.WriteLine($"Did NOT clear {trackDownloadQueue.Count} tracks from the download queue.");
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