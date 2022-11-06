using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    public class Playlists
    {
        [XmlElement(ElementName = "NODE")]
        public PlaylistNode? PlaylistNode { get; set; }
    }
}