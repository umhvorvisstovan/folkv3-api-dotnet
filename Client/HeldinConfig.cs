using System.Text.RegularExpressions;

namespace Us.FolkV3.Api.Client;

public class HeldinConfig
{
    private static readonly Identifier DEFAULT_SERVICE = Identifier.Parse("FO/GOV/405388/us-folk-v3");

    public string Host { get; }
    public bool Secure { get; }
    public Identifier Service { get; }
    public Identifier Client { get; }
    public string UserId { get; }

    private HeldinConfig(string host, bool secure, Identifier service, Identifier client, string userId)
    {
        Host = host;
        Secure = secure;
        Service = service;
        Client = client;
        UserId = userId;
    }

    public static HeldinConfig Create(string host, bool secure, string clientPath)
    {
        return Create(host, secure, Identifier.Parse(clientPath));
    }

    public static HeldinConfig Create(string host, bool secure, Identifier clientIdentifier)
    {
        var serviceIdentifier = clientIdentifier.Prod ? DEFAULT_SERVICE : DEFAULT_SERVICE.WithEnv(clientIdentifier);
        return new HeldinConfig(host, secure, serviceIdentifier, clientIdentifier, null);
    }

    public static B0 ForHost(String host)
    {
        return new Builder(host, false);
    }

    public static B0 ForSecureHost(String host)
    {
        return new Builder(host, true);
    }

    public HeldinConfig WithUserId(string userId)
    {
        return new HeldinConfig(Host, Secure, Service, Client, userId);
    }

    public override string ToString()
    {
        return $"host: {Host}; secure: {Secure}; service: {Service}; client: {Client}; userId: {UserId}";
    }

    public interface B0
    {
        B1 Fo();
    }
    public interface B1
    {
        B2 Dev();
        B2 Test();
        B2 Prod();
    }
    public interface B2
    {
        B3 Com();
        B3 Gov();
    }
    public interface B3
    {
        B4 MemberCode(String memberCode);
    }
    public interface B4
    {
        HeldinConfig SubSystemCode(String subSystemCode);
        HeldinConfig NoSubSystemCode();
    }
    public class Builder : B0, B1, B2, B3, B4 {

        private string host;
        private bool secure;
        private string xRoadInstancePrefix;
        private string envSuffix;
        private string memberClass;
        private string memberCodeValue;
        internal Builder(String host, bool secure)
        {
            this.host = host;
            this.secure = secure;
        }
    
        public B1 Fo()
        {
            xRoadInstancePrefix = "FO";
            return this;
        }
        public B2 Dev()
        {
            envSuffix = "-DEV";
            return this;
        }
        public B2 Test()
        {
            envSuffix = "-TST";
            return this;
        }
        public B2 Prod()
        {
            envSuffix = "";
            return this;
        }
        public B3 Com()
        {
            memberClass = "COM";
            return this;
        }
        public B3 Gov()
        {
            memberClass = "GOV";
            return this;
        }
        public B4 MemberCode(String memberCode)
        {
            memberCodeValue = memberCode;
            return this;
        }
        public HeldinConfig SubSystemCode(String subSystemCode)
        {
            return Create(host, secure, xRoadInstancePrefix + envSuffix + '/'
                                        + memberClass + '/' + memberCodeValue + '/' + subSystemCode);
        }
        public HeldinConfig NoSubSystemCode()
        {
            return Create(host, secure, xRoadInstancePrefix + envSuffix + '/'
                                        + memberClass + '/' + memberCodeValue);
        }
    }

    public class Identifier
    {
        private static readonly Regex REGEX = new Regex("/");
        public string XRoadInstancePrefix { get; }
        public string Env { get; }
        public string MemberClass { get; }
        public string MemberCode { get; }
        public string SubSystemCode { get; }
        public string XRoadInstance { get; }
        public string Path { get; }
        public bool Dev { get; }
        public bool Test { get; }
        public bool Prod { get; }
        internal Identifier(string xRoadInstancePrefix, string env, string memberClass, string memberCode, string subSystemCode)
        {
            XRoadInstancePrefix = xRoadInstancePrefix;
            Env = env;
            MemberClass = memberClass;
            MemberCode = memberCode;
            SubSystemCode = subSystemCode;
            XRoadInstance = xRoadInstancePrefix + (env.Equals("PROD") ? "" : '-' + env);
            Path = XRoadInstance + '/' + memberClass + '/' + memberCode
                + (string.IsNullOrWhiteSpace(subSystemCode) ? "" : '/' + subSystemCode);
        }
        public static Identifier Parse(string path)
        {
            var parts = IdentifierParts(path);
            var xRoadInstance = parts[0];
            var memberClass = parts[1];
            var memberCode = parts[2];
            var subSystemCode = parts[3];
            var envSepIdx = xRoadInstance.IndexOf('-');
            var env = envSepIdx == -1 ? "PROD" : xRoadInstance.Substring(envSepIdx + 1);
            var xRoadInstancePrefix = envSepIdx == -1 ? xRoadInstance : xRoadInstance.Substring(0, envSepIdx);
            return new Identifier(xRoadInstancePrefix, env, memberClass, memberCode, subSystemCode);
        }
        public Identifier WithEnv(Identifier identifier)
        {
            return new Identifier(XRoadInstancePrefix, identifier.Env, MemberClass, MemberCode, SubSystemCode);
        }
        public override String ToString()
        {
            return Path;
        }
        private static String[] IdentifierParts(string path)
        {
            var parts = REGEX.Split(path);
            if (parts.Length != 4)
            {
                throw new ArgumentException(
                        "path has to be of the form xRoadInstance/memberClass/memberCode/subSystemCode - actual "
                        + path);
            }
            return parts;
        }

    }
}
