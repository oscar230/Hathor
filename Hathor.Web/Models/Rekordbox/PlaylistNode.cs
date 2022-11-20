using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxPlaylistNodes")]
    [XmlRoot(ElementName = "NODE")]
	public class PlaylistNode : Base
	{
		[XmlElement(ElementName = "NODE")]
		public List<PlaylistNode>? PlaylistNodes { get; set; }

		[XmlElement(ElementName = "TRACK")]
		public List<PlaylistNodeTrack>? Tracks { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string? Name { get; set; }

		[XmlAttribute(AttributeName = "Type")]
		public string? Type { get; set; }

		[XmlAttribute(AttributeName = "KeyType")]
		public string? KeyType { get; set; }

		[XmlAttribute(AttributeName = "Entries")]
		public string? Entries { get; set; }
        
		[NotMapped]
        [XmlIgnore]
		public bool IsFolder => Entries is null;

        [NotMapped]
        [XmlIgnore]
		public bool IsPlaylist => Entries is not null;
	}
}