using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_23 : IDocCodeIdentity
{
    public Guid Id { get; set; }

    public decimal DOC_CODE { get; set; }

    public string REG_NAME { get; set; } = null!;

    public decimal? REG_PARENT_DC { get; set; }

    public decimal? REG_STRANA_DC { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_23> InverseREG_PARENT_DCNavigation { get; set; } = new List<SD_23>();

    public virtual SD_23? REG_PARENT_DCNavigation { get; set; }

    public virtual ICollection<SD_27> SD_27 { get; set; } = new List<SD_27>();

    public virtual ICollection<SD_43> SD_43 { get; set; } = new List<SD_43>();

    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
