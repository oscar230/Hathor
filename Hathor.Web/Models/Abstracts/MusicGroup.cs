namespace Hathor.Web.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicGroup
    /// A musical group, such as a band, an orchestra, or a choir. Can also be a solo musician.
    /// </summary>
    internal abstract class MusicGroup : Organization
    {
        /// <summary>
        /// Music albums.
        /// </summary>
        internal IEnumerable<MusicAlbum>? Albums { get; set; }

        /// <summary>
        /// Genre of the creative work, broadcast channel or group.
        /// </summary>
        internal IEnumerable<string>? Genres { get; set; }

        /// <summary>
        /// A music recording (track)—usually a single song. If an ItemList is given, the list should contain items of type MusicRecording.
        /// </summary>
        internal IEnumerable<MusicRecording>? Tracks { get; set; }
    }
}