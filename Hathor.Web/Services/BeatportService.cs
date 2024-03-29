﻿using Flurl.Http;
using Flurl.Http.Configuration;
using Hathor.Web.Mappers;
using Hathor.Web.Models;
using Hathor.Web.Models.Beatport;
using HtmlAgilityPack;
using System.Web;

namespace Hathor.Web.Services
{
    public class BeatportService
    {
        private const string BaseUrl = "https://www.beatport.com/";
        private readonly ILogger<BeatportService> _logger;
        private readonly IFlurlClient _flurlClient;

        public BeatportService(ILogger<BeatportService> logger, IFlurlClientFactory flurlClientFactory)
        {
            _logger = logger;
            Uri baseUrl = new(BaseUrl);
            _flurlClient = flurlClientFactory.Get(baseUrl);
        }

        public async Task<Playlist> Search(string searchQuery, int perPage = 25)
        {
            if (perPage.Equals(25) || perPage.Equals(50) || perPage.Equals(100) || perPage.Equals(150))
            {
                string pathAndQuery = $"search/tracks?q={HttpUtility.UrlEncode(searchQuery)}&per-page={perPage}";
                HtmlDocument htmlDocument = await Download(pathAndQuery);
                Uri uri = UriWithBase(pathAndQuery);
                BeatportSearchResults beatportSearchResults = new(htmlDocument, uri);
                List<Track> tracks = beatportSearchResults?.Tracks?.Select(beatportTrack => BeatportMapper.ToTrack(beatportTrack)).ToList() ?? new();
                Playlist playlist = new(uri, $"Search results for {searchQuery}", tracks);
                return playlist;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Parameter {nameof(perPage)} can only be 25, 50, 100 or 150, not {perPage}.");
            }
        }

        public async Task<List<Genre>> AllGenres()
        {
            Uri uri = new(_flurlClient.BaseUrl);
            HtmlDocument htmlDocument = await Download(string.Empty);
            BeatportStartpage beatportStartpage = new(htmlDocument, uri);
            if (beatportStartpage.AllGenres is not null && beatportStartpage.AllGenres.Any())
            {
                return beatportStartpage.AllGenres.Select(g => g.ToGenre()).ToList();
            }
            else
            {
                return Enumerable.Empty<Genre>().ToList();
            }
        }

        public async Task<Playlist> TopHundredReleases()
        {
            throw new NotImplementedException();
        }

        public async Task<Playlist> TopHundredTracks()
        {
            string path = "top-100";
            HtmlDocument htmlDocument = await Download(path);
            Uri uri = UriWithBase(path);
            BeatportSearchResults beatportSearchResults = new(htmlDocument, uri);
            List<Track> tracks = beatportSearchResults?.Tracks?.Select(beatportTrack => BeatportMapper.ToTrack(beatportTrack)).ToList() ?? new();
            Playlist playlist = new(uri, "Top 100 Tracks.", tracks);
            return playlist;
        }

        public async Task<Playlist> TopHundredHypeTracks()
        {
            string path = "hype-100";
            HtmlDocument htmlDocument = await Download(path);
            Uri uri = UriWithBase(path);
            BeatportSearchResults beatportSearchResults = new(htmlDocument, uri);
            List<Track> tracks = beatportSearchResults?.Tracks?.Select(beatportTrack => BeatportMapper.ToTrack(beatportTrack)).ToList() ?? new();
            Playlist playlist = new(uri, "Top 100 Hype Tracks.", tracks);
            return playlist;
        }

        private async Task<HtmlDocument> Download(string uriPath)
        {
            IFlurlRequest request = _flurlClient
                .WithHeader("Accept", "text/html")
                .WithHeader("Content_Language", "en-US")
                .Request(uriPath);
            _logger.LogDebug($"Requesting {request.Url}");
            IFlurlResponse response = await request.GetAsync();
            string html = await response.GetStringAsync();
            _logger.LogDebug($"Response status {response.StatusCode} with HTML of length {html.Length}");
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(html);
            _logger.LogInformation($"Downloaded page {UriWithBase(uriPath)}");
            return htmlDocument;
        }

        private Uri UriWithBase(string uriPath) => new($"{_flurlClient.BaseUrl}{uriPath}");
    }
}