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
                BeatportSearchResults beatportSearchResults = await GetBeatportSearchResults(pathAndQuery);
                List<Track> tracks = beatportSearchResults?.Tracks?.Select(t => t.ToTrack()).ToList() ?? new();
                return tracks;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Parameter {nameof(perPage)} can only be 25, 50, 100 or 150, not {perPage}.");
            }
        }

        internal async Task<BeatportDjChart> GetBeatportDjChart(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportDjChart(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportDjChartListingsPage> GetBeatportDjChartListingsPage(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportDjChartListingsPage(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportGenre> GetBeatportGenre(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportGenre(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportLabel> GetBeatportLabel(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportLabel(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportRelease> GetBeatportRelease(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportRelease(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportSearchResults> GetBeatportSearchResults(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportSearchResults(htmlDocument, UriWithBase(uriPath));
        }

        internal async Task<BeatportTrack> GetBeatportTrack(string uriPath)
        {
            HtmlDocument htmlDocument = await Download(uriPath);
            return new BeatportTrack(htmlDocument, UriWithBase(uriPath));
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