namespace Data.SqlServer.KursReferences.Context;

public interface IKursReferenceContextRepository
{
    void Register(DbContextInfo info, string _connString);
    KursReferenceContext? GetContext(string _name);
    KursReferenceContext? GetContext(Guid id);
    Dictionary<DbContextInfo, KursReferenceContext?> GetAllCContexts();

    string GetContextName(Guid id);
}


public record DbContextInfo
{
    public required Guid Id { set; get; }
    public required string Name { set; get; }
    public required int RedisId { set; get; }
}
