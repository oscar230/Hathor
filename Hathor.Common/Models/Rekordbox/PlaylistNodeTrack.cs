using System.Xml.Serialization;

namespace Hathor.Common.Models.Rekordbox
{
    [XmlRoot(ElementName = "TRACK")]
    public class PlaylistNodeTrack
    {
        [XmlAttribute(AttributeName = "Key")]
        public string? TrackID { get; set; }
    }
}