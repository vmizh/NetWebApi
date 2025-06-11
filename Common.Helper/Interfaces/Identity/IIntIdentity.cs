namespace Common.Helper.Interfaces.Identity;

public interface IIntIdentity : IBaseIdentity
{
    new int Id { set; get; }
}
