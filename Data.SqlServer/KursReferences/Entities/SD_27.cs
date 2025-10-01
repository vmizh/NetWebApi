namespace Data.SqlServer.KursReferences.Entities;

public class SD_27
{
    public decimal DOC_CODE { get; set; }

    public string SKL_NAME { get; set; } = null!;

    public int TABELNUMBER { get; set; }

    public decimal SKL_REGION_DC { get; set; }

    public short? SKL_NEGATIVE_REST { get; set; }

    public short? SKL_PROIZVODSTVO { get; set; }

    public short? SKL_NOTAXTO_MUSTTAXFROM { get; set; }

    public short? SKL_GOTOV_PRODUC { get; set; }

    public short? SKL_TORGOVY_ZAL { get; set; }

    public short? SKL_OTK { get; set; }

    public short? SKL_UDAL_TORG_POINT { get; set; }

    public decimal? SKL_KONTR_TO_SPIS_DC { get; set; }

    public Guid Id { get; set; }

    public bool? IsDeleted { get; set; }

    public Guid? ParentId { get; set; }

    public bool? IsOutBalans { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<SD_27> InverseParent { get; set; } = new List<SD_27>();

    public virtual SD_27? Parent { get; set; }

    public virtual SD_23 SKL_REGION_DCNavigation { get; set; } = null!;
}
