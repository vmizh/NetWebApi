namespace DTO.KursReferences.SDR;

public record SDRStateDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required string Shifr { set; get; }
    public required decimal? ParentDC { set; get; }
    public required bool IsDohod { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
