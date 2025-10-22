using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_175 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string ED_IZM_NAME { get; set; } = null!;

    public string? ED_IZM_OKEI { get; set; }

    public short? ED_IZM_MONEY { get; set; }

    public short? ED_IZM_INT { get; set; }

    public string? ED_IZM_OKEI_CODE { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<NomenklMain> NomenklMain { get; set; } = new List<NomenklMain>();

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
