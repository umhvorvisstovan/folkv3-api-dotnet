using System;

namespace Us.FolkV3.Api.Client;

public class FolkApiException : Exception
{
    public FolkApiException(string message) : base(message) { }
    public FolkApiException(string message, Exception innerException) : base(message, innerException) { }
}
