namespace DTO.KursReferences.Bank;

public record BankDto
{
    public required Guid Id { get; set; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required string? CorrespAcc {set; get; }
    public required string? PostCode { set; get; }
    public required string? Address { set; get; }
    public required string? NickName { set; get; }
    public required DateTime? UpdateDate { set; get; }
}
