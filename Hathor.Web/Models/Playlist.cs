using Hathor.Web.Helpers;
using Hathor.Web.Models.Abstracts.DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hathor.Web.Models
{
    [Table("Playlists")]
    public class Playlist : SourcedFromWeb
    {
        private const int TitleMaxLength = 150;
        private const int DescriptionMaxLength = 500;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string? Title { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public IEnumerable<Track>? Tracks { get; set; }

        [Url]
        public Uri? ArtworkSourceAsUrl { get; set; }

        public Playlist()
        {
        }

        public Playlist(
            Uri? sourceAsUrl,
            string? title,
            IEnumerable<Track>? tracks,
            string? description = null,
            Uri? artwork = null) : base(sourceAsUrl)
        {
            Title = StringHelpers.Shorten(title, TitleMaxLength);
            Description = StringHelpers.Shorten(description, DescriptionMaxLength);
            Tracks = tracks;
            ArtworkSourceAsUrl = artwork;
        }

        public override string? ToString() => Title;
    }
}
