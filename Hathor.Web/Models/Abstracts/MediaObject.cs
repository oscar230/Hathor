namespace Hathor.Web.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MediaObject
    /// A media object, such as an image, video, or audio object embedded in a web page or a downloadable dataset.
    /// </summary>
    internal abstract class MediaObject : CreativeWork
    {
        /// <summary>
        /// The bitrate of the media object.
        /// </summary>
        internal string? Bitrate { get; set; }

        /// <summary>
        /// File size in bytes.
        /// </summary>
        internal long? ContentSize { get; set; }

        /// <summary>
        /// Actual bytes of the media object, for example the image file or video file.
        /// </summary>
        internal Uri? ContentUrl { get; set; }

        /// <summary>
        /// The duration of the item (movie, audio recording, event, etc.).
        /// </summary>
        internal TimeSpan? Duration { get; set; }

        /// <summary>
        /// The CreativeWork encoded by this media object.
        /// Inverse property CreativeWork.Encoding.
        /// </summary>
        internal CreativeWork? EncodesCreativeWork { get; set; }

        /// <summary>
        /// Media type typically expressed using a MIME format e.g. application/zip for a SoftwareApplication binary, audio/mpeg for .mp3 etc.).
        /// In cases where a CreativeWork has several media type representations, encoding can be used to indicate each MediaObject alongside particular encodingFormat information.
        /// </summary>
        internal string? EncodingFormat { get; set; }

        /// <summary>
        /// The height of the item.
        /// </summary>
        internal long Height { get; set; }

        /// <summary>
        /// The production company or studio responsible for the item e.g. series, video game, episode etc.
        /// </summary>
        internal Organization? ProductionCompany { get; set; }

        /// <summary>
        /// The SHA-2 SHA256 hash of the content of the item.
        /// </summary>
        internal string? Sha256 { get; set; }

        /// <summary>
        /// Date when this media object was uploaded to this site.
        /// </summary>
        internal DateTime? UploadDate { get; set; }

        /// <summary>
        /// The width of the item.
        /// </summary>
        internal long Width { get; set; }
    }
}