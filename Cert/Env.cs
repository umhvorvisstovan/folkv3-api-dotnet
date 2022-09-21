using System.Configuration;

namespace Us.FolkV3.Api.Cert;

public static class Env
{
    public static string Property(string name) {
        var value = ConfigurationManager.AppSettings[name];
        if (value == null) value = Environment.GetEnvironmentVariable(ToEnv(name));
        return value;
    }

    public static string ToEnv(string name) {
        return name.ToUpper().Replace('.', '_');
    }

}
