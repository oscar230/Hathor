namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicRelease
    /// A MusicRelease is a specific release of a music album.
    /// </summary>
    internal abstract class MusicRelease : MusicPlaylist
    {
        /// <summary>
        /// The catalog number for the release.
        /// </summary>
        internal string? CatalogNumber { get; set; }

        /// <summary>
        /// The group the release is credited to if different than the byArtist.
        /// For example, Red and Blue is credited to "Stefani Germanotta Band", but by Lady Gaga.
        /// </summary>
        internal Person? CreditedTo { get; set; }

        /// <summary>
        /// The duration of the item (movie, audio recording, event, etc.).
        /// </summary>
        internal TimeSpan? Duration { get; set; }

        /// <summary>
        /// Format of this release (the type of recording media used, ie. compact disc, digital media, LP, etc.).
        /// </summary>
        internal MusicReleaseFormatType? MusicReleaseFormat { get; set; }

        /// <summary>
        /// The label that issued the release.
        /// </summary>
        internal Organization? RecordLabel { get; set; }

        /// <summary>
        /// The album this is a release of.
        /// Inverse property MusicAlbum.AlbumRelease.
        /// </summary>
        internal MusicAlbum? ReleaseOf { get; set; }
    }
}