namespace Data.SqlServer.KursReferences.Entities;

public class SD_77
{
    public decimal DOC_CODE { get; set; }

    public string TV_NAME { get; set; } = null!;

    public short? TV_TYPE { get; set; }

    public decimal? TV_SHPZ_DC { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_303? TV_SHPZ_DCNavigation { get; set; }
}
