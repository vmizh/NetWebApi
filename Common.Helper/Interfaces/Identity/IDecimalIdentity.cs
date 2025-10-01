namespace Common.Helper.Interfaces.Identity;

public interface IDecimalIdentity : IBaseIdentity
{
    new decimal Id { set; get; }
}

public interface IDocCodeIdentity : IBaseIdentity
{
    new Guid Id { set; get; }
    decimal DOC_CODE { set; get; }
}
