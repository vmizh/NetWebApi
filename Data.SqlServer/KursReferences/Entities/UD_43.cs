using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class UD_43 : IBaseIdentity
{
    public int EG_ID { get; set; }

    public string EG_NAME { get; set; } = null!;

    public int? EG_PARENT_ID { get; set; }

    public short? EG_DELETED { get; set; }

    public short? EG_BALANS_GROUP { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual UD_43? EG_PARENT { get; set; }

    public virtual ICollection<UD_43> InverseEG_PARENT { get; set; } = new List<UD_43>();

    public virtual ICollection<SD_43> SD_43 { get; set; } = new List<SD_43>();

    public object Id
    {
        get => EG_ID;
        set => EG_ID = (int)value;
    }
}
