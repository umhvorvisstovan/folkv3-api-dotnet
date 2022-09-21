using System.Net;
using System.ServiceModel;

namespace Us.FolkV3.Api.Cert;

public class CertificateConfig
{
    public static readonly string TLS_PROTOCOL = "FolkV3.TlsProtocol";
    public static readonly string TLS_PROTOCOL_ENV = Env.ToEnv(TLS_PROTOCOL);

    private readonly ServerCertificateConfig _serverCertificateConfig;
    private readonly ClientCertificateConfig _clientCertificateConfig;
    private readonly TlsProtocolVersion _tlsProtocol;
    
    public bool HasClientCertificate => _clientCertificateConfig != null && _clientCertificateConfig.HasCertificate;
    
    internal CertificateConfig(
        ServerCertificateConfig serverCertificateConfig,
        ClientCertificateConfig clientCertificateConfig,
        TlsProtocolVersion? tlsProtocol
        )
    {
        _clientCertificateConfig = clientCertificateConfig;
        _serverCertificateConfig = serverCertificateConfig ?? new ServerCertificateConfig(null);
        _tlsProtocol = tlsProtocol ?? TlsProtocol.DefaultTlsProtocol;
        SetSecurityProtocol(_tlsProtocol);
    }

    public static CertificateConfigBuilder Builder()
    {
        return new CertificateConfigBuilder();
    }

    public static CertificateConfig TrustAll() {
        return new CertificateConfig(
            null,
            null,
            LoadTlsProtocol()
        );
    }

    public static CertificateConfig LoadClientCertificate() {
        return new CertificateConfig(
            null,
            ClientCertificateConfig.Load(),
            LoadTlsProtocol()
        );
    }

    public static CertificateConfig LoadServerCertificate() {
        return new CertificateConfig(
            ServerCertificateConfig.Load(),
            null,
            LoadTlsProtocol()
        );
    }

    public static CertificateConfig LoadClientAndServerCertificate() {
        return new CertificateConfig(
            ServerCertificateConfig.Load(),
            ClientCertificateConfig.Load(),
            LoadTlsProtocol()
        );
    }

    public override string ToString()
    {
        return $"CertificateConfig(serverCertificateConfig={_serverCertificateConfig}, clientCertificateConfig={_clientCertificateConfig}, tlsProtocol={_tlsProtocol})";
    }

    public void HandleCertificates<T>(ClientBase<T> client) where T : class
    {
        _clientCertificateConfig?.HandleCertificate(client);
        _serverCertificateConfig?.HandleCertificate(client);
    }
    
    private static void SetSecurityProtocol(TlsProtocolVersion? tlsProtocol = null)
    {
        ServicePointManager.SecurityProtocol = TlsProtocol.SecurityProtocol(tlsProtocol);
    }
  
    private static TlsProtocolVersion? LoadTlsProtocol() {
        var envTlsProtocol = Env.Property(TLS_PROTOCOL);
        if (envTlsProtocol == null) return null;
        try {
            return TlsProtocol.From(envTlsProtocol);
        } catch (Exception) {
            throw new CertificateException($"Invalid parameter supplied ({TLS_PROTOCOL} or {TLS_PROTOCOL_ENV}) - value: {envTlsProtocol}");
        }
    }
}

public class CertificateConfigBuilder {

    private string _clientKeyStorePath;
    private char[] _clientKeyStorePassword;
    private string _serverCertificatePath;
    private TlsProtocolVersion _tlsProtocol;
    
    public CertificateConfigBuilder ClientKeyStorePath(string clientKeyStorePath) {
        _clientKeyStorePath = clientKeyStorePath;
        return this;
    }
    
    public CertificateConfigBuilder ClientKeyStorePassword(string clientKeyStorePassword) {
        return ClientKeyStorePassword(clientKeyStorePassword.ToCharArray());
    }
    
    public CertificateConfigBuilder ClientKeyStorePassword(char[] clientKeyStorePassword) {
        _clientKeyStorePassword = new char[clientKeyStorePassword.Length]; 
        clientKeyStorePassword.CopyTo(_clientKeyStorePassword, 0);
        return this;
    }
    
    public CertificateConfigBuilder ServerCertificatePath(string serverCertificatePath) {
        _serverCertificatePath = serverCertificatePath;
        return this;
    }
    
    public CertificateConfigBuilder TlsProtocol(string tlsProtocol) {
        return TlsProtocol(Cert.TlsProtocol.From(tlsProtocol));
    }
    
    public CertificateConfigBuilder TlsProtocol(TlsProtocolVersion tlsProtocol) {
        _tlsProtocol = tlsProtocol;
        return this;
    }
    
    public CertificateConfig Build() {
        return new CertificateConfig(
                _serverCertificatePath == null ? null : new ServerCertificateConfig(_serverCertificatePath),
                _clientKeyStorePath == null ? null : new ClientCertificateConfig(
                        _clientKeyStorePath, _clientKeyStorePassword),
                _tlsProtocol
        );
    }
}
