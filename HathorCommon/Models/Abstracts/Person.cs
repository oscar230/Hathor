namespace Hathor.Common.Models.Abstracts
{
    /// <summary>
    /// https://schema.org/Person
    /// A person (alive, dead, undead, or fictional).
    /// </summary>
    internal class Person : Thing
    {
        /// <summary>
        /// An additional name for a Person, can be used for a middle name.
        /// </summary>
        internal string? AdditionalName { get; set; }

        /// <summary>
        /// Physical address of the item.
        /// </summary>
        internal string? Address { get; set; }

        /// <summary>
        /// An organization that this person is affiliated with. For example, a school/university, a club, or a team.
        /// </summary>
        internal Organization? Affiliation { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        internal DateTime? BirthDate { get; set; }

        /// <summary>
        /// The place where the person was born.
        /// </summary>
        internal string? BirthPlace { get; set; }

        /// <summary>
        /// Date of death.
        /// </summary>
        internal DateTime? DeathDate { get; set; }

        /// <summary>
        /// The place where the person died.
        /// </summary>
        internal string? DeathPlace { get; set; }

        /// <summary>
        /// The Dun & Bradstreet DUNS number for identifying an organization or business person.
        /// https://en.wikipedia.org/wiki/Data_Universal_Numbering_System
        /// The Data Universal Numbering System assigns a unique numeric identifier, referred to as a "DUNS number" to a single business entity.
        /// More than 50 global industry and trade associations recognize, recommend, or require DUNS. The DUNS database contains over 300 million entries for businesses throughout the world.
        /// </summary>
        internal string? Duns { get; set; }

        /// <summary>
        /// Email address.
        /// </summary>
        internal string? Email { get; set; }

        /// <summary>
        /// Family name. In the U.S., the last name of a Person.
        /// </summary>
        internal string? FamilyName { get; set; }

        /// <summary>
        /// Gender of something, typically a Person, but possibly also fictional characters, animals, etc.
        /// While male and female may be used, text strings are also acceptable for people who do not identify as a binary gender.
        /// </summary>
        internal string? Gender { get; set; }

        /// <summary>
        /// Given name. In the U.S., the first name of a Person.
        /// </summary>
        internal string? GivenName { get; set; }

        /// <summary>
        /// The Global Location Number (GLN, sometimes also referred to as International Location Number or ILN) of the respective organization, person, or place.
        /// The GLN is a 13-digit number used to identify parties and physical locations.
        /// https://en.wikipedia.org/wiki/Global_Location_Number
        /// The GS1 Identification Key is used to identify physical locations or legal entities.
        /// The key comprises a GS1 Company Prefix, Location Reference, and Check Digit.
        /// </summary>
        internal string? GlobalLocationNumber { get; set; }

        /// <summary>
        /// A contact location for a person's residence.
        /// </summary>
        internal string? HomeLocation { get; set; }

        /// <summary>
        /// An honorific prefix preceding a Person's name such as Dr/Mrs/Mr.
        /// </summary>
        internal string? HonorificPrefix { get; set; }

        /// <summary>
        /// An honorific suffix following a Person's name such as M.D. /PhD/MSCSW.
        /// </summary>
        internal string? HonorificSuffix { get; set; }

        /// <summary>
        /// The International Standard of Industrial Classification of All Economic Activities (ISIC), Revision 4 code for a particular organization, business person, or place.
        /// </summary>
        internal string? IsicV4 { get; set; }

        /// <summary>
        /// An Organization (or ProgramMembership) to which this Person or Organization belongs.
        /// Inverse property Organization.Member.
        /// </summary>
        internal IEnumerable<Organization>? MemberOf { get; set; }

        /// <summary>
        /// The North American Industry Classification System (NAICS) code for a particular organization or business person.
        /// https://www.naics.com/search/
        /// </summary>
        internal string? Naics { get; set; }

        /// <summary>
        /// Nationality of the person.
        /// </summary>
        internal string? Nationality { get; set; }

        /// <summary>
        /// The Tax / Fiscal ID of the organization or person, e.g. the TIN in the US or the CIF/NIF in Spain.
        /// </summary>
        internal string? TaxID { get; set; }

        /// <summary>
        /// The Value-added Tax ID of the organization or person.
        /// </summary>
        internal string? VatID { get; set; }

        /// <summary>
        /// Organizations that the person works for.
        /// </summary>
        internal IEnumerable<Organization>? WorksFor { get; set; }
    }
}