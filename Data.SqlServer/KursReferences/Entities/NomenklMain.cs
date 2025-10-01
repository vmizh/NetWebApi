using System.Diagnostics.CodeAnalysis;

namespace Data.SqlServer.KursReferences.Entities;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class NomenklMain
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string NomenklNumber { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsUsluga { get; set; }

    public decimal CategoryDC { get; set; }

    public string? FullName { get; set; }

    public bool IsNakladExpense { get; set; }

    public Guid? CountryId { get; set; }

    public decimal UnitDC { get; set; }

    /// <summary>
    ///     Сборочный комплект
    /// </summary>
    public bool IsComplex { get; set; }

    public decimal TypeDC { get; set; }

    public bool? IsDelete { get; set; }

    public decimal ProductDC { get; set; }

    public bool? IsRentabelnost { get; set; }

    public bool? IsCurrencyTransfer { get; set; }

    public bool? IsOnlyState { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual SD_82 CategoryDCNavigation { get; set; } = null!;

    public virtual SD_50 ProductDCNavigation { get; set; } = null!;

    public virtual ICollection<SD_83> SD_83 { get; set; } = new List<SD_83>();

    public virtual SD_119 TypeDCNavigation { get; set; } = null!;

    public virtual SD_175 UnitDCNavigation { get; set; } = null!;
}
