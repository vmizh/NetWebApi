namespace Common.Helper.API;

public record IdentityRequest
{
    public int? IntId { set; get; }
    public Guid? Id { set; get; }

    public decimal? DocCode
    {
        set;
        get;
    }

    public override string ToString()
    {
        return $"{IntId}{Id}{DocCode}";
    }
}
