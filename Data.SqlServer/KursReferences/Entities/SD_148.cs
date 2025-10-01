namespace Data.SqlServer.KursReferences.Entities;

public class SD_148
{
    public decimal DOC_CODE { get; set; }

    public decimal CK_MIN_OBOROT { get; set; }

    public double CK_MAX_PROSROCH_DNEY { get; set; }

    public decimal CK_CREDIT_SUM { get; set; }

    public string? CK_NAME { get; set; }

    public double? CK_NACEN_DEFAULT_ROZN { get; set; }

    public double? CK_NACEN_DEFAULT_KOMPL { get; set; }

    public short? CK_IMMEDIATE_PRICE_CHANGE { get; set; }

    public string? CK_GROUP { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_43> SD_43 { get; set; } = new List<SD_43>();
}
