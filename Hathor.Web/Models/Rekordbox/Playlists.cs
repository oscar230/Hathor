using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Rekordbox
{
    [Table("RekordboxPlaylists")]
    public class Playlists : Base
    {
        [XmlElement(ElementName = "NODE")]
        public PlaylistNode? PlaylistNode { get; set; }
    }
}