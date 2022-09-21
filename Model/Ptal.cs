namespace Us.FolkV3.Api.Model;

public class Ptal : BaseSsn
{
    protected override string Pattern { get; } = @"\d{9}";

    public Ptal(string value) : base(value) { }

    public static Ptal Create(string value)
    {
        return new Ptal(value);
    }

    protected override string Clean(string value)
    {
        return value.Replace("-", "");
    }

    protected override string Format()
    {
        return $"{Value.Substring(0, 6)}-{Value.Substring(6)}";
    }
}
