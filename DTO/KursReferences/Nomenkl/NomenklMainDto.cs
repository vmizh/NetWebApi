using DTO.KursReferences.Country;
using DTO.KursReferences.Unit;

namespace DTO.KursReferences.Nomenkl;

public record NomenklMainDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string NomenklNumber { get; set; }
    public required string? Note { get; set; }
    public required bool IsUsluga { get; set; }
    public decimal? CategoryDC => Category?.DocCode;
    public required NomenklGroupDto? Category { get; set; }
    public required string? FullName { get; set; }
    public required bool IsNakladExpense { get; set; }
    public required Guid? CountryId { set; get; }
    public required CountryDto? Country { set; get; }
    public decimal? UnitDC => Unit?.DocCode;
    public required UnitDto Unit { get; set; }

    /// <summary>
    ///     Сборочный комплект
    /// </summary>
    public required bool IsComplex { get; set; }

    public decimal TypeDC => NomenklType.DocCode;
    public required NomenklTypeDto NomenklType { set; get; }
    public required bool? IsDelete { get; set; }
    public decimal ProductDC { get; set; }
    public required bool? IsRentabelnost { get; set; }
    public required bool? IsCurrencyTransfer { get; set; }
    public required bool? IsOnlyState { get; set; }
    public required DateTime? UpdateDate { get; set; }
}
