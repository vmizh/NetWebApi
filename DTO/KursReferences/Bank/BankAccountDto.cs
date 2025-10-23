using DTO.KursReferences.Responsibility;

namespace DTO.KursReferences.Bank;

public record BankAccountDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required int RashAccCode { set; get; }
    public required string RashAcc { set; get; }
    public required bool IsCurrency { set; get; }
    public required bool IsNegativeRest { set; get; }
    public required decimal BankDC { set; get; } 
    public required string BankName { set; get; }
    public required string ShortName { set; get; }
    public decimal ResponsibilityDC => Responsibility.DocCode;
    public required ResponsibilityDto Responsibility { set; get; }
    public required bool? IsDeleted { set; get; }
    public DateTime? UpdateDate { get; set; }
}
