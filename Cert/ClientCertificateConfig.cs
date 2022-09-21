using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace Us.FolkV3.Api.Cert;

public class ClientCertificateConfig
{
    public static string CLIENT_PATH = "FolkV3.ClientKeyStore.Path";
    public static string CLIENT_PATH_ENV = Env.ToEnv(CLIENT_PATH);
    public static readonly string CLIENT_PASSWORD = "FolkV3.ClientKeyStore.Password";
    public static readonly string CLIENT_PASSWORD_ENV = Env.ToEnv(CLIENT_PASSWORD);

    private readonly string _keyStorePath;
    private readonly char[] _keyStorePassword;

    public bool HasCertificate => _keyStorePath != null;
    
    internal ClientCertificateConfig(
        string keyStorePath,
        char[] keyStorePassword
        )
    {
        _keyStorePath = keyStorePath;
        _keyStorePassword = keyStorePassword;
    }

    public static ClientCertificateConfig Load()
    {
        var keyStorePath = Env.Property(CLIENT_PATH);
        var keyStorePassword = Env.Property(CLIENT_PASSWORD);
        if (keyStorePath == null) {
            throw new  CertificateException($"No path parameter supplied ({CLIENT_PATH} or {CLIENT_PATH_ENV})");
        }
        if (keyStorePassword == null) {
            throw new CertificateException($"No password parameter supplied for key store ({CLIENT_PASSWORD} or {CLIENT_PASSWORD_ENV})");
        }
        if (!File.Exists(keyStorePath)) {
            throw new CertificateException(
                $"The client key store file denoted by the path {keyStorePath} does not exist as a regular readable file"
            );
        }
        return new ClientCertificateConfig(keyStorePath, keyStorePassword.ToCharArray());
    }

    public void HandleCertificate<T>(ClientBase<T> client) where T : class
    {
        var certificate = LoadCertificate();
        if (certificate != null)
        {
            client.ClientCredentials.ClientCertificate.Certificate = certificate;
        }
    }
    
    public override string ToString() {
        return $"ClientCertificateConfig(keyStorePath={_keyStorePath})";
    }

    private X509Certificate2 LoadCertificate()
    {
        if (_keyStorePath == null) return null;
        try
        {
            return new X509Certificate2(_keyStorePath, new string(_keyStorePassword));
        }
        catch (Exception e)
        {
            throw new ApplicationException("Could not load client certificate " + _keyStorePath, e);
        }
    }
}
