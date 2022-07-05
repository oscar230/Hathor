using Hathor.Common.Models;

namespace Hathor.Metadata.Lib.Helpers.Mappers
{
    internal static class TagLibCommonMapper
    {
        internal static Track MapTagLibFileToTrack(TagLib.File file)
        {
            throw new NotImplementedException();
            return new Track()
            {
                Uri = default,
                Title = default,
                Artists = default,
                Remixers = default,
                Year = default,
                Duration = default,
                FileSizeInBytes = default,
                SampleRateInHz = default,
                BitRateInBitsPerSecond = default,
                LyricVulgarity = default,
                InAlbum = default,
                Comments = default,
                Genres = default,
                Bpm = default,
                Key = default,
                Version = default
            };
        }

        internal static TagLib.File MapTrackToTagLibFile(TagLib.File file, Track track)
        {
            string?[] artists = track?.Artists?.Select(a => a.ToString()).ToArray() ?? Array.Empty<string>();
            string?[] genres = track?.Genres?.Select(g => g.ToString()).ToArray() ?? Array.Empty<string>();
            file.Tag.Title = track?.Title ?? string.Empty;
            file.Tag.Performers = artists;
            file.Tag.AlbumArtists = artists;
            file.Tag.BeatsPerMinute = track?.Bpm is not null ? (uint)track.Bpm : default;
            file.Tag.Comment = track?.Comments ?? string.Empty;
            file.Tag.DateTagged = DateTime.UtcNow;
            file.Tag.Genres = genres;
            return file;
        }
    }
}
