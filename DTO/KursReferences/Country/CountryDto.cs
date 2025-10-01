namespace DTO.KursReferences.Country;

public record CountryDto
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public required DateTime? UpdateDate { get; set; }
}
