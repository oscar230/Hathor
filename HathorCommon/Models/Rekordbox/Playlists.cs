using System.Xml.Serialization;

namespace Hathor.Common.Models.Rekordbox
{
    public class Playlists
    {
        [XmlElement(ElementName = "NODE")]
        public PlaylistNode? PlaylistNode { get; set; }
    }
}