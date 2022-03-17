﻿using HathorCommon.Models;
using HtmlAgilityPack;

namespace WebApi.Services.PlaylistRepositoryServices
{
    public class ThousandOnePlaylistRepositoryService : IPlaylistRepositoryService
    {
        public const string HTTP_CLIENT_NAME = "ThousandOneHttpClient";

        private readonly ILogger<ThousandOnePlaylistRepositoryService> _logger;
        private readonly HttpClient _httpClient;
        private readonly DbService _dbService;

        public ThousandOnePlaylistRepositoryService(ILogger<ThousandOnePlaylistRepositoryService> logger, HttpClient httpClient, DbService dbService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _dbService = dbService;
        }

        public IEnumerable<IPlaylist> Playlists => throw new NotImplementedException();

        private static IPlaylist ParsePlaylistsFromHtml(string html)
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
                            //return new Playlist();
                        }
                    }
                }
            }
            throw new NodeNotFoundException("Could not parse html into playlist.");
        }
    }
}
