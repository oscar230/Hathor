using HtmlAgilityPack;
using WebApi.Models;
using WebApi.Models.ThousandOne;

namespace WebApi.Services.TrackRepositoryServices
{
    public class ThousandOnePlaylistRepositoryService : IPlaylistRepositoryService
    {
        public const string HTTP_CLIENT_NAME = "ThousandOneHttpClient";

        private readonly ILogger<ThousandOnePlaylistRepositoryService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IDbService _dbService;

        public ThousandOnePlaylistRepositoryService(ILogger<ThousandOnePlaylistRepositoryService> logger, HttpClient httpClient, IDbService dbService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _dbService = dbService;
        }

        public IEnumerable<IPlaylist> Playlists => throw new NotImplementedException();

        private IPlaylist ParsePlaylistsFromHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var musicPlaylistHtmlNodes = doc.DocumentNode.SelectNodes("//div[@itemtype=\"http://schema.org/MusicPlaylist\"]").FirstOrDefault();
            if (musicPlaylistHtmlNodes != null)
            {
                var trackHtmlNodes = musicPlaylistHtmlNodes.SelectNodes("//div[@onclick=\"rowToggle('tlp', event);\"]");
                if (trackHtmlNodes != null)
                {
                    foreach (var trackHtmlNode in trackHtmlNodes)
                    {
                        trackHtmlNode.SelectNodes("//div[@itemtype=\"http://schema.org/MusicRecording\"]").FirstOrDefault();
                        if (trackHtmlNode != null)
                        {
                            // TODO
                            throw new NotImplementedException();
                            return new Playlist();
                        }
                    }
                }
            }
            throw new NodeNotFoundException("Could not parse html into playlist.");
        }
    }
}
