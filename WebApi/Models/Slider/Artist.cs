namespace WebApi.Models.Slider
{
    public class Artist : IArtist
    {
        public const string ARTIST_TRACK_SEPARATOR = " - ";
        
        private const char ARTISTS_SEPARATOR = ',';
        private Guid _guid;
        private string _name;

        public Artist(string name)
        {
            _guid = Guid.NewGuid();
            _name = name;
        }

        public Guid Guid => _guid;

        public string Name => _name;

        public static IEnumerable<IArtist> ParseArtistsFromFullTitle(string fullTitle)
        {
            if (fullTitle.Contains(ARTIST_TRACK_SEPARATOR))
            {
                var splitted = fullTitle.Split(ARTIST_TRACK_SEPARATOR);
                if (splitted?.Length == 2)
                {
                    if (splitted[1].Contains(ARTISTS_SEPARATOR))
                    {
                        var artists = splitted[1].Split(ARTISTS_SEPARATOR);
                        if (artists?.Length > 0)
                        {
                            return artists.Select(a => new Artist(a));
                        }
                    }
                    else
                    {
                        return new IArtist[1]
                        {
                            new Artist(splitted[1])
                        };
                    }
                }
            }
            throw new ArgumentException($"Could not parse artists from {fullTitle}.");
        }
    }
}
