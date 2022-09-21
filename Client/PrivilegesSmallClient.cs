using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;

namespace Us.FolkV3.Api.Client;

public abstract class PrivilegesSmallClient : BaseClient
{

    protected PrivilegesSmallClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
    }

    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        operationClasses.Add(typeof(GetPrivilegesSmall));
        return operationClasses;
    }

    public override ISet<string> GetRequiredPrivileges()
    {
        var method = new GetPrivilegesSmall();
        var request = new GetPrivilegesSmallRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPrivilegesSmall = method
        };
        return Call(
            () => webService.GetPrivilegesSmallAsync(request).Result,
            r => new ResponseWrapper<ISet<string>>(
                r.GetPrivilegesSmallResponse,
                r.GetPrivilegesSmallResponse.result.ToHashSet()
                )
            );
    }
}
