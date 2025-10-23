using DTO.KursReferences.Currency;

namespace Data.SqlServer.KursReferences.Employee;

public record EmployeeDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required int TabelNumber { set; get; }
    public string Name => $"{NameLast} {NameFirst} {NameSecond}";
    public required string NameLast { set; get; }
    public required string? NameFirst { set; get; }
    public required string? NameSecond { set; get; }
    public required bool? IsDeleted { set; get; }
    public decimal? CurrencyDC => Currency.DocCode;
    public required CurrencyDto Currency { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
