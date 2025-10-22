using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_82 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string CAT_NAME { get; set; } = null!;

    public decimal? CAT_PARENT_DC { get; set; }

    public string? CAT_OKP { get; set; }

    public string? CAT_PATH_NAME { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_82? CAT_PARENT_DCNavigation { get; set; }

    public virtual ICollection<SD_82> InverseCAT_PARENT_DCNavigation { get; set; } = new List<SD_82>();

    public virtual ICollection<NomenklMain> NomenklMains { get; set; } = new List<NomenklMain>();

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
