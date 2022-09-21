namespace Us.FolkV3.Api.Model;

public class Cpr : BaseSsn
{
    protected override string Pattern => @"\d{10}";

    private Cpr(string value)
        : base(value) { }

    public static Cpr Create(string value) => new Cpr(value);

    protected override string Format()
    {
        return $"{Value.Substring(0, 6)}-{Value.Substring(6)}";
    }
}
