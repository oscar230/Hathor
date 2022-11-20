using Hathor.Web.Models;
using Hathor.Web.Models.Beatport;

namespace Hathor.Web.Mappers
{
    internal static class BeatportMapper
    {
        internal static Track ToTrack(BeatportTrack beatportTrack)
        {
            return new Track()
            {
                SourceAsUrl = beatportTrack.Url,
                Title = beatportTrack.Title,
                Artists = beatportTrack.Artists?.Select(a => a.ToArtist()),
                Remixers = beatportTrack.Remixers?.Select(r => r.ToArtist()),
                Year = beatportTrack.ReleasedDate.HasValue ? (short)beatportTrack.ReleasedDate.Value.Year : null,
                Duration = beatportTrack.Length ?? default,
                FileSizeInBytes = default,
                SampleRateInHz = default,
                BitRateInBitsPerSecond = default,
                InAlbum = beatportTrack.Release.ToAlbum(),
                Comments = $"Key {beatportTrack.Key}. Version {beatportTrack.Version}. Label {beatportTrack.Label}. Price {beatportTrack.Price}.",
                Genres = beatportTrack.Genre is not null ? new List<Genre>() { beatportTrack.Genre.ToGenre() } : null,
                Bpm = beatportTrack.Bpm is not null ? float.Parse(beatportTrack.Bpm) : default,
                Key = beatportTrack.Key,
                Version = beatportTrack.Version,
            };
        }
    }
}
