namespace Us.FolkV3.Api.Model;

public class Incapacity
{
    public Guardian Guardian1 { get; }
    public Guardian Guardian2 { get; }

    public Incapacity(Guardian guardian1, Guardian guardian2 = null)
    {
        Guardian1 = Util.RequireNonNull(guardian1, "guardian1");
        Guardian2 = guardian2;
    }
}
