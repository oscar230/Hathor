using Hathor.Web.Models.Abstracts.Types;

namespace Hathor.Web.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicAlbum
    /// A collection of music tracks.
    /// </summary>
    internal abstract class MusicAlbum : MusicPlaylist
    {
        /// <summary>
        /// Classification of the album by it's type of content: soundtrack, live album, studio album, etc.
        /// </summary>
        internal MusicAlbumProductionType? AlbumProductionType { get; set; }

        /// <summary>
        /// A release of this album.
        /// Inverse property MusicRelease.ReleaseOf.
        /// </summary>
        internal MusicRelease? AlbumRelease { get; set; }

        /// <summary>
        /// The kind of release which this album is: single, EP or album.
        /// </summary>
        internal MusicAlbumReleaseType? AlbumReleaseType { get; set; }

        /// <summary>
        /// The artist that performed this album or recording.
        /// </summary>
        internal IEnumerable<MusicGroup>? ByArtist { get; set; }
    }
}