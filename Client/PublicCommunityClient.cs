using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;
using Us.FolkV3.Api.Client.Mapper;
using Us.FolkV3.Api.Model;
using PublicId = Us.FolkV3.Api.Model.PublicId;

namespace Us.FolkV3.Api.Client;

public class PublicCommunityClient : PrivilegesMediumClient
{
    private PublicChangesMapper ChangesMapper { get; }

    public PublicCommunityClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
        ChangesMapper = new PublicChangesMapper();
        CheckCanGetPublicChanges();
    }

    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        base.ListOfOperationClasses(operationClasses).Add(typeof(GetPublicChanges));
        return operationClasses;
    }

    public Changes<PublicId> GetChanges(DateTime from)
    {
        return GetChanges(from, DateTime.Now);
    }

    public Changes<PublicId> GetChanges(DateTime from, DateTime to)
    {
        Util.RequireNonNull(from, "from");
        Util.RequireNonNull(to, "to");
        var method = new GetPublicChanges() {
            request = Mapper.Mapper.ChangesParam(from, to)
        };
        var request = new GetPublicChangesRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPublicChanges = method
        };
        return Call(
            () => webService.GetPublicChangesAsync(request).Result,
            r => new ResponseWrapper<Changes<PublicId>>(
                r.GetPublicChangesResponse,
                ChangesMapper.Map(r.GetPublicChangesResponse.result)
                )
            );
    }

}
