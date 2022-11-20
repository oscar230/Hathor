using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxCollections")]
    [XmlRoot(ElementName = "COLLECTION")]
    public class Collection : Base
    {
        [Required]
        [XmlAttribute(AttributeName = "Entries")]
        public string? Entries { get; set; }

        [Required]
        [XmlElement(ElementName = "TRACK")]
        public List<Track>? Tracks { get; set; }
    }
}
