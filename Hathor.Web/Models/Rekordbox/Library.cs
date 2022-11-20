using Hathor.Web.Models.Abstracts.DB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxLibraries")]
    [Index(nameof(UploadDateTimeOffset))]
    [XmlRoot(ElementName = "DJ_PLAYLISTS")]
    public class Library : Base
    {
        [Required]
        [XmlAttribute(AttributeName = "Version")]
        public string? Version { get; set; }

        [Required]
        [XmlElement(ElementName = "PRODUCT")]
        public Product? Product { get; set; }

        [Required]
        [XmlElement(ElementName = "COLLECTION")]
        public Collection? Collection { get; set; }

        [Required]
        [XmlElement(ElementName = "PLAYLISTS")]
        public Playlists? Playlists { get; set; }

        [Required]
        [XmlIgnore]
        public DateTimeOffset UploadDateTimeOffset { get; set; }
    }
}
