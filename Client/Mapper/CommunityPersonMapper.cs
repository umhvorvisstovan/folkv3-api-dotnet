using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Model;
using CommunityPerson = Eu.Xroad.UsFolkV3.Producer.CommunityPerson;

namespace Us.FolkV3.Api.Client.Mapper;

internal class CommunityPersonMapper : ClientMapper<CommunityPerson, Model.CommunityPerson>
{
    private PersonSmallMapper PersonMapper { get; }

    public CommunityPersonMapper() {
        PersonMapper = new PersonSmallMapper();
    }

    protected override Model.CommunityPerson DoMap(CommunityPerson value)
    {
        return new Model.CommunityPerson(
                PersonMapper.Map(value.person),
                Mapper.PrivateId(value.existingId),
                Status(value)
                );
    }

    public ResponseWrapper<Model.CommunityPerson> Map(CommunityPersonResponse r)
    {
        return new ResponseWrapper<Model.CommunityPerson>(r, Map(r.result));
    }

    internal static CommunityPersonStatus Status(CommunityPerson person)
    {
        return EnumMapper.CommunityPersonStatus(person.status);
    }
}
