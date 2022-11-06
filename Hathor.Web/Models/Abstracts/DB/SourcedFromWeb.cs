using System.ComponentModel.DataAnnotations;

namespace Hathor.Web.Models.Abstracts.DB
{
    public class SourcedFromWeb : Base
    {
        [Url]
        public Uri? SourceAsUrl { get; set; }

        [Required]
        public DateTimeOffset? SourcedDateTime { get; set; }

        public SourcedFromWeb()
        {
        }

        public SourcedFromWeb(Uri? sourceAsUrl)
        {
            SourceAsUrl = sourceAsUrl;
            SourcedDateTime = DateTimeOffset.UtcNow;
        }
    }
}
