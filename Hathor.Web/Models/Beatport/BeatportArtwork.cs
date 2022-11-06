namespace Hathor.Web.Models.Beatport
{
    internal class BeatportArtwork
    {
        private const int THUMBNAIL_SIZE = 95;
        private const int FULL_SIZE = 1400;
        private const string BASE_PATH = "/image_size/";

        private Uri _uri { get; set; }
        private string _fileName { get; set; }

        internal BeatportArtwork(Uri uri)
        {
            _uri = uri;
            _fileName = uri.PathAndQuery.Split('/').Last();
        }

        internal Uri GetUri(int sizeInPx)
        {
            if (sizeInPx >= THUMBNAIL_SIZE && sizeInPx <= FULL_SIZE)
            {
                return new Uri(_uri, $"{BASE_PATH}{sizeInPx}x{sizeInPx}/{_fileName}");
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Can only request images of minimum {THUMBNAIL_SIZE} pixels and a maximum of {FULL_SIZE} pixels.");
            }
        }

        internal Uri GetThumbnailSize() => GetUri(THUMBNAIL_SIZE);
        internal Uri GetFullSize() => GetUri(FULL_SIZE);
    }
}
