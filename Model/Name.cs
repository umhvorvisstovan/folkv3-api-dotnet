namespace Us.FolkV3.Api.Model;

public class Name
{
    public string First { get; }
    public string Middle { get; }
    public string Last { get; }
    public string Official { get; }

    public Name(string first, string middle, string last, string official)
    {
        First = first;
        Middle = middle;
        Last = last;
        Official = official;
    }

    public bool IsComplete() => First != null && Last != null && Official != null;

    public override string ToString() => Official;
}
