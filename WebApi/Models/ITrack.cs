namespace WebApi.Models
{
    public interface ITrack
    {
        Guid Guid { get; }

        string InternalID { get; }
        
        string DisplayName { get; }

        IRepository FromRepository { get; }

        Uri DownloadUri { get; }
    }
}
