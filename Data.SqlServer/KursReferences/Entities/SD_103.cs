using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_103 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string BUP_NAME { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
