namespace WebApi.Models
{
    public interface ITrackAtRepository : ITrack
    {
        string InternalID { get; }
        
        string DisplayName { get; }

        IRepository FromRepository { get; }
    }
}
