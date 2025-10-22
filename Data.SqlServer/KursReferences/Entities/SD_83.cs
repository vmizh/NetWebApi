using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

/// <summary>
///     Status
/// </summary>
public class SD_83 : IDocCodeIdentity
{
    public decimal DOC_CODE { get; set; }

    public string? NOM_BAR_KOD { get; set; }

    public string NOM_NOMENKL { get; set; } = null!;

    public decimal NOM_ED_IZM_DC { get; set; }

    public decimal NOM_CATEG_DC { get; set; }

    public string NOM_FULL_NAME { get; set; } = null!;

    public string NOM_NAME { get; set; } = null!;

    public double? NOM_SROK_HRAN_DNEY { get; set; }

    public int NOM_0MATER_1USLUGA { get; set; }

    public int NOM_1PROD_0MATER { get; set; }

    public int NOM_1NAKLRASH_0NO { get; set; }

    public int? NOM_1PRICELIST_0NO { get; set; }

    public decimal? NOM_SALE_PRICE { get; set; }

    public decimal? NOM_SALE_CRS_DC { get; set; }

    public double? NOM_NDS_PERCENT { get; set; }

    public decimal? NOM_SALE_CRS_PRICE { get; set; }

    public decimal? NOM_TYPE_DC { get; set; }

    public double? NOM_NACEN_KOMPL_PERS { get; set; }

    public decimal? NOM_NACEN_KOMPL_SUM { get; set; }

    public double? NOM_NACEN_OTD_PERS { get; set; }

    public decimal? NOM_NACEN_OTD_SUM { get; set; }

    public short? NOM_RAZDELN_UCHET { get; set; }

    public string? NOM_SHPZ { get; set; }

    public int? NOM_ACC { get; set; }

    public int? NOM_SUBACC { get; set; }

    public int? NOM_MBP { get; set; }

    public decimal NOM_PRODUCT_DC { get; set; }

    public string? NOM_OKP { get; set; }

    public decimal? NOM_PRODUCTOR_DC { get; set; }

    public decimal? NOM_PROIZVODSTVO { get; set; }

    public decimal? NOM_KOMPLEKT_ID { get; set; }

    public decimal? NOM_BASE_KOMPLEKT_DC { get; set; }

    public string? NOM_POLNOE_IMIA { get; set; }

    public int? NOM_1PRINT_IN_PR_LIST_NO { get; set; }

    public int? NOM_DELETED { get; set; }

    public decimal? NOM_SHPZ_DEF_IN_COMPL_DC { get; set; }

    public short? NOM_DEEP_LEVEL { get; set; }

    public double? NOM_VES { get; set; }

    public short? NOM_1EDIT_KOMP_PRICE_0NO { get; set; }

    public string? NOM_NOTES { get; set; }

    public string? NOM_STRANA_IZGOTOV { get; set; }

    public decimal? NOM_GTD_FROM_NOMENKL_DC { get; set; }

    public int? NOM_VHOD_KONTR { get; set; }

    public int? NOM_GAR_NUM_ENABLE { get; set; }

    public decimal? NOM_CO_ZAK_DEF_DC { get; set; }

    public double? NOM_SROK_PROIZVODSTVA { get; set; }

    public decimal? NOM_TARA_DC { get; set; }

    public double? NOM_KOL_IN_ED_TARA { get; set; }

    public short? NOM_IN_PRODUCE_DO_MAIN_NOM { get; set; }

    public short? NOM_PROIZV_UCH_PO_PARTIAM { get; set; }

    public decimal? NOM_CO_REALIZ_DEF_DC { get; set; }

    public double? NOM_HEIGHT { get; set; }

    public double? NOM_LENGTH { get; set; }

    public double? NOM_WIDTH { get; set; }

    public double? NOM_OBYEM { get; set; }

    public double? NOM_BRUTTO_HEIGHT { get; set; }

    public double? NOM_BRUTTO_LENGTH { get; set; }

    public double? NOM_DRUTTO_WIDTH { get; set; }

    public double? NOM_BRUTTO_VES { get; set; }

    public double? NOM_BRUTTO_WIDTH { get; set; }

    public double? NOM_BRUTTO_OBYEM { get; set; }

    public int? SF_NDS_1INCLUD_0NO { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid Id { get; set; }

    public Guid? MainId { get; set; }

    public Guid? StatusId { get; set; }

    public bool? IsUslugaInRent { get; set; }

    public bool? IsCurrencyTransfer { get; set; }

    public virtual ICollection<SD_83> InverseNOM_GTD_FROM_NOMENKL_DCNavigation { get; set; } = new List<SD_83>();

    public virtual ICollection<SD_83> InverseNOM_TARA_DCNavigation { get; set; } = new List<SD_83>();

    public virtual NomenklMain? Main { get; set; }

    public virtual SD_82 NOM_CATEG_DCNavigation { get; set; } = null!;

    public virtual SD_40? NOM_CO_REALIZ_DEF_DCNavigation { get; set; }

    public virtual SD_40? NOM_CO_ZAK_DEF_DCNavigation { get; set; }

    public virtual SD_175 NOM_ED_IZM_DCNavigation { get; set; } = null!;

    public virtual SD_83? NOM_GTD_FROM_NOMENKL_DCNavigation { get; set; }

    public virtual SD_43? NOM_PRODUCTOR_DCNavigation { get; set; }

    public virtual SD_50 NOM_PRODUCT_DCNavigation { get; set; } = null!;

    public virtual SD_303? NOM_SHPZ_DEF_IN_COMPL_DCNavigation { get; set; }

    public virtual SD_83? NOM_TARA_DCNavigation { get; set; }

    public virtual SD_119? NOM_TYPE_DCNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
