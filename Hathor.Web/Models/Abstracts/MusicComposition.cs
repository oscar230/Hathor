namespace Hathor.Web.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/MusicComposition
    /// A musical composition.
    /// </summary>
    internal abstract class MusicComposition : CreativeWork
    {
        /// <summary>
        /// The person or organization who wrote a composition, or who is the composer of a work performed at some event.
        /// </summary>
        internal Person? Composer { get; set; }

        /// <summary>
        /// Smaller compositions included in this work (e.g. a movement in a symphony).
        /// </summary>
        internal IEnumerable<MusicComposition>? IncludedCompositions { get; set; }

        /// <summary>
        /// The International Standard Musical Work Code for the composition.
        /// https://www.iswc.org/
        /// The ISWC (International Standard Musical Work Code) is a unique, permanent and internationally recognized reference number for the identification of musical works.
        /// Example: T-303.211.468-0
        /// </summary>
        internal string? IswcCode { get; set; }

        /// <summary>
        /// The person who wrote the words.
        /// </summary>
        internal Person? Lyricist { get; set; }

        /// <summary>
        /// The words in the song.
        /// </summary>
        internal CreativeWork? Lyrics { get; set; }

        /// <summary>
        /// An arrangement derived from the composition.
        /// </summary>
        internal IEnumerable<MusicComposition>? MusicArrangements { get; set; }

        /// <summary>
        /// The type of composition (e.g. overture, sonata, symphony, etc.).
        /// </summary>
        internal string? MusicCompositionForm { get; set; }

        /// <summary>
        /// The key, mode, or scale this composition uses.
        /// </summary>
        internal string? MusicalKey { get; set; }

        /// <summary>
        /// An audio recording of the work.
        /// Inverse property MusicRecording.RecordingOf.
        /// </summary>
        internal IEnumerable<MusicRecording>? RecordedAs { get; set; }
    }
}