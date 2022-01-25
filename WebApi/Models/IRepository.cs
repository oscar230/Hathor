namespace WebApi.Models
{
    public interface IRepository
    {
        public Guid Guid { get; }

        public string DisplayName { get; }

        public Uri HomePageUri { get; }
    }
}
