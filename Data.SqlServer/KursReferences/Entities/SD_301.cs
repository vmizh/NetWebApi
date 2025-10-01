using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_301 : IDocCodeIdentity
{
    public string CRS_CODE { get; set; } = null!;

    public string CRS_NAME { get; set; } = null!;

    public string CRS_SHORTNAME { get; set; } = null!;

    public short CRS_MAIN_CURRENCY { get; set; }

    public string? CRS_BIG_SYMBOL { get; set; }

    public string? CRS_SMALL_SYMBOL { get; set; }

    public int? CRS_ACTIVE { get; set; }

    public byte[]? SMALL_SUMBOL { get; set; }

    public int? ORDER_IMPOTANCE { get; set; }

    public string? NalogCode { get; set; }

    public string? NalogName { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_114> SD_114 { get; set; } = new List<SD_114>();

    public virtual ICollection<SD_2> SD_2 { get; set; } = new List<SD_2>();

    public virtual ICollection<SD_43> SD_43 { get; set; } = new List<SD_43>();
    public decimal DOC_CODE { get; set; }

    public Guid Id { get; set; }

    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
