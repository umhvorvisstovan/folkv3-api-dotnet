namespace Us.FolkV3.Api.Model;

public class PublicId : Id
{
    public PublicId(int value) : base(value) { }

    public static PublicId Create(int value) => new PublicId(value);

    public static IList<PublicId> Create(params int[] values)
    {
        return values.Select(e => Create(e)).ToList();
    }

}
