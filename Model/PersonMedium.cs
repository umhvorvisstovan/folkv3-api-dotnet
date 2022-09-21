namespace Us.FolkV3.Api.Model;

public class PersonMedium : PersonSmall
{
    public PublicId PublicId { get; }
    public Ptal Ptal { get; }
    public DateTime? DateOfBirth { get; }
    public CivilStatus CivilStatus { get; }

    public PersonMedium(PrivateId privateId, PublicId publicId, Ptal ptal, Name name, DateTime? dateOfBirth,
        Gender gender, Address address, string placeOfBirth, SpecialMarks specialMarks, Incapacity incapacity,
        CivilStatus civilStatus, DateTime? dateOfDeath)
        : base(privateId, name, gender, address, placeOfBirth, incapacity, specialMarks, dateOfDeath)
    {
        PublicId = publicId;
        Ptal = ptal;
        DateOfBirth = dateOfBirth;
        CivilStatus = civilStatus;
    }

}
