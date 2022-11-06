using Hathor.Web.Models;
using System.Linq;

namespace Hathor.Web.Helpers
{
    internal static class MetadataTagHelper
    {
        internal static Track ToTrack(TagLib.File file, Uri? sourceAsUrl, Track? overwriteTrack = null)
        {
            const char artistSeparator = ',';
            IEnumerable<Artist> artists;
            if (file.Tag.Performers.Any())
            {
                artists = file.Tag.Performers.Select(artistName => new Artist(sourceAsUrl, artistName));
            }
            else
            {
                artists = file.Tag.AlbumArtists.Select(artistName => new Artist(sourceAsUrl, artistName));
            }
            IEnumerable<Artist> remixers;
            if (file.Tag.RemixedBy.Contains(artistSeparator).Equals(0))
            {
                remixers = new Artist[]
                {
                    new Artist(sourceAsUrl, file.Tag.RemixedBy)
                };
            }
            else
            {
                remixers = file.Tag.RemixedBy
                    .Split(artistSeparator)
                    .Where(remixerName => remixerName.Length > 0)
                    .Select(remixerName => new Artist(sourceAsUrl, remixerName));
            }
            IEnumerable<Genre> genres = file.Tag.Genres.Select(genreTitle => new Genre(sourceAsUrl, genreTitle));
            string? version = TrackHelper.GetVersion(file.Name);
            if (overwriteTrack is null)
            {
                return new Track()
                {
                    SourceAsUrl = sourceAsUrl,
                    Title = file.Tag.Title,
                    Artists = artists,
                    Remixers = remixers,
                    Year = (short)file.Tag.Year,
                    Duration = file.Properties.Duration,
                    FileSizeInBytes = file.Length,
                    SampleRateInHz = file.Properties.AudioSampleRate,
                    BitRateInBitsPerSecond = file.Properties.AudioBitrate,
                    LyricVulgarity = TrackHelper.GetLyricVulgarity(file.Name),
                    InAlbum = file.Tag.Album.Any() ? new Album(sourceAsUrl, file.Tag.Album) : default,
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
                    overwriteTrack.InAlbum = new Album(sourceAsUrl, file.Tag.Album);
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
