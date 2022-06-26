namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportTrack
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal string? Remixed { get; set; }
        internal string? Price { get; set; }
        internal string? ArtistName { get; set; }
        internal int ArtistId { get; set; }
        internal Uri? ArtistUrl { get; set; }
        internal Uri? ArtworkUrl { get; set; }
        internal string? Length { get; set; }
        internal string? Released { get; set; }
        internal string? Bpm { get; set; }
        internal string? Key { get; set; }
        internal string? Genre { get; set; }
        internal Uri? GenreUrl { get; set; }
        internal string? Label { get; set; }
        internal Uri? LabelUri { get; set; }

        public BeatportTrack(string html)
        {
        }
    }
}
