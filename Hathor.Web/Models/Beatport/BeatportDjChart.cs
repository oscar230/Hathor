﻿using Hathor.Web.Mappers;
using HtmlAgilityPack;

namespace Hathor.Web.Models.Beatport
{
    internal class BeatportDjChart
    {
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal Artist? CreatedByArtist { get; set; }
        internal Uri? CreatedByUserImage { get; set; }
        internal BeatportArtwork? Artwork { get; set; }
        internal string? DateCreated { get; set; }
        internal IEnumerable<BeatportGenre>? Genres { get; set; }
        internal string? Description { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<BeatportTrack>? Tracks { get; set; }

        internal BeatportDjChart(HtmlDocument htmlDocument, Uri uri)
        {
            throw new NotImplementedException();
        }

        internal Playlist ToPlaylist()
        {
            return new Playlist()
            {
                SourceAsUrl = Url,
                Title = Title,
                Description = $"Beatport DJ Chart by {CreatedByArtist?.Name ?? "NO NAME"} at date {DateCreated}.",
                Tracks = Tracks?.Select(beatportTrack => BeatportMapper.ToTrack(beatportTrack)),
                ArtworkSourceAsUrl = Artwork?.GetFullSize() ?? null,
            };
        }

        public override string? ToString() => Title;
    }
}
