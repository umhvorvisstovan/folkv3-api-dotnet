namespace Us.FolkV3.Api.Client.Mapper;

internal abstract class ClientMapper<T, U>
    where T : class
    where U : class
{

    public U Map(T value)
    {
        return value == null ? null : DoMap(value);
    }

    protected abstract U DoMap(T value);

}
