using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxTempos")]
    [XmlRoot(ElementName = "TEMPO")]
	public class Tempo : Base
    {
		[XmlAttribute(AttributeName = "Inizio")]
		public string? Inizio { get; set; }

		[XmlAttribute(AttributeName = "Bpm")]
		public string? Bpm { get; set; }

		[XmlAttribute(AttributeName = "Metro")]
		public string? Metro { get; set; }

		[XmlAttribute(AttributeName = "Battito")]
		public string? Battito { get; set; }
	}
}