using Eu.Xroad.UsFolkV3.Producer;

namespace Us.FolkV3.Api.Client.Mapper;

internal class PersonSmallMapper : PersonBaseMapper<PersonSmall, Model.PersonSmall>
{
    protected override Model.PersonSmall DoMap(PersonSmall value)
    {
        return new Model.PersonSmall(
            Mapper.PrivateId(value),
            Mapper.Name(value),
            Mapper.Gender(value),
            Mapper.Address(value),
            value.placeOfBirth,
            Mapper.Incapacity(value),
            Mapper.SpecialMarks(value),
            Mapper.DateOfDeath(value.dateOfDeath)
        );
    }

    public ResponseWrapper<Model.PersonSmall> Map(PersonSmallResponse r)
    {
        return new ResponseWrapper<Model.PersonSmall>(r, Map(r.result));
    }
}
