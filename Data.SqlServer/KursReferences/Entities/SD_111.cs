namespace Data.SqlServer.KursReferences.Entities;

public class SD_111
{
    public decimal DOC_CODE { get; set; }

    public string ZACH_NAME { get; set; } = null!;

    public bool IsCurrencyConvert { get; set; }

    public DateTime? UpdateDate { get; set; }
}
