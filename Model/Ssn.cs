namespace Us.FolkV3.Api.Model;

public class Ssn : BaseSsn
{
    public Country Country { get; }

    public Ssn(string value, Country country)
        : base(value)
    {
        Country = Util.RequireNonNull(country, "country");
    }

    protected override string Format() => Value;
}
