using Flurl.Http;
using Hathor.Beatport.Lib.Models;
using Hathor.Common.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System.Web;

namespace Hathor.Beatport.Lib
{
    public class Beatport
    {
        private readonly ILogger<Beatport> _logger;
        private readonly IFlurlClient _flurlClient;

        public Beatport(ILogger<Beatport> logger, IFlurlClient flurlClient)
        {
            _logger = logger;
            _flurlClient = flurlClient;
        }

        public async Task<List<Track>> Search(string searchQuery, int perPage = 25)
        {
            if (perPage.Equals(25) || perPage.Equals(50) || perPage.Equals(100) || perPage.Equals(150))
            {
                string pathAndQuery = new($"search/tracks?q={HttpUtility.UrlEncode(searchQuery)}&per-page={perPage}");
                HtmlDocument htmlDocument = await Download(pathAndQuery);
                BeatportSearchResults beatportSearchResults = new(htmlDocument, UriWithBase(pathAndQuery));
                List<Track> tracks = beatportSearchResults?.Tracks?.Select(t => t.ToTrack()).ToList() ?? new();
                return tracks;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Parameter {nameof(perPage)} can only be 25, 50, 100 or 150, not {perPage}.");
            }
        }

        public async Task<List<Genre>> AllGenres()
        {
            Uri uri = new Uri(_flurlClient.BaseUrl);
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