namespace Hathor.Beatport.Lib.Models
{
    internal class BeatportRelease
    {
        internal int Id { get; set; }
        internal Uri? Url { get; set; }
        internal string? Title { get; set; }
        internal string? Price { get; set; }
        internal IEnumerable<Uri>? TrackUrls { get; set; }
        internal int NumOfTracks { get => TrackUrls is not null ? TrackUrls.Count() : 0; }
        internal string? ReleaseDate { get; set; }
        internal string? Label { get; set; }
        internal Uri? LabelUrl { get; set; }
        internal string? Catalog { get; set; }
        internal Uri? ArtworkUrl { get; set; }
    }
}
