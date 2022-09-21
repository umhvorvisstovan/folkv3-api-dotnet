namespace Us.FolkV3.Api.Model.Param;

public class NameParam
{
    public string First { get; }
    public string Last { get; }

    public NameParam(string first, string last)
    {
        First = Util.RequireNonNull(first, "first");
        Last = Util.RequireNonNull(last, "last");
    }

    public static NameParam Create(string first, string last) =>
        new NameParam(first, last);
}
