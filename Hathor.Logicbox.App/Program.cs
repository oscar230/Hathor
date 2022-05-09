using Hathor.Common.Helpers;
using Hathor.Common.Models.Rekordbox;
using Hathor.Logicbox.Lib.Helpers;
using System.Reflection;

const string NAME = "Hathor Logicbox";

void ShowPlaylistTree(PlaylistNode playlistNode, int treeWidth = 0)
{
    string displayText = $"{string.Concat(Enumerable.Repeat("-", treeWidth))} {playlistNode.Name ?? String.Empty}";
    if (playlistNode.IsPlaylist)
    {
        ConsoleHelper.WriteLine(displayText);
    }
    else
    {
        ConsoleHelper.PrimaryWriteLine(displayText);
    }
    foreach (PlaylistNode currentPlaylistNode in playlistNode.PlaylistNodes ?? throw new Exception())
    {
        ShowPlaylistTree(currentPlaylistNode, treeWidth + 1);
    }
}

void ShowHelp()
{
    throw new NotImplementedException();
}

bool MainMenu(Library library)
{
    string[] menuItems =
    {
        $"Quit {NAME}.",
        "Help.",
        "Show playlists.",
        "Load tags from playlist folder."
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
        case "Show playlists.":
            // Show playlists
            PlaylistNode? rootPlaylistNode = library.Playlists?.PlaylistNode;
            if (rootPlaylistNode is not null)
            {
                ShowPlaylistTree(rootPlaylistNode);
            }
            break;
        case "Load tags from playlist folder.":
            // Load tags
            PlaylistNode? rootPlaylistNode2 = library.Playlists?.PlaylistNode;
            if (rootPlaylistNode2 is not null)
            {
                List<PlaylistNode> playlistNodesSelection = new();
                //ConsoleHelper.Selection();
            }
            break;
        default:
            return false;
    }
    return true;
}

ConsoleHelper.WriteLine($"Welcome to {NAME}.");
string? runningDirectoryAsString = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
if (runningDirectoryAsString is null)
{
    throw new Exception("Could not the running process's running directory.");
}
DirectoryInfo? runningDirectory = new FileInfo(runningDirectoryAsString).Directory;
if (runningDirectory is null || !runningDirectory.Exists)
{
    throw new DirectoryNotFoundException();
}
ConsoleHelper.WriteLine(runningDirectory.FullName);
string[] xmlFileNames = Directory.GetFiles(runningDirectory.FullName, "*.xml", SearchOption.AllDirectories);
string xmlFileName = ConsoleHelper.Selection(xmlFileNames.ToList(), "Choose you library xml file: ") ?? string.Empty;
Library library = RekordboxHelper.GetLibrary(xmlFileName);
ConsoleHelper.WriteLine($"Loaded the library successfully! The library is from {library.Product?.Name} version {library.Product?.Version} and contains {library.Collection?.Entries} tracks.");
while (MainMenu(library)) { }
ConsoleHelper.WriteLine("Bye! :)");