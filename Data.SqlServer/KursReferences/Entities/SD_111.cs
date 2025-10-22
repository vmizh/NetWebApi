using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_111 : IDocCodeIdentity
{
    public decimal DOC_CODE { get; set; }

    public string ZACH_NAME { get; set; } = null!;

    public bool IsCurrencyConvert { get; set; }

    public DateTime? UpdateDate { get; set; }
    public Guid Id { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
