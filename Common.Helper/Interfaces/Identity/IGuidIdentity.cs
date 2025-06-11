namespace Common.Helper.Interfaces.Identity;

public interface IGuidIdentity : IBaseIdentity
{
    new Guid Id { set; get; }
}
