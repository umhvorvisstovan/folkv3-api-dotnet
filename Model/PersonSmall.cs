namespace Us.FolkV3.Api.Model;

public class PersonSmall
{
    public PrivateId PrivateId { get; }
    public Name Name { get; }
    public Gender Gender { get; }
    public Address Address { get; }
    public string PlaceOfBirth { get; }
    public Incapacity Incapacity { get; }
    public SpecialMarks SpecialMarks { get; }
    public DateTime? DateOfDeath { get; }
    public bool IsAlive => DateOfDeath == null;
    public bool IsDead => !IsAlive;
    public bool IsIncapable => Incapacity != null;

    public PersonSmall(PrivateId privateId, Name name, Gender gender, Address address, string placeOfBirth,
        Incapacity incapacity, SpecialMarks specialMarks, DateTime? dateOfDeath)
    {
        PrivateId = privateId;
        Name = name;
        Gender = gender;
        Address = address;
        PlaceOfBirth = placeOfBirth;
        Incapacity = incapacity;
        SpecialMarks = specialMarks;
        DateOfDeath = dateOfDeath;
    }
}
