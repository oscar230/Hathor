using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxPositionMarks")]
    [XmlRoot(ElementName = "POSITION_MARK")]
	public class PositionMark : Base
	{
		[XmlAttribute(AttributeName = "Name")]
		public string? Name { get; set; }

		[XmlAttribute(AttributeName = "Type")]
		public string? Type { get; set; }

		[XmlAttribute(AttributeName = "Start")]
		public string? Start { get; set; }

		[XmlAttribute(AttributeName = "Num")]
		public string? Num { get; set; }

		[XmlAttribute(AttributeName = "Red")]
		public string? Red { get; set; }

		[XmlAttribute(AttributeName = "Green")]
		public string? Green { get; set; }

		[XmlAttribute(AttributeName = "Blue")]
		public string? Blue { get; set; }
	}
}