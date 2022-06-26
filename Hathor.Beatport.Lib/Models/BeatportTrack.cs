using Hathor.Beatport.Lib.Helpers;
using Hathor.Common.Models;
using HtmlAgilityPack;
using System.Web;

namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportTrack
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal string? Version { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<BeatportArtist>? Artists { get; set; }
        internal IEnumerable<BeatportArtist>? Remixers { get; set; }
        internal BeatportArtwork? Artwork { get; set; }
        internal TimeSpan? Length { get; set; }
        internal DateTime? ReleasedDate { get; set; }
        internal BeatportRelease Release { get; set; }
        internal string? Bpm { get; set; }
        internal string? Key { get; set; }
        internal BeatportGenre? Genre { get; set; }
        internal BeatportLabel? Label { get; set; }

        public BeatportTrack(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        public BeatportTrack(HtmlNode node, Uri uri)
        {
            string title = node.SelectSingleNode(".//span[@class='buk-track-primary-title']").InnerText;
            string version = node.SelectSingleNode(".//span[@class='buk-track-remixed']").InnerText;
            string price = node.SelectSingleNode(".//div[@class='buy-button track-buy-button \n']").Attributes["data-price"].Value;
            string hrefPathString = node.SelectSingleNode(".//p[@class='buk-track-title']").SelectSingleNode("//a").Attributes["href"].Value;
            string artworkSrcString = node.SelectSingleNode(".//img[@class='buk-track-artwork lazy-load']").Attributes["src"].Value;
            string releasedDateString = node.SelectSingleNode(".//p[@class='buk-track-released']").InnerText;
            HtmlNodeCollection? artistsHtmlNodes = node.SelectNodes(".//p[@class='buk-track-artists']/a");
            HtmlNodeCollection? remixersHtmlNodes = node.SelectNodes(".//p[@class='buk-track-remixers']/a");
            IEnumerable<BeatportArtist>? artists = artistsHtmlNodes is not null ? artistsHtmlNodes.Select(a => new BeatportArtist(a, uri)) : new List<BeatportArtist>();
            IEnumerable<BeatportArtist>? remixers = remixersHtmlNodes is not null ? remixersHtmlNodes.Select(a => new BeatportArtist(a, uri)) : new List<BeatportArtist>();
            HtmlNode releaseHtmlNode = node.SelectSingleNode(".//div[@class='buk-track-artwork-parent']").SelectSingleNode("//a");
            string key = node.SelectSingleNode(".//p[@class='buk-track-key']").InnerText;

            Id = int.Parse(node.Attributes["data-ec-id"].Value);
            Url = new Uri(uri, hrefPathString);
            Title = HttpUtility.HtmlDecode(title);
            Version = HttpUtility.HtmlDecode(version);
            Price = HttpUtility.HtmlDecode(price);
            Artists = artists;
            Remixers = remixers;
            Artwork = new BeatportArtwork(new Uri(artworkSrcString));
            Length = default;
            ReleasedDate = BeatportModelHelper.StringToDateTime(HttpUtility.HtmlDecode(releasedDateString));
            Release = new BeatportRelease(releaseHtmlNode, uri);
            Bpm = default;
            Key = HttpUtility.HtmlDecode(key);
            Genre = new BeatportGenre(node.SelectSingleNode(".//p[@class='buk-track-genre']").SelectSingleNode("//a"), uri);
            Label = new BeatportLabel(node.SelectSingleNode(".//p[@class='buk-track-labels']").SelectSingleNode("//a"), uri);
        }

        public Track ToTrack()
        {
            return new Track()
            {
                Uri = Url,
                Title = Title,
                Artists = Artists?.Select(a => a.ToArtist()),
                Remixers = Remixers?.Select(r => r.ToArtist()),
                Year = ReleasedDate.HasValue ? (short)ReleasedDate.Value.Year : null,
                Duration = Length ?? default,
                FileSizeInBytes = default,
                SampleRateInHz = default,
                BitRateInBitsPerSecond = default,
                IsLyricsClean = false,
                InAlbum = Release.ToAlbum(),
                Comments = $"Key {Key}. Version {Version}. Label {Label}. Price {Price}.",
                Genres = Genre is not null ? new List<Genre>() { Genre.ToGenre() } : null,
                Bpm = Bpm is not null ? float.Parse(Bpm) : default,
                Key = Key,
                Version = Version,
            };
        }

        public override string? ToString() => Title;
    }
}
