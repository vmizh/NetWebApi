namespace Data.SqlServer.KursReferences.Entities;

public class SD_50
{
    public decimal DOC_CODE { get; set; }

    public string PROD_NAME { get; set; } = null!;

    public short PROD_TYPE { get; set; }

    public string? PROD_ED_IZM { get; set; }

    public decimal? PROD_PARENT_DC { get; set; }

    public string? PROD_FULL_NAME { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_50> InversePROD_PARENT_DCNavigation { get; set; } = new List<SD_50>();

    public virtual ICollection<NomenklMain> NomenklMain { get; set; } = new List<NomenklMain>();

    public virtual SD_50? PROD_PARENT_DCNavigation { get; set; }

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();
}
