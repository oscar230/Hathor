using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hathor.Web.Models
{
    [Table("Albums")]
    public class Album : SourcedFromWeb
    {
        private const int TitleMaxLength = 200;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [Url]
        public Uri? ArtworkSourceAsUrl { get; set; }
        public IEnumerable<Track>? Tracks { get; set; }
        public IEnumerable<Artist>? Artists { get; set; }
        public IEnumerable<Label>? Labels { get; set; }

        public Album()
        {
        }

        public Album(
            Uri? sourceAsUrl = null,
            string? title = null,
            IEnumerable<Track>? tracks = null,
            IEnumerable<Artist>? artists = null) : base(sourceAsUrl)
        {
            Title = StringHelpers.Shorten(title, TitleMaxLength);
            Tracks = tracks;
            Artists = artists;
        }
    }
}