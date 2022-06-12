using Flurl.Http;
using Hathor.Common.Helpers;

const string NAME = "Hathor Slider";
FlurlClient _flurlClient = new("https://slider.kz");

async Task<bool> MainMenu()
{
    return true;
}

ConsoleHelper.WriteLine($"Welcome to {NAME}.");
while (await MainMenu()) { }
ConsoleHelper.WriteLine("Bye! :)");