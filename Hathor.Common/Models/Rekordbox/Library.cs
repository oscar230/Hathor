using System.Xml.Serialization;

namespace Hathor.Common.Models.Rekordbox
{
    [XmlRoot(ElementName = "DJ_PLAYLISTS")]
    public class Library
    {
        [XmlAttribute(AttributeName = "Version")]
        public string? Version { get; set; }

        [XmlElement(ElementName = "PRODUCT")]
        public Product? Product { get; set; }

        [XmlElement(ElementName = "COLLECTION")]
        public Collection? Collection { get; set; }

        [XmlElement(ElementName = "PLAYLISTS")]
        public Playlists? Playlists { get; set; }
    }
}
