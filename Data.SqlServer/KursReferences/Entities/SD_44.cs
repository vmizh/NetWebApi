namespace Data.SqlServer.KursReferences.Entities;

public class SD_44
{
    public decimal DOC_CODE { get; set; }

    public string BANK_NAME { get; set; } = null!;

    public string? CORRESP_ACC { get; set; }

    public string? MFO_NEW { get; set; }

    public string? MFO_OLD { get; set; }

    public string? POST_CODE { get; set; }

    public string? SUB_CORR_ACC { get; set; }

    public string? ADDRESS { get; set; }

    public string? BANK_NICKNAME { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_114> SD_114 { get; set; } = new List<SD_114>();
}
