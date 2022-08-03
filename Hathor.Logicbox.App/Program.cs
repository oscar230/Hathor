using Hathor.Common.Helpers;
using Hathor.Common.Models.Rekordbox;
using Hathor.Logicbox.Lib;
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
        ConsoleHelper.OKWriteLine(displayText);
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

bool MainMenu(RekordboxLibrary library)
{
    string[] menuItems =
    {
        $"Quit {NAME}.",
        "Help.",
        "Show playlists.",
        "Load \"My Tags\".",
    };
    ConsoleHelper.WriteLine("Main menu:");
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
            PlaylistNode? rootPlaylistNode = library.RootPlaylistNode;
            if (rootPlaylistNode is not null)
            {
                ShowPlaylistTree(rootPlaylistNode);
            }
            break;
        case "Load \"My Tags\".":
            // Load tags
            PlaylistNode? rootPlaylistNode2 = library.RootPlaylistNode;
            if (rootPlaylistNode2 is not null)
            {
                List<PlaylistNode> playlistNodesSelection = new();
                PlaylistNode selectedPlaylistNode = ConsoleHelper.Selection<PlaylistNode>(playlistNodesSelection, "Choose the root folder for your tags playlist.");
            }
            break;
        default:
            return false;
    }
    return true;
}

ConsoleHelper.WriteLine($"Welcome to {NAME}.");

DirectoryInfo runningDirectory = new(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!);
string[] allXmlFileNamesInRunningDirectory = Directory.GetFiles(runningDirectory.FullName, "*.xml", SearchOption.AllDirectories);
string choosenXmlFileName;
if (allXmlFileNamesInRunningDirectory.Any())
{
    choosenXmlFileName = ConsoleHelper.Selection(allXmlFileNamesInRunningDirectory.ToList(), "Choose you library xml file: ")!;
}
else
{
    ConsoleHelper.WriteLine("Enter a path here or place one or more library xml files in the running directory of this executable.");
    ConsoleHelper.WriteLine("Library xml file path: ");
    choosenXmlFileName = Console.ReadLine() ?? string.Empty;
}

FileInfo choosenXmlFile;
try
{
    choosenXmlFile = new FileInfo(choosenXmlFileName);
}
catch (Exception)
{
    ConsoleHelper.ErrorWriteLine($"Could not load library xml from path: {choosenXmlFileName}");
    throw;
}

RekordboxLibrary library = new(choosenXmlFile);
ConsoleHelper.OKWriteLine("Loaded the library successfully!");
ConsoleHelper.WriteLine(library.ToString());
while (MainMenu(library)) { }
ConsoleHelper.WriteLine("Bye! :)");