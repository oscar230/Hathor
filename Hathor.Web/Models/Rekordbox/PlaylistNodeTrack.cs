using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [XmlRoot(ElementName = "TRACK")]
    public class PlaylistNodeTrack
    {
        [XmlAttribute(AttributeName = "Key")]
        public string? TrackID { get; set; }
    }
}