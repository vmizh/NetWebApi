namespace Common.Helper.Interfaces.Identity;

public interface IDecimalIdentity : IBaseIdentity
{
    new decimal Id { set; get; }
}
