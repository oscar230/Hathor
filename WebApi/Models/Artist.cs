namespace HathorCommon.Models
{
    public class Artist
    {
        public Guid? Guid { get; }
        public string? Name { get; }
        
        public Artist(string? name)
        {
            Guid = new Guid();
            Name = name;
        }
    }
}
