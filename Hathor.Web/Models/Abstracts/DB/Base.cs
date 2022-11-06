using System.ComponentModel.DataAnnotations;

namespace Hathor.Web.Models.Abstracts.DB
{
    public abstract class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
