namespace Us.FolkV3.Api.Model;

public class PrivateId : Id
{
    public PrivateId(int value) : base(value) { }

    public static PrivateId Create(int value) => new PrivateId(value);

    public static IList<PrivateId> Create(params int[] values)
    {
        return values.Select(e => Create(e)).ToList();
    }
}
