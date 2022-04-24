namespace Hathor.Api.Exceptions
{
    public class TrackStreamTrackFileRepositoryException : Exception, IUserExceptions
    {
        private Uri _uri;

        public TrackStreamTrackFileRepositoryException(Uri uri) : base($"Could not get stream from uri {uri}.")
        {
            _uri = uri;
        }

        public string UserMessage => $"Could not download file from uri {_uri}.";
    }
}
