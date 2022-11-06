namespace Hathor.Web.Models.Abstracts.Types
{
    /// <summary>
    /// https://schema.org/MusicAlbumReleaseType
    /// The kind of release which this album is: single, EP or album.
    /// </summary>
    internal enum MusicAlbumReleaseType
    {
        AlbumRelease,
        BroadcastRelease,
        EPRelease,
        SingleRelease
    }
}