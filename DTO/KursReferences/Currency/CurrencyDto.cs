namespace DTO.KursReferences.Currency;

public record CurrencyDto
{
    public required string Name { get; set; }

    public required string ShortName { get; set; }

    public required bool IsMain { get; set; }
    public required DateTime? UpdateDate { get; set; }

    public required decimal DocCode { get; set; }

    public required Guid Id { get; set; }
}
