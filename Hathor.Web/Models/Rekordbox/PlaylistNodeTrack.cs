using Hathor.Web.Models.Abstracts.DB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxPlaylistNodeTracks")]
    [Index(nameof(TrackID))]
    [XmlRoot(ElementName = "TRACK")]
    public class PlaylistNodeTrack : Base
    {
        [Required]
        [XmlAttribute(AttributeName = "Key")]
        public string? TrackID { get; set; }
    }
}