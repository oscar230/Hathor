namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/Organization
    /// An organization such as a school, NGO, corporation, club, etc.
    /// </summary>
    internal class Organization : Thing
    {
        /// <summary>
        /// The date that this organization was founded.
        /// </summary>
        internal DateTime FoundingDate { get; set; }

        /// <summary>
        /// The International Standard of Industrial Classification of All Economic Activities (ISIC), Revision 4 code for a particular organization, business person, or place.
        /// </summary>
        internal string? IsicV4 { get; set; }

        /// <summary>
        /// An organization identifier as defined in ISO 6523(-1).
        /// </summary>
        internal string? Iso6523Code { get; set; }

        /// <summary>
        /// Keywords or tags used to describe some item. Multiple textual entries in a keywords list are typically delimited by commas, or by repeating the property.
        /// </summary>
        internal string? Keywords { get; set; }

        /// <summary>
        /// Of a Person, and less typically of an Organization, to indicate a topic that is known about - suggesting possible expertise but not implying it.
        /// </summary>
        internal string? KnowsAbout { get; set; }

        /// <summary>
        /// Of a Person, and less typically of an Organization, to indicate a known language.
        /// Use language codes from the IETF BCP 47 standard.
        /// </summary>
        internal string? KnowsLanguage { get; set; }

        /// <summary>
        /// The official name of the organization, e.g. the registered company name.
        /// </summary>
        internal string? LegalName { get; set; }

        /// <summary>
        /// An organization identifier that uniquely identifies a legal entity as defined in ISO 17442.
        /// https://en.wikipedia.org/wiki/Legal_Entity_Identifier#Code_structure
        /// </summary>
        internal string? LeiCode { get; set; }

        /// <summary>
        /// The location of, for example, where an event is happening, where an organization is located, or where an action takes place.
        /// </summary>
        internal string? Location { get; set; }

        /// <summary>
        /// An associated logo.
        /// </summary>
        internal ImageObject? Logo { get; set; }

        /// <summary>
        /// A member of an Organization or a ProgramMembership. Organizations can be members of organizations; ProgramMembership is typically for individuals.
        /// Inverse property: memberOf
        /// </summary>
        internal Organization? Member { get; set; }

        /// <summary>
        /// An Organization (or ProgramMembership) to which this Person or Organization belongs.
        /// Inverse property Organization.Member.
        /// </summary>
        internal Organization? MemberOf { get; set; }

        /// <summary>
        /// The North American Industry Classification System (NAICS) code for a particular organization or business person.
        /// https://www.naics.com/search/
        /// </summary>
        internal string? Naics { get; set; }

        /// <summary>
        /// The larger organization that this organization is a subOrganization of, if any.
        /// Inverse property Organization.SubOrganization.
        /// </summary>
        internal Organization? ParentOrganization { get; set; }

        /// <summary>
        /// The publishingPrinciples property indicates (typically via URL) a document describing the editorial principles of an Organization.
        /// </summary>
        internal CreativeWork? PublishingPrinciples { get; set; }

        /// <summary>
        /// A slogan or motto associated with the item.
        /// </summary>
        internal string? Slogan { get; set; }

        /// <summary>
        /// A relationship between two organizations where the first includes the second, e.g., as a subsidiary.
        /// </summary>
        internal IEnumerable<Organization>? SubOrganizations { get; set; }

        /// <summary>
        /// The Tax / Fiscal ID of the organization or person, e.g. the TIN in the US or the CIF/NIF in Spain.
        /// </summary>
        internal string? TaxID { get; set; }

        /// <summary>
        /// The Value-added Tax ID of the organization or person.
        /// </summary>
        internal string? VatID { get; set; }
    }
}