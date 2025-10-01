namespace Data.SqlServer.KursReferences.Entities;

public class SD_22
{
    public decimal DOC_CODE { get; set; }

    public string CA_NAME { get; set; } = null!;

    public decimal CA_CRS_DC { get; set; }

    public short? CA_NEGATIVE_RESTS { get; set; }

    public decimal? CA_KONTRAGENT_DC { get; set; }

    public decimal? CA_CENTR_OTV_DC { get; set; }

    public decimal? CA_KONTR_DC { get; set; }

    public short? CA_NO_BALANS { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_40? CA_CENTR_OTV_DCNavigation { get; set; }
}
