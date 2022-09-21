using System.Net;

namespace Us.FolkV3.Api.Cert;

public static class TlsProtocol
{
    public static readonly TlsProtocolVersion DefaultTlsProtocol = TlsProtocolVersion.TLSv13;

    public static TlsProtocolVersion From(string value)
    {
        if (value == "TLSv1.2" || value == "TLS1.2" || value == "TLS12") return TlsProtocolVersion.TLSv12;
        if (value == "TLSv1.3" || value == "TLS1.3" || value == "TLS13") return TlsProtocolVersion.TLSv13;
        throw new ArgumentException("Invalid TLS protocol value: " + value);
    }
    
    public static SecurityProtocolType SecurityProtocol(TlsProtocolVersion? tlsProtocol)
    {
        tlsProtocol = tlsProtocol ?? DefaultTlsProtocol;
        if (tlsProtocol == TlsProtocolVersion.TLSv12) return SecurityProtocolType.Tls12;
        if (tlsProtocol == TlsProtocolVersion.TLSv13) return SecurityProtocolType.Tls13;
        throw new ArgumentException("Invalid TLS protocol: " + tlsProtocol);
    }
}

public enum TlsProtocolVersion
{
    TLSv12, TLSv13
}
