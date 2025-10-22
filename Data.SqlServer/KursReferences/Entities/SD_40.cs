using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_40 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string CENT_FULLNAME { get; set; } = null!;

    public string CENT_NAME { get; set; } = null!;

    public decimal? CENT_PARENT_DC { get; set; }

    public int? IS_DELETED { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_40? CENT_PARENT_DCNavigation { get; set; }

    public virtual ICollection<SD_40> InverseCENT_PARENT_DCNavigation { get; set; } = new List<SD_40>();

    public virtual ICollection<SD_114> SD_114 { get; set; } = new List<SD_114>();

    public virtual ICollection<SD_22> SD_22 { get; set; } = new List<SD_22>();

    public virtual ICollection<SD_83> SD_83NOM_CO_REALIZ_DEF_DCNavigations { get; set; } = new List<SD_83>();

    public virtual ICollection<SD_83> SD_83NOM_CO_ZAK_DEF_DCNavigations { get; set; } = new List<SD_83>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
