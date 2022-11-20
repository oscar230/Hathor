using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hathor.Web.Models
{
    [Table("RecordLabels")]
    public class Label : SourcedFromWeb
    {
        private const int TitleMaxLength = 150;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [Url]
        public Uri? ArtworkSourceAsUrl { get; set; }

        public Label(Uri? sourceAsUrl, string? title, Uri? artwork) : base(sourceAsUrl)
        {
            Title = StringHelpers.Shorten(title, TitleMaxLength);
            ArtworkSourceAsUrl = artwork;
        }
    }
}
