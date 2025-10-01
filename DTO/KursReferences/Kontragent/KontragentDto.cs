using DTO.KursReferences.Currency;
using DTO.KursReferences.KontragentGroup;

namespace DTO.KursReferences.Kontragent;

public record KontragentDto
{
    public required decimal DocCode { get; set; }
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required bool IsDeleted { get; set; }

    public int? GroupId => Group?.Id;
    public required KontragentGroupDto? Group { get; set; }
    public required bool IsBalans { set; get; }

    public decimal? CurrencyDC => Currency?.DocCode;
    public required CurrencyDto? Currency { get; set; }

    public required string? NameFull { set; get; }
    public required DateTime? UpdateDate { set; get; }
}
