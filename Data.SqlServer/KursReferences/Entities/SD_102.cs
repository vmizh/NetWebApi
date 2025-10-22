using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_102 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string TD_NAME { get; set; } = null!;

    public short TD_0BUY_1SALE { get; set; }

    public short? TD_DOP_SOGL { get; set; }

    public short? TD_DILER { get; set; }

    public short? TD_SF_AUTOMAT { get; set; }

    public short? TD_IN_SF_WITH_TEK_PRICES { get; set; }

    public short? TD_USE_PRICES_FOR_ZAKUPOK { get; set; }

    public short? TD_DAVLENCH_DOG { get; set; }

    public DateTime? UpdateDate { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
