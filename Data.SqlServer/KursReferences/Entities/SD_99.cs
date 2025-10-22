using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_99 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string SZ_NAME { get; set; } = null!;

    public string SZ_SHIFR { get; set; } = null!;

    public decimal? SZ_PARENT_DC { get; set; }

    public short? SZ_1DOHOD_0_RASHOD { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_99> InverseSZ_PARENT_DCNavigation { get; set; } = new List<SD_99>();

    public virtual ICollection<SD_303> SD_303 { get; set; } = new List<SD_303>();

    public virtual SD_99? SZ_PARENT_DCNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
