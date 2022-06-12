namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicRecording
    /// A music recording (track), usually a single song.
    /// </summary>
    internal class MusicRecording : CreativeWork
    {
        /// <summary>
        /// The artist that performed this album or recording.
        /// </summary>
        internal IEnumerable<MusicGroup>? ByArtists { get; set; }

        /// <summary>
        /// The duration of the item.
        /// </summary>
        internal TimeSpan? Duration { get; set; }

        /// <summary>
        /// The album to which this recording belongs.
        /// </summary>
        internal MusicAlbum? InAlbum { get; set; }

        /// <summary>
        /// The playlist to which this recording belongs.
        /// </summary>
        internal MusicPlaylist? InPlaylist { get; set; }

        /// <summary>
        /// The International Standard Recording Code for the recording.
        /// https://isrc.ifpi.org/en/
        /// ISRC identifies sound recordings and music videos.
        /// ISRC is not used to identify compositions/musical works, music products or performers.
        /// https://isrc.ifpi.org/en/isrc-standard/structure
        /// Visually presented as: ISRC AA-6Q7-20-00047
        /// AA6Q7 - Prefix Code - two letters followed by three alphanumeric characters – total five characters.
        /// 20 - two digits, 20 meaning the year 2020.
        /// 00047 - Designation Code - five digits
        /// </summary>
        internal string? IsrcCode { get; set; }

        /// <summary>
        /// The composition this track is a recording of.
        /// Inverse property MusicComposition.recordedAs.
        /// </summary>
        internal MusicComposition? RecordingOf { get; set; }
    }
}