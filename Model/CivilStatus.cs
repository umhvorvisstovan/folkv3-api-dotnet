namespace Us.FolkV3.Api.Model;

public class CivilStatus
{
    public CivilStatusType Type { get; }
    public DateTime From { get; }

    public CivilStatus(CivilStatusType type, DateTime from)
    {
        Type = Util.RequireNonNull(type, "type");
        From = Util.RequireNonNull(from, "from");
    }
}
