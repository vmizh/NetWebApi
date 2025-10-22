using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_77 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string TV_NAME { get; set; } = null!;

    public short? TV_TYPE { get; set; }

    public decimal? TV_SHPZ_DC { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_303? TV_SHPZ_DCNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
