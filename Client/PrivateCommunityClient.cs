using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;
using Us.FolkV3.Api.Client.Mapper;
using Us.FolkV3.Api.Model;
using AddressParam = Us.FolkV3.Api.Model.Param.AddressParam;
using CommunityPerson = Us.FolkV3.Api.Model.CommunityPerson;
using NameParam = Us.FolkV3.Api.Model.Param.NameParam;
using PrivateId = Us.FolkV3.Api.Model.PrivateId;

namespace Us.FolkV3.Api.Client;

public class PrivateCommunityClient : PrivilegesSmallClient
{
    private CommunityPersonMapper CommunityMapper { get; }
    private PrivateChangesMapper ChangesMapper { get; }

    public PrivateCommunityClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
        CommunityMapper = new CommunityPersonMapper();
        ChangesMapper = new PrivateChangesMapper();
        CheckCanUseCommunityMethods();
    }

    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        base.ListOfOperationClasses(operationClasses).AddRange(
            new List<Type>()
            {
                typeof(AddPersonToCommunityByNameAndAddress),
                typeof(AddPersonToCommunityByNameAndDateOfBirth),
                typeof(RemovePersonsFromCommunity),
                typeof(GetPrivateChanges),
            });
        return operationClasses;
    }

    public CommunityPerson AddPersonToCommunity(NameParam name, AddressParam address)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(address, "address");
        var method = new AddPersonToCommunityByNameAndAddress()
        {
            request = Mapper.Mapper.NameAndAddressParam(name, address)
        };
        var request = new AddPersonToCommunityByNameAndAddressRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            AddPersonToCommunityByNameAndAddress = method
        };
        return Call(
            () => webService.AddPersonToCommunityByNameAndAddressAsync(request).Result,
            (r) => CommunityMapper.Map(r.AddPersonToCommunityByNameAndAddressResponse)
            );
    }

    public CommunityPerson AddPersonToCommunity(NameParam name, DateTime dateOfBirth)
    {
        Util.RequireNonNull(name, "name");
        Util.RequireNonNull(dateOfBirth, "dateOfBirth");
        var method = new AddPersonToCommunityByNameAndDateOfBirth()
        {
            request = Mapper.Mapper.NameAndDateOfBirthParam(name, dateOfBirth)
        };
        var request = new AddPersonToCommunityByNameAndDateOfBirthRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            AddPersonToCommunityByNameAndDateOfBirth = method
        };
        return Call(
            () => webService.AddPersonToCommunityByNameAndDateOfBirthAsync(request).Result,
            r => CommunityMapper.Map(r.AddPersonToCommunityByNameAndDateOfBirthResponse)
            );
    }

    public PrivateId RemovePersonFromCommunity(PrivateId id)
    {
        var removedIds = RemovePersonsFromCommunity(new List<PrivateId> { id });
        return removedIds.Count == 0 ? null : removedIds[0];
    }

    public IList<PrivateId> RemovePersonsFromCommunity(IList<PrivateId> ids)
    {
        Util.RequireNonNull(ids, "ids");
        var method = new RemovePersonsFromCommunity();
        var request = new RemovePersonsFromCommunityRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            RemovePersonsFromCommunity = method
        };
        return Call(
            () => webService.RemovePersonsFromCommunityAsync(request).Result,
            r => new ResponseWrapper<IList<PrivateId>>(
                r.RemovePersonsFromCommunityResponse,
                Mapper.Mapper.PrivateIds(r.RemovePersonsFromCommunityResponse.result)
                )
            );
    }

    public Changes<PrivateId> GetChanges(DateTime from)
    {
        return GetChanges(from, DateTime.Now);
    }

    public Changes<PrivateId> GetChanges(DateTime from, DateTime to)
    {
        Util.RequireNonNull(from, "from");
        Util.RequireNonNull(to, "to");
        var method = new GetPrivateChanges()
        {
            request = Mapper.Mapper.ChangesParam(from, to)
        };
        var request = new GetPrivateChangesRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPrivateChanges = method
        };
        return Call(
            () => webService.GetPrivateChangesAsync(request).Result,
            r => new ResponseWrapper<Changes<PrivateId>>(
                r.GetPrivateChangesResponse,
                ChangesMapper.Map(r.GetPrivateChangesResponse.result)
                )
            );
    }

}
