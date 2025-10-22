using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Entities;

public class SD_114 : IDocCodeIdentity
{
    public Guid Id { get; set; }
    public decimal DOC_CODE { get; set; }

    public int BA_RASH_ACC_CODE { get; set; }

    public string BA_RASH_ACC { get; set; } = null!;

    public short BA_CURRENCY { get; set; }

    public decimal? BA_BANK_AS_KONTRAGENT_DC { get; set; }

    public short BA_TRANSIT { get; set; }

    public decimal BA_BANKDC { get; set; }

    public string BA_BANK_NAME { get; set; } = null!;

    public short? BA_NEGATIVE_RESTS { get; set; }

    public short? BA_BANK_ACCOUNT { get; set; }

    public string? BA_ACC_SHORTNAME { get; set; }

    public decimal? BA_CENTR_OTV_DC { get; set; }

    public decimal? CurrencyDC { get; set; }

    public DateTime? StartDate { get; set; }

    public decimal? StartSumma { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DateNonZero { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_44 BA_BANKDCNavigation { get; set; } = null!;

    public virtual SD_40? BA_CENTR_OTV_DCNavigation { get; set; }

    public virtual SD_301? CurrencyDCNavigation { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
