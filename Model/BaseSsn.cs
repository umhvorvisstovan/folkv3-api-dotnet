using System.Text.RegularExpressions;

namespace Us.FolkV3.Api.Model;

public abstract class BaseSsn
{
    public string Value { get; }
    public string FormattedValue { get; }
    protected virtual string Pattern => null;

    protected BaseSsn(string value)
    {
        value = Clean(Util.RequireNonNull(value, "value"));
        if (Pattern != null && !Regex.Match(value, Pattern).Success)
        {
            throw new ArgumentException($"value does not represent a valid {GetType().Name}: {value}");
        }
        Value = value;
        FormattedValue = Format();
    }

    protected virtual String Clean(String value)
    {
        return value;
    }

    protected abstract string Format();

}
