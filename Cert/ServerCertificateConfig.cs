using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using Microsoft.IdentityModel.Tokens;

namespace Us.FolkV3.Api.Cert;

public class ServerCertificateConfig
{
    public static readonly string SERVER_PATH = "FolkV3.serverCertificate.Path";
    public static readonly string SERVER_PATH_ENV = Env.ToEnv(SERVER_PATH);

    private readonly string _certificatePath;

    internal ServerCertificateConfig(string certificatePath)
    {
        _certificatePath = certificatePath;
    }
    
    public static ServerCertificateConfig Load()
    {
        var path = Env.Property(SERVER_PATH);
        if (path == null) {
            throw new CertificateException($"No path parameter supplied ({SERVER_PATH} or {SERVER_PATH_ENV})");
        }
        if (!File.Exists(path)) {
            throw new CertificateException(
                $"The server certificate file denoted by the path {path} does not exist as a regular readable file"
            );
        }
        return new ServerCertificateConfig(path);
    }

    public override string ToString() {
        return $"ServerCertificateConfig(certificatePath={_certificatePath})";
    }

    public void HandleCertificate<T>(ClientBase<T> client) where T : class
    {
        client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
        {
            CertificateValidationMode = X509CertificateValidationMode.Custom,
            RevocationMode = X509RevocationMode.NoCheck,
            CustomCertificateValidator = new ServerCertificateValidator(LoadCertificate())
        };
    }

    private X509Certificate LoadCertificate()
    {
        if (_certificatePath == null) return null;
        try
        {
            return new X509Certificate(_certificatePath);
        }
        catch (Exception e)
        {
            throw new CertificateException("Could not load server certificate " + _certificatePath, e);
        }
    }
}

internal class ServerCertificateValidator : X509CertificateValidator
{
    private readonly string _certificateHash;

    internal ServerCertificateValidator(X509Certificate certificate = null)
    {
        _certificateHash = certificate?.GetRawCertDataString();
    }
    public override void Validate(X509Certificate2 certificate)
    {
        if (_certificateHash != null && _certificateHash != certificate.GetRawCertDataString())
        {
            throw new SecurityTokenValidationException("Unknown certificate");
        }
    }
}
