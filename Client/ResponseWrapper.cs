using Eu.Xroad.UsFolkV3.Producer;

namespace Us.FolkV3.Api.Client;

public class ResponseWrapper<T>
{
    private readonly ResponseBase responseBase;
    public T Result { get; }
    public string Status { get { return this.responseBase.status; } }
    public string Message { get { return this.responseBase.message; } }

    public ResponseWrapper(ResponseBase responseBase, T result)
    {
        Result = result;
        this.responseBase = responseBase;
    }
}
