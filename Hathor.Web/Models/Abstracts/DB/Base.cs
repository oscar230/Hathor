using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Hathor.Web.Models.Abstracts.DB
{
    public abstract class Base
    {
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; }
    }
}
