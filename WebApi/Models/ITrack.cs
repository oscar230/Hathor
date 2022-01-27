namespace WebApi.Models
{
    public interface ITrack
    {
        string InternalId { get; }
        
        string DisplayName { get; }

        IRepository FromRepository { get; }

        string DownloadUriBase64 { get; }

        Uri DownloadUri { get; }
    }
}
