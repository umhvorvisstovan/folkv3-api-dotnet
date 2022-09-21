namespace Us.FolkV3.Api.Client;

public class ResponseStatusException : FolkApiException
{

    public ResponseStatus ResponseStatus { get; }

    public ResponseStatusException(string message, ResponseStatus responseStatus)
        : base(responseStatus + " - " + message)
    {
        ResponseStatus = responseStatus;
    }

}
