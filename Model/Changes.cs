namespace Us.FolkV3.Api.Model;

public class Changes<I> where I : Id
{
    public DateTime From { get; }
    public DateTime To { get; }
    public IList<I> Ids { get; }

    public Changes(DateTime from, DateTime to, IList<I> ids)
    {
        From = Util.RequireNonNull(from, "from");
        To = Util.RequireNonNull(to, "to");
        if (to <= from)
        {
            throw new ArgumentException("from has to be before to");
        }
        Ids = new List<I>(ids).AsReadOnly();
    }
}
