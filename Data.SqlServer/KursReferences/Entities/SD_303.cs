namespace Data.SqlServer.KursReferences.Entities;

public class SD_303
{
    public decimal DOC_CODE { get; set; }

    public string SHPZ_NAME { get; set; } = null!;

    public short SHPZ_DELETED { get; set; }

    public int? OP_CODE { get; set; }

    public string? SHPZ_SHIRF { get; set; }

    public short? SHPZ_1OSN_0NO { get; set; }

    public decimal? SHPZ_STATIA_DC { get; set; }

    public decimal? SHPZ_ELEMENT_DC { get; set; }

    public short? SHPZ_PODOTCHET { get; set; }

    public short? SHPZ_1DOHOD_0_RASHOD { get; set; }

    public short? SHPZ_1TARIFIC_0NO { get; set; }

    public short? SHPZ_1ZARPLATA_0NO { get; set; }

    public short? SHPZ_NOT_USE_IN_OTCH_DDS { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_77> SD_77 { get; set; } = new List<SD_77>();

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();

    public virtual SD_99? SHPZ_STATIA_DCNavigation { get; set; }
}
