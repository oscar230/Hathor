using Hathor.Common.Helpers;
using Hathor.Common.Models;

namespace Hathor.Metadata.Lib.Helpers.Mappers
{
    internal static class TagMapper
    {
        internal static Track ToTrack(TagLib.File file, Track? overwriteTrack = null)
        {
            const char artistSeparator = ',';
            IEnumerable<Artist> artists = file.Tag.Performers.Any() ? file.Tag.Performers.Select(a => new Artist(a)) : (file.Tag.AlbumArtists.Select(a => new Artist(a)) ?? Array.Empty<Artist>());
            IEnumerable<Artist> remixers = file.Tag.RemixedBy.Contains(artistSeparator).Equals(0) ? new Artist[] { new Artist(file.Tag.RemixedBy) } : file.Tag.RemixedBy.Split(artistSeparator).Where(r => r.Length > 0).Select(r => new Artist(r));
            IEnumerable<Genre> genres = file.Tag.Genres.Select(g => new Genre(g));
            string? version = TrackHelper.GetVersion(file.Name);
            if (overwriteTrack is null)
            {
                return new Track()
                {
                    Uri = default,
                    Title = file.Tag.Title,
                    Artists = artists,
                    Remixers = remixers,
                    Year = (short)file.Tag.Year,
                    Duration = file.Properties.Duration,
                    FileSizeInBytes = file.Length,
                    SampleRateInHz = file.Properties.AudioSampleRate,
                    BitRateInBitsPerSecond = file.Properties.AudioBitrate,
                    LyricVulgarity = TrackHelper.GetLyricVulgarity(file.Name),
                    InAlbum = file.Tag.Album.Any() ? new Album(file.Tag.Album) : default,
                    Comments = file.Properties.Description,
                    Genres = genres,
                    Bpm = file.Tag.BeatsPerMinute,
                    Key = file.Tag.InitialKey,
                    Version = version ?? string.Empty,
                };
            }
            else
            {
                if (artists.Any())
                {
                    overwriteTrack.Artists = artists;
                }
                if (remixers.Any())
                {
                    overwriteTrack.Remixers = remixers;
                }
                overwriteTrack.Year = (short)file.Tag.Year;
                overwriteTrack.Duration = file.Properties.Duration;
                overwriteTrack.FileSizeInBytes = file.Length;
                overwriteTrack.SampleRateInHz = file.Properties.AudioSampleRate;
                overwriteTrack.BitRateInBitsPerSecond = file.Properties.AudioBitrate;
                overwriteTrack.LyricVulgarity = TrackHelper.GetLyricVulgarity(file.Name);
                if (file.Tag.Album.Any())
                {
                    overwriteTrack.InAlbum = new Album(file.Tag.Album);
                }
                overwriteTrack.Comments = file.Properties.Description;
                overwriteTrack.Genres = genres;
                overwriteTrack.Bpm = file.Tag.BeatsPerMinute;
                overwriteTrack.Key = file.Tag.InitialKey;
                if (version is not null)
                {
                    overwriteTrack.Version = version;
                }
                return overwriteTrack;
            }
        }

        internal static TagLib.File TrackToFile(TagLib.File file, Track track)
        {
            IEnumerable<string>? artists = track.Artists?.Select(a => a.ToString() ?? string.Empty).Where(s => !string.IsNullOrWhiteSpace(s));
            IEnumerable<string>? remixers = track.Remixers?.Select(r => r.Name ?? string.Empty).Where(s => !string.IsNullOrWhiteSpace(s));
            IEnumerable<string>? genres = track.Genres?.Select(g => g.ToString() ?? string.Empty).Where(s => !string.IsNullOrWhiteSpace(s));
            file.Tag.Title = track.Title ?? string.Empty;
            file.Tag.Performers = artists?.ToArray() ?? Array.Empty<string>();
            file.Tag.AlbumArtists = artists?.ToArray() ?? Array.Empty<string>();
            file.Tag.Genres = genres?.ToArray() ?? Array.Empty<string>();
            file.Tag.BeatsPerMinute = track.Bpm is not null ? (uint)track.Bpm : default;
            file.Tag.Comment = string.Join(", ", (new string[] { track.Comments ?? string.Empty, track.Version ?? string.Empty, track.LyricVulgarity != LyricVulgarity.Unknown ? track.LyricVulgarity.ToString() : string.Empty}).Where(t => !string.IsNullOrWhiteSpace(t)));
            file.Tag.DateTagged = DateTime.UtcNow;
            file.Tag.Year = track.Year is not null ? (uint)track.Year : default;
            file.Tag.Album = track.InAlbum?.Title ?? string.Empty;
            file.Tag.BeatsPerMinute = Convert.ToUInt32(track.Bpm ?? 0.0f);
            file.Tag.InitialKey = track.Key ?? string.Empty;
            return file;
        }
    }
}
