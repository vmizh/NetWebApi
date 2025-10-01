namespace Data.SqlServer.KursReferences.Entities;

public class SD_189
{
    public decimal DOC_CODE { get; set; }

    public string OOT_NAME { get; set; } = null!;

    public short? OOT_NALOG_S_PRODAZH { get; set; }

    public double? OOT_NALOG_PERCENT { get; set; }

    public decimal? OOT_USL_OPL_DEF_DC { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_179? OOT_USL_OPL_DEF_DCNavigation { get; set; }
}
