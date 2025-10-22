using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_119 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public string MC_NAME { get; set; } = null!;

    public short MC_DELETED { get; set; }

    public double? MC_PROC_OTKL { get; set; }

    public short? MC_TARA { get; set; }

    public short? MC_TRANSPORT { get; set; }

    public short? MC_PREDOPLATA { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<NomenklMain> NomenklMain { get; set; } = new List<NomenklMain>();

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
