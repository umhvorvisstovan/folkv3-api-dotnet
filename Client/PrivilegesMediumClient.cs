using Eu.Xroad.UsFolkV3.Producer;
using Us.FolkV3.Api.Cert;

namespace Us.FolkV3.Api.Client;

public abstract class PrivilegesMediumClient : BaseClient
{

    protected PrivilegesMediumClient(HeldinConfig heldinConfig, CertificateConfig certificateConfig)
        : base(heldinConfig, certificateConfig)
    {
    }
    
    protected override List<Type> ListOfOperationClasses(List<Type> operationClasses)
    {
        operationClasses.Add(typeof(GetPrivilegesMedium));
        return operationClasses;
    }

    public override ISet<string> GetRequiredPrivileges()
    {
        var method = new GetPrivilegesMedium();
        var request = new GetPrivilegesMediumRequest()
        {
            client = clientHeader,
            service = ServiceHeader(method.GetType()),
            userId = userIdHeader,
            id = IdHeader(),
            issue = issueHeader,
            protocolVersion = protocolVersionHeader,
            GetPrivilegesMedium = method
        };
        return Call(
            () => webService.GetPrivilegesMediumAsync(request).Result,
            r => new ResponseWrapper<ISet<string>>(
                r.GetPrivilegesMediumResponse,
                r.GetPrivilegesMediumResponse.result.ToHashSet()
                )
            );
    }
}
