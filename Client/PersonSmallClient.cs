using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;
using Us.FolkV3.Api.Client.Mapper;
using Us.FolkV3.Api.Model;
using AddressParam = Us.FolkV3.Api.Model.Param.AddressParam;
using NameParam = Us.FolkV3.Api.Model.Param.NameParam;
using PersonSmall = Us.FolkV3.Api.Model.PersonSmall;
using PrivateId = Us.FolkV3.Api.Model.PrivateId;

namespace Us.FolkV3.Api.Client;

public class PersonSmallClient : PrivilegesSmallClient
{
    private PersonSmallMapper PersonMapper { get; }

    public PersonSmallClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
        PersonMapper = new PersonSmallMapper();
    }

    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        base.ListOfOperationClasses(operationClasses).AddRange(
            new List<Type>()
            {
                typeof(GetPersonSmallByPrivateId),
                typeof(GetPersonSmallByPtal),
                typeof(GetPersonSmallByNameAndAddress),
                typeof(GetPersonSmallByNameAndDateOfBirth),
                typeof(GetPrivateChanges)
            });
        return operationClasses;
    }

    public PersonSmall GetPerson(PrivateId id)
    {
        Util.RequireNonNull(id, "id");
        var method = new GetPersonSmallByPrivateId() { request = Mapper.Mapper.PrivateId(id) };
        var request = new GetPersonSmallByPrivateIdRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonSmallByPrivateId = method
        };
        return Call(
            () => webService.GetPersonSmallByPrivateIdAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonSmallByPrivateIdResponse)
            );
    }

    public PersonSmall GetPerson(Ptal ptal)
    {
        Util.RequireNonNull(ptal, "ptal");
        var method = new GetPersonSmallByPtal() { request = ptal.Value };
        var request = new GetPersonSmallByPtalRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonSmallByPtal = method
        };
        return Call(
            () => webService.GetPersonSmallByPtalAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonSmallByPtalResponse)
            );
    }

    public PersonSmall GetPerson(NameParam name, AddressParam address)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(address, "address");
        var method = new GetPersonSmallByNameAndAddress()
        {
            request = Mapper.Mapper.NameAndAddressParam(name, address)
        };
        var request = new GetPersonSmallByNameAndAddressRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonSmallByNameAndAddress = method
        };
        return Call(
            () => webService.GetPersonSmallByNameAndAddressAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonSmallByNameAndAddressResponse)
            );
    }

    public PersonSmall GetPerson(NameParam name, DateTime dateOfBirth)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(dateOfBirth, "dateOfBirth");
        var method = new GetPersonSmallByNameAndDateOfBirth()
        {
            request = Mapper.Mapper.NameAndDateOfBirthParam(name, dateOfBirth)
        };
        var request = new GetPersonSmallByNameAndDateOfBirthRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPersonSmallByNameAndDateOfBirth = method
        };
        return Call(
            () => webService.GetPersonSmallByNameAndDateOfBirthAsync(request).Result,
            r => PersonMapper.Map(r.GetPersonSmallByNameAndDateOfBirthResponse)
            );
    }

}
