namespace Us.FolkV3.Api.Model;

public class Country
{
    public string Code { get; }
    public string NameFo { get; }
    public string NameEn { get; }

    public Country(string code, string nameFo, string nameEn)
    {
        Code = Util.RequireNonNull(code, "code");
        NameFo = Util.RequireNonNull(nameFo, "nameFo");
        NameEn = Util.RequireNonNull(nameEn, "nameEn");
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public override bool Equals(object that)
    {
        if (this == that)
        {
            return true;
        }
        if (!(that is Country))
        {
            return false;
        }
        var other = (Country)that;
        return Equals(Code, other.Code);
    }
}
