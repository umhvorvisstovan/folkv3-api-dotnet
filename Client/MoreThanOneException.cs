namespace Us.FolkV3.Api.Client;

public class MoreThanOneException : ResponseStatusException
{
    public MoreThanOneException()
        : base(null, ResponseStatus.MoreThanOne) { }
}
