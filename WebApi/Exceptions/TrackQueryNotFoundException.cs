using System.Runtime.Serialization;
using WebApi.Models;

namespace WebApi.Exceptions
{
    public class TrackDownloadFailedException : Exception, IUserExceptions
    {
        private readonly ITrack _track;

        public TrackDownloadFailedException(ITrack track) : base($"Download of track: {track.DisplayName} ({track.InternalId}) failed.")
        {
            _track = track;
        }

        public string UserMessage => $"The track {_track.DisplayName} could not be downloaded from track repository {_track.FromRepository.DisplayName}.";
    }
}
