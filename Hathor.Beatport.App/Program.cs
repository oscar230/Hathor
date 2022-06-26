﻿using Flurl.Http;
using Hathor.Beatport.Lib;
using Hathor.Common;
using Hathor.Common.Helpers;
using Hathor.Common.Models;

const string NAME = "Hathor Beatport";
FlurlClient _flurlClient = new("https://www.beatport.com/");
_flurlClient.WithHeader("User-Agent", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)");

async Task<bool> MainMenu()
{
    var logger = new LoggerToConsole<Beatport>(NAME);
    Beatport beatport = new(logger, _flurlClient);
    try
    {
        List<Track> tracks = await beatport.Search("Avicii Levels");
        ConsoleHelper.WriteLine($"Tracks: {tracks.Count}");
        ConsoleHelper.WriteList(tracks);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    return false;
}

ConsoleHelper.WriteLine($"Welcome to {NAME}.");
while (await MainMenu()) { }
ConsoleHelper.WriteLine("Bye! :)");