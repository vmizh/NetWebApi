namespace Common.Helper.API;

public struct APIRequest
{
    public APIRequest()
    {
        DbId = default;
        RequestData = null;
    }

    public Guid DbId { set; get; }
    public object Id { set; get; } = 0;
    public object? RequestData { set; get; }
    public Dictionary<string, object> RequestParams { set; get; } = [];
}
