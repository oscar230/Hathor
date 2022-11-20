using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hathor.Web.Models
{
    [Table("Artists")]
    public class Artist : SourcedFromWeb
    {
        private const int NameMaxLength = 150;

        [Required]
        [MaxLength(NameMaxLength)]
        public string? Name { get; set; }

        public Artist()
        {
        }

        public Artist(Uri? sourceAsUrl, string? name) : base(sourceAsUrl)
        {
            Name = StringHelpers.Shorten(name, NameMaxLength);
        }

        public override string? ToString() => Name;
    }
}
