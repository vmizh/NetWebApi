namespace DTO.KursReferences.SDR;

public record SDRSchetDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required bool IsDeleted { set; get; }
    public required string? Shifr { set; get; }
    public decimal? StateDC => State?.DocCode;
    public required SDRStateDto? State { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
