namespace Us.FolkV3.Api.Cert;

public class CertificateException : Exception
{
    public CertificateException(string message, Exception innerException = null)
        : base(message, innerException)
    {
    }
}