using System.Xml.Serialization;

namespace Hathor.Common.Models.Rekordbox
{
    [XmlRoot(ElementName = "COLLECTION")]
    public class Collection
    {
        [XmlAttribute(AttributeName = "Entries")]
        public string? Entries { get; set; }

        [XmlElement(ElementName = "TRACK")]
        public List<Track>? Tracks { get; set; }
    }
}
