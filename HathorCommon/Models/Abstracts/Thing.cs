using System;

namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/Thing
    /// The most generic type of item.
    /// </summary>
    internal class Thing
    {
        /// <summary>
        /// An additional type for the item, typically used for adding more specific types from external vocabularies in microdata syntax.
        /// </summary>
        internal Uri? AdditionalType { get; set; }

        /// <summary>
        /// An alias for the item.
        /// </summary>
        internal string? AlternateName { get; set; }

        /// <summary>
        /// A description of the item.
        /// </summary>
        internal string? Description { get; set; }

        /// <summary>
        /// A sub property of description. A short description of the item used to disambiguate from other, similar items.
        /// </summary>
        internal string? DisambiguatingDescription { get; set; }

        /// <summary>
        /// The identifier property represents any kind of identifier for any kind of Thing, such as ISBNs, GTIN codes, UUIDs etc.
        /// </summary>
        internal string? Identifier { get; set; }

        /// <summary>
        /// An image of the item.
        /// </summary>
        internal ImageObject? Image { get; set; }

        /// <summary>
        /// Indicates a page (or other CreativeWork) for which this thing is the main entity being described.
        /// Inverse property CreativeWork.mainEntity.
        /// </summary>
        internal CreativeWork? MainEntityOfPage { get; set; }

        /// <summary>
        /// URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.
        /// </summary>
        internal Uri? SameAs { get; set; }

        /// <summary>
        /// A CreativeWork about this Thing.
        /// Inverse property CreativeWork.About.
        /// </summary>
        internal CreativeWork? SubjectOf { get; set; }

        /// <summary>
        /// URL of the item.
        /// </summary>
        internal Uri? Url { get; set; }
    }
}
