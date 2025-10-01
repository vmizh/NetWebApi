using DTO.KursReferences.Currency;
using DTO.KursReferences.Unit;

namespace DTO.KursReferences.Nomenkl;

public record NomenklDto
{
    public required decimal DocCode { set; get; }
    public required Guid Id { set; get; }
    public required string Name { set; get; }
    public required string NameFull { set; get; }
    public required string NomenklNumber { set; get; }
    public bool IsUsluga => Main.IsUsluga;
    public required bool IsNaklad { set; get; }
    public required decimal CurrencyDC { set; get; }
    public required CurrencyDto? Currency { set; get; }
    public required bool IsDeleted { set; get; }
    public required DateTime? UpdateDate { get; set; }
    public Guid? MainId => Main?.Id;
    public required NomenklMainDto? Main { get; set; }
    public required bool? IsUslugaInRent { get; set; }
    public bool? IsCurrencyTransfer => Main?.IsCurrencyTransfer;
    public NomenklGroupDto? Group => Main?.Category;
    public UnitDto? Unit => Main?.Unit;
    public required string? Note { set; get; }
}


