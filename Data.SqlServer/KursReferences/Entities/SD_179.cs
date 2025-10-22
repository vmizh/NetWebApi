using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_179 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string PT_NAME { get; set; } = null!;

    public short? DEFAULT_VALUE { get; set; }

    public double? PT_DAYS_OPL { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_189> SD_189 { get; set; } = new List<SD_189>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
