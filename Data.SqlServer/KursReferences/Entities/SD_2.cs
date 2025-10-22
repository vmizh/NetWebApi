using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_2 : IDocCodeIdentity
{
    public int TABELNUMBER { get; set; }

    public Guid Id
    {
        get => string.IsNullOrWhiteSpace(ID) ? Guid.Empty : Guid.Parse(ID);
        set => ID = ID = value.ToString();
    }

    public decimal DOC_CODE { get; set; }

    public string? NAME { get; set; }

    public string? NAME_FIRST { get; set; }

    public string? NAME_LAST { get; set; }

    public string? NAME_SECOND { get; set; }

    public string? NAME_OGLY { get; set; }

    public short? DELETED { get; set; }

    public short? OK_DATA_CHANGED { get; set; }

    public DateTime? CHANGE_DATE { get; set; }

    public decimal? crs_dc { get; set; }

    public int? OLD { get; set; }

    public string? ID { get; set; }

    public byte[]? PHOTO { get; set; }

    public string? STATUS_NOTES { get; set; }

    public DateTime? PAYROL_DATE { get; set; }

    public decimal? PAYROL_START { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Project> Project { get; set; } = new List<Project>();

    public virtual ICollection<SD_43> SD_43 { get; set; } = new List<SD_43>();

    public virtual SD_301? crs_dcNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
