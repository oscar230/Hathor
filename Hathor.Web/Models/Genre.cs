using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hathor.Web.Models
{
    [Table("Genres")]
    public class Genre : SourcedFromWeb
    {
        private const int TitleMaxLength = 150;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        public override string? ToString() => Title;

        public Genre()
        {
        }

        public Genre(Uri? sourceAsUrl, string? title) : base(sourceAsUrl)
        {
            Title = StringHelpers.Shorten(title, TitleMaxLength);
        }
    }
}