using DTO.KursReferences.Region;

namespace DTO.KursReferences.Warehouse;

public record WarehouseDto
{
    public required decimal DocCode { set; get; }
    public required Guid Id { set; get; }
    public required string Name { set; get; }
    public required int KladovshikTabelNumber { set; get; }
    public decimal RegionDC => Region.DocCode;
    public required RegionDto Region { set; get; }
    public required bool? IsDeleted { get; set; }
    public required bool? IsNegativeRest { set; get; }
    public required Guid? ParentId { get; set; }
    public required bool? IsOutBalans { get; set; }
    public required DateTime? UpdateDate { get; set; }
}
