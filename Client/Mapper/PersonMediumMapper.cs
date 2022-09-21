using Eu.Xroad.UsFolkV3.Producer;

namespace Us.FolkV3.Api.Client.Mapper;

internal class PersonMediumMapper : PersonBaseMapper<PersonMedium, Model.PersonMedium>
{
    protected override Model.PersonMedium DoMap(PersonMedium value)
    {
        return new Model.PersonMedium(
            Mapper.PrivateId(value),
            Mapper.PublicId(value),
            Mapper.Ptal(value),
            Mapper.Name(value),
            Mapper.DateOfBirth(value.dateOfBirth),
            Mapper.Gender(value),
            Mapper.Address(value),
            value.placeOfBirth,
            Mapper.SpecialMarks(value),
            Mapper.Incapacity(value),
            Mapper.CivilStatus(value),
            Mapper.DateOfDeath(value.dateOfDeath)
        );
    }

    public ResponseWrapper<Model.PersonMedium> Map(PersonMediumResponse r)
    {
        return new ResponseWrapper<Model.PersonMedium>(r, Map(r.result));
    }
}
