namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicPlaylist
    /// A collection of music tracks in playlist form.
    /// </summary>
    internal class MusicPlaylist : CreativeWork
    {
        /// <summary>
        /// The number of tracks in this album or playlist.
        /// </summary>
        internal int NumTracks => Tracks is not null ? Tracks.Count() : 0;

        /// <summary>
        /// A music recording (track)—usually a single song. If an ItemList is given, the list should contain items of type MusicRecording.
        /// </summary>
        internal IEnumerable<MusicRecording>? Tracks { get; set; }
    }
}
