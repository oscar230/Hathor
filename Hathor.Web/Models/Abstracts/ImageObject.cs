namespace Hathor.Web.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/ImageObject
    /// An image file.
    /// </summary>
    internal abstract class ImageObject : MediaObject
    {
        /// <summary>
        /// The caption for this object. For downloadable machine formats (closed caption, subtitles etc.)
        /// </summary>
        internal string? Caption { get; set; }

        /// <summary>
        /// Represents textual captioning from a MediaObject, e.g. text of a 'meme'.
        /// </summary>
        internal string? EmbeddedTextCaption { get; set; }

        /// <summary>
        /// exif data for this object.
        /// </summary>
        internal string? ExifData { get; set; }

        /// <summary>
        /// Indicates whether this image is representative of the content of the page.
        /// </summary>
        internal bool RepresentativeOfPage { get; set; }

        /// <summary>
        /// Thumbnail image for an image or video.
        /// </summary>
        internal ImageObject? Thumbnail { get; set; }
    }
}