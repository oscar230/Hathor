using Hathor.Web.Models.Abstracts.DB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxTracks")]
    [Index(nameof(TrackID), nameof(Artist), nameof(Name), nameof(Remixer), nameof(Genre))]
	[XmlRoot(ElementName = "TRACK")]
	public class Track : Base
    {
		[XmlElement(ElementName = "TEMPO")]
		public Tempo? TEMPO { get; set; }

		[XmlElement(ElementName = "POSITION_MARK")]
		public List<PositionMark>? PositionMarks { get; set; }

		[Required]
		[XmlAttribute(AttributeName = "TrackID")]
		public string? TrackID { get; set; }

		[XmlAttribute(AttributeName = "Name")]
		public string? Name { get; set; }

		[XmlAttribute(AttributeName = "Artist")]
		public string? Artist { get; set; }

		[XmlAttribute(AttributeName = "Composer")]
		public string? Composer { get; set; }

		[XmlAttribute(AttributeName = "Album")]
		public string? Album { get; set; }

		[XmlAttribute(AttributeName = "Grouping")]
		public string? Grouping { get; set; }

		[XmlAttribute(AttributeName = "Genre")]
		public string? Genre { get; set; }

		[XmlAttribute(AttributeName = "Kind")]
		public string? Kind { get; set; }

		[XmlAttribute(AttributeName = "Size")]
		public string? Size { get; set; }

		[XmlAttribute(AttributeName = "TotalTime")]
		public string? TotalTime { get; set; }

		[XmlAttribute(AttributeName = "DiscNumber")]
		public string? DiscNumber { get; set; }

		[XmlAttribute(AttributeName = "TrackNumber")]
		public string? TrackNumber { get; set; }

		[XmlAttribute(AttributeName = "Year")]
		public string? Year { get; set; }

		[XmlAttribute(AttributeName = "AverageBpm")]
		public string? AverageBpm { get; set; }

		[XmlAttribute(AttributeName = "DateAdded")]
		public string? DateAdded { get; set; }

		[XmlAttribute(AttributeName = "BitRate")]
		public string? BitRate { get; set; }

		[XmlAttribute(AttributeName = "SampleRate")]
		public string? SampleRate { get; set; }

		[XmlAttribute(AttributeName = "Comments")]
		public string? Comments { get; set; }

		[XmlAttribute(AttributeName = "PlayCount")]
		public string? PlayCount { get; set; }

		[XmlAttribute(AttributeName = "Rating")]
		public string? Rating { get; set; }

		[XmlAttribute(AttributeName = "Location")]
		public string? Location { get; set; }

		[XmlAttribute(AttributeName = "Remixer")]
		public string? Remixer { get; set; }

		[XmlAttribute(AttributeName = "Tonality")]
		public string? Tonality { get; set; }

		[XmlAttribute(AttributeName = "Label")]
		public string? Label { get; set; }

		[XmlAttribute(AttributeName = "Mix")]
		public string? Mix { get; set; }
	}
}