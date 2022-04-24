namespace HathorCommon.Models
{
    public class Repository
    {
        public Guid Guid { get; }
        public string DisplayName { get; }
        public Uri? HomePageUri { get; }

        public Repository(string guid, string displayName, string homePageUri)
        {
            Guid = Guid.Parse(guid);
            DisplayName = displayName;
            HomePageUri = new Uri(homePageUri);
        }
    }
}
