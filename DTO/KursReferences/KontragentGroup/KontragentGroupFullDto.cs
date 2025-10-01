namespace DTO.KursReferences.KontragentGroup;

public class KontragentGroupFullDto
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public int? ParentId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? UpdateDate { get; set; }
}
