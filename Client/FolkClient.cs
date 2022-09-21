using Us.FolkV3.Api.Cert;

namespace Us.FolkV3.Api.Client;

public static class FolkClient
{

    public static PersonSmallClient PersonSmall(HeldinConfig heldinConfig, CertificateConfig certificateConfig = null)
    {
        return new PersonSmallClient(heldinConfig, CertificateConfig(heldinConfig, certificateConfig));
    }

    public static PersonMediumClient PersonMedium(HeldinConfig heldinConfig, CertificateConfig certificateConfig = null)
    {
        return new PersonMediumClient(heldinConfig, CertificateConfig(heldinConfig, certificateConfig));
    }

    public static PrivateCommunityClient PrivateCommunity(HeldinConfig heldinConfig, CertificateConfig certificateConfig = null)
    {
        return new PrivateCommunityClient(heldinConfig, CertificateConfig(heldinConfig, certificateConfig));
    }

    public static PublicCommunityClient PublicCommunity(HeldinConfig heldinConfig, CertificateConfig certificateConfig = null)
    {
        return new PublicCommunityClient(heldinConfig, CertificateConfig(heldinConfig, certificateConfig));
    }
    
    private static CertificateConfig CertificateConfig(HeldinConfig heldinConfig, CertificateConfig certificateConfig) {
        return certificateConfig ?? (heldinConfig.Secure ? Cert.CertificateConfig.TrustAll() : null);
    }

}
