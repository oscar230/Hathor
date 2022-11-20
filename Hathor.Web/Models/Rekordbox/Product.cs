using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxProducts")]
    [XmlRoot(ElementName = "PRODUCT")]
    public class Product : Base
    {
        [Required]
        [XmlAttribute(AttributeName = "Name")]
        public string? Name { get; set; }

        [Required]
        [XmlAttribute(AttributeName = "Version")]
        public string? Version { get; set; }

        [Required]
        [XmlAttribute(AttributeName = "Company")]
        public string? Company { get; set; }
    }
}