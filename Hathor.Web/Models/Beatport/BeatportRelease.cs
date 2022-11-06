using Hathor.Common.Models;
using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportRelease
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<BeatportTrack>? Tracks { get; set; }
        internal string? ReleaseDate { get; set; }
        internal string? Label { get; set; }
        internal Uri? LabelUrl { get; set; }
        internal string? Catalog { get; set; }
        internal BeatportArtwork? Artwork { get; set; }

        public BeatportRelease(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        public BeatportRelease(HtmlNode node, Uri uri)
        {
            string uriString = node.Attributes["href"].Value;
            Id = int.Parse(uriString.Split('/').Last());
            Url = new Uri(uri, uriString);
        }

        internal Album ToAlbum()
        {
            return new Album()
            {
                Uri = Url,
                Title = Title,
                Artwork = Artwork?.GetFullSize() ?? null,
                Tracks = Tracks?.Select(t => t.ToTrack()),
                Artists = null,
                Labels = null
            };
        }

        public override string? ToString() => Title;
    }
}
