using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_43 : IDocCodeIdentity
{
    public decimal DOC_CODE { get; set; }

    public string? INN { get; set; }

    public string? NAME { get; set; }

    public string? HEADER { get; set; }

    public string? GLAVBUH { get; set; }

    public string? NOTES { get; set; }

    public string? TYPE_PROP { get; set; }

    public short? DELETED { get; set; }

    public string? ADDRESS { get; set; }

    public string? TEL { get; set; }

    public string? FAX { get; set; }

    public string? OKPO { get; set; }

    public string? OKONH { get; set; }

    public short? FLAG_0UR_1PHYS { get; set; }

    public string? PASSPORT { get; set; }

    public short? SHIPPING_TRAIN_DAYS { get; set; }

    public short? SHIPPING_AUTO_DAYS { get; set; }

    public short? PAYMENT_DAYS { get; set; }

    public int? EG_ID { get; set; }

    public int? TABELNUMBER { get; set; }

    public decimal? NAL_PAYER_DC { get; set; }

    public decimal? REGION_DC { get; set; }

    public decimal? CLIENT_CATEG_DC { get; set; }

    public short? AUTO_CLIENT_CATEGORY { get; set; }

    public decimal? AB_OTRASL_DC { get; set; }

    public decimal? AB_BUDGET_DC { get; set; }

    public decimal? AB_MINISTRY_DC { get; set; }

    public short? PODRAZD_CORP_OBOSOBL { get; set; }

    public short? PODRAZD_CORP_GOLOVNOE { get; set; }

    public short? FLAG_BALANS { get; set; }

    public decimal? VALUTA_DC { get; set; }

    public DateTime? START_BALANS { get; set; }

    public decimal? START_SUMMA { get; set; }

    public int? INNER_CODE { get; set; }

    public string? NAME_FULL { get; set; }

    public short? NO_NDS { get; set; }

    public string? PREFIX_IN_NUMBER { get; set; }

    public string? CONTAKT_LICO { get; set; }

    public string? KASSIR { get; set; }

    public decimal? SPOSOB_OTPRAV_DC { get; set; }

    public string? KPP { get; set; }

    public short? KONTR_DISABLE { get; set; }

    public decimal? MAX_KREDIT_SUM { get; set; }

    public double? TRANSP_KOEF { get; set; }

    public string? TELEKS { get; set; }

    public string? E_MAIL { get; set; }

    public string? WWW { get; set; }

    public int? OTVETSTV_LICO { get; set; }

    public DateTime? LAST_CALC_BALANS { get; set; }

    public byte[]? LAST_MAX_VERSION { get; set; }

    public DateTime? UpdateDate { get; set; }

    public Guid Id { get; set; }

    public virtual SD_148? CLIENT_CATEG_DCNavigation { get; set; }

    public virtual UD_43? EG { get; set; }

    public virtual SD_23? REGION_DCNavigation { get; set; }

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();

    public virtual SD_2? TABELNUMBERNavigation { get; set; }

    public virtual SD_301? VALUTA_DCNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
