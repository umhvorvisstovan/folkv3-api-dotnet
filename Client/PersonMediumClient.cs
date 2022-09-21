using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;
using Us.FolkV3.Api.Client.Mapper;
using Us.FolkV3.Api.Model;
using AddressParam = Us.FolkV3.Api.Model.Param.AddressParam;
using NameParam = Us.FolkV3.Api.Model.Param.NameParam;
using PersonMedium = Us.FolkV3.Api.Model.PersonMedium;
using PrivateId = Us.FolkV3.Api.Model.PrivateId;
using PublicId = Us.FolkV3.Api.Model.PublicId;

namespace Us.FolkV3.Api.Client;

public class PersonMediumClient : PrivilegesMediumClient
{
    private PersonMediumMapper PersonMapper { get; }

    public PersonMediumClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
        PersonMapper = new PersonMediumMapper();
    }

    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        base.ListOfOperationClasses(operationClasses).AddRange(
            new List<Type>()
            {
                typeof(GetPersonMediumByPrivateId),
                typeof(GetPersonMediumByPublicId),
                typeof(GetPersonMediumByPtal),
                typeof(GetPersonMediumByNameAndAddress),
                typeof(GetPersonMediumByNameAndDateOfBirth),
            });
        return operationClasses;
    }

    public PersonMedium GetPerson(PrivateId id)
    {
        CheckCanUsePrivateId();
        Util.RequireNonNull(id, "id");
        var method = new GetPersonMediumByPrivateId() { request = Mapper.Mapper.PrivateId(id) };
        var request = new GetPersonMediumByPrivateIdRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonMediumByPrivateId = method
        };
        return Call(
            () => webService.GetPersonMediumByPrivateIdAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonMediumByPrivateIdResponse)
            );
    }

    public PersonMedium GetPerson(PublicId id)
    {
        CheckCanUsePublicId();
        Util.RequireNonNull(id, "id");
        var method = new GetPersonMediumByPublicId() { request = Mapper.Mapper.PublicId(id) };
        var request = new GetPersonMediumByPublicIdRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonMediumByPublicId = method
        };
        return Call(
            () => webService.GetPersonMediumByPublicIdAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonMediumByPublicIdResponse)
            );
    }

    public PersonMedium GetPerson(Ptal ptal)
    {
        Util.RequireNonNull(ptal, "ptal");
        var method = new GetPersonMediumByPtal() { request = ptal.Value };
        var request = new GetPersonMediumByPtalRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonMediumByPtal = method
        };
        return Call(
            () => webService.GetPersonMediumByPtalAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonMediumByPtalResponse)
            );
    }

    public PersonMedium GetPerson(NameParam name, AddressParam address)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(address, "address");
        var method = new GetPersonMediumByNameAndAddress()
        {
            request = Mapper.Mapper.NameAndAddressParam(name, address)
        };
        var request = new GetPersonMediumByNameAndAddressRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonMediumByNameAndAddress = method
        };
        return Call(
            () => webService.GetPersonMediumByNameAndAddressAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonMediumByNameAndAddressResponse)
            );
    }

    public PersonMedium GetPerson(NameParam name, DateTime dateOfBirth)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(dateOfBirth, "dateOfBirth");
        var method = new GetPersonMediumByNameAndDateOfBirth()
        {
            request = Mapper.Mapper.NameAndDateOfBirthParam(name, dateOfBirth)
        };
        var request = new GetPersonMediumByNameAndDateOfBirthRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonMediumByNameAndDateOfBirth = method
        };
        return Call(
            () => webService.GetPersonMediumByNameAndDateOfBirthAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonMediumByNameAndDateOfBirthResponse)
            );
    }

}
