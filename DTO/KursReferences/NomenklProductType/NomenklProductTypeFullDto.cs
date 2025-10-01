namespace DTO.KursReferences.NomenklProductType;

public record NomenklProductTypeFullDto : NomenklProductTypeDto
{
    public short? Type { get; set; }
    public decimal? ShpzDC { get; set; }
}
