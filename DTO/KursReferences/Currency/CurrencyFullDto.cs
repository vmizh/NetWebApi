namespace DTO.KursReferences.Currency;

public record CurrencyFullDto : CurrencyDto
{
    public required string Code { get; set; }

    public required string? BigSymbol { get; set; }

    public required string? SmallSymbol { get; set; }

    public required bool IsActive { get; set; }

    public required int? OrderOfImportance { get; set; }

    public required string? NalogCode { get; set; }

    public required string? NalogName { get; set; }
}
