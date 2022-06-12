namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/CreativeWork
    /// The most generic kind of creative work, including books, movies, photographs, software programs, etc.
    /// </summary>
    internal class CreativeWork : Thing
    {
        /// <summary>
        /// The subject matter of the content.
        /// Inverse property Thing.SubjectOf.
        /// </summary>
        internal Thing? About { get; set; }

        /// <summary>
        /// An abstract is a short description that summarizes a CreativeWork.
        /// </summary>
        internal string? Abstract { get; set; }

        /// <summary>
        /// The author of this content or rating.
        /// </summary>
        internal Person? Author { get; set; }

        /// <summary>
        /// Comments, typically from users.
        /// </summary>
        internal IEnumerable<string>? Comment { get; set; }

        /// <summary>
        /// The number of comments this CreativeWork.
        /// </summary>
        internal int CommentCount => Comment is not null ? Comment.Count() : 0;

        /// <summary>
        /// Official rating of a piece of content—for example,'MPAA PG-13'.
        /// </summary>
        internal string? ContentRating { get; set; }

        /// <summary>
        /// The specific time described by a creative work, for works (e.g. articles, video objects etc.) that emphasise a particular moment within an Event.
        /// </summary>
        internal DateTime ContentReferenceTime { get; set; }

        /// <summary>
        /// A secondary contributor to the CreativeWork or Event.
        /// </summary>
        internal Person? Contributor { get; set; }

        /// <summary>
        /// The party holding the legal copyright to the CreativeWork.
        /// </summary>
        internal Organization? CopyrightHolder { get; set; }

        /// <summary>
        /// Text of a notice appropriate for describing the copyright aspects of this Creative Work, ideally indicating the owner of the copyright for the Work.
        /// </summary>
        internal string? CopyrightNotice { get; set; }

        /// <summary>
        /// The year during which the claimed copyright for the CreativeWork was first asserted.
        /// </summary>
        internal short CopyrightYear { get; set; }

        /// <summary>
        /// Indicates a correction to a CreativeWork, either via a CorrectionComment, textually or in another document.
        /// </summary>
        internal string? Correction { get; set; }

        /// <summary>
        /// The country of origin of something, including products as well as creative works such as movie and TV content.
        /// </summary>
        internal string? CountryOfOrigin { get; set; }

        /// <summary>
        /// The status of a creative work in terms of its stage in a lifecycle. Example terms include Incomplete, Draft, Published, Obsolete.
        /// </summary>
        internal string? CreativeWorkStatus { get; set; }

        /// <summary>
        /// Text that can be used to credit person(s) and/or organization(s) associated with a published Creative Work.
        /// </summary>
        internal string? CreditText { get; set; }

        /// <summary>
        /// The date on which the CreativeWork was created or the item was added to a DataFeed.
        /// </summary>
        internal DateTime? DateCreated { get; set; }

        /// <summary>
        /// The date on which the CreativeWork was most recently modified or when the item's entry was modified within a DataFeed.
        /// </summary>
        internal DateTime? DateModified { get; set; }

        /// <summary>
        /// Date of first broadcast/publication.
        /// </summary>
        internal DateTime? DatePublished { get; set; }

        /// <summary>
        /// A link to the page containing the comments of the CreativeWork.
        /// </summary>
        internal Uri? DiscussionUrl { get; set; }

        /// <summary>
        /// An EIDR (Entertainment Identifier Registry) identifier representing a specific edit / edition for a work of film or television.
        /// For example, the motion picture known as "Ghostbusters" whose titleEIDR is "10.5240/7EC7-228A-510A-053E-CBB8-J", has several edits e.g. "10.5240/1F2A-E1C5-680A-14C6-E76B-I" and "10.5240/8A35-3BEE-6497-5D12-9E4F-3".
        /// https://www.eidr.org/
        /// EIDR is the industry-curated public registry of media assets.
        /// </summary>
        internal string? EditEIDR { get; set; }

        /// <summary>
        /// Specifies the Person who edited the CreativeWork.
        /// </summary>
        internal Person? Editor { get; set; }

        /// <summary>
        /// A media object that encodes this CreativeWork. This property is a synonym for associatedMedia.
        /// Inverse property MediaObject.EncodesCreativeWork.
        /// </summary>
        internal IEnumerable<MediaObject>? Encodings { get; set; }

        /// <summary>
        /// Genre of the creative work, broadcast channel or group.
        /// </summary>
        internal string? Genre { get; set; }

        /// <summary>
        /// Indicates an item or CreativeWork that is part of this item, or CreativeWork (in some sense).
        /// Inverse property CreativeWork.IsPartOf.
        /// </summary>
        internal IEnumerable<CreativeWork>? HasPart { get; set; }

        /// <summary>
        /// Headline of the article.
        /// </summary>
        internal string? Headline { get; set; }

        /// <summary>
        /// The language of the content or performance or used in an action.
        /// Please use one of the language codes from the IETF BCP 47 standard.
        /// </summary>
        internal string? InLanguage { get; set; }

        /// <summary>
        /// A flag to signal that the item, event, or place is accessible for free.
        /// </summary>
        internal bool IsAccessibleForFree { get; set; }

        /// <summary>
        /// Indicates whether this content is family friendly.
        /// </summary>
        internal bool IsFamilyFriendly { get; set; }

        /// <summary>
        /// Indicates an item or CreativeWork that this item, or CreativeWork (in some sense), is part of.
        /// Inverse property CreativeWork.HasPart.
        /// </summary>
        internal IEnumerable<CreativeWork>? IsPartOf { get; set; }

        /// <summary>
        /// Keywords or tags used to describe some item. Multiple textual entries in a keywords list are typically delimited by commas, or by repeating the property.
        /// </summary>
        internal string? Keywords { get; set; }

        /// <summary>
        /// A license document that applies to this content, typically indicated by URL.
        /// </summary>
        internal Uri? License { get; set; }

        /// <summary>
        /// The position of an item in a series or sequence of items.
        /// </summary>
        internal int Position { get; set; }

        /// <summary>
        /// The person or organization who produced the work (e.g. music album, movie, tv/radio series etc.).
        /// </summary>
        internal Person? Producer { get; set; }

        /// <summary>
        /// The textual content of this CreativeWork.
        /// </summary>
        internal string? Text { get; set; }

        /// <summary>
        /// A thumbnail image.
        /// </summary>
        internal ImageObject? ThumbnailImage { get; set; }

        /// <summary>
        /// The version of the CreativeWork embodied by a specified resource.
        /// </summary>
        internal string? Version { get; set; }
    }
}