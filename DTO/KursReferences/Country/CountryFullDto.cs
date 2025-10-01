namespace DTO.KursReferences.Country;

public record CountryFullDto : CountryDto
{
    public required string ALPHA2 { get; set; }

    public required string ALPHA3 { get; set; }

    public required string ISO { get; set; }

    public required string FOREIGN_NAME { get; set; }

    public required string RUSSIAN_NAME { get; set; }

    public required string? NOTES { get; set; }

    public required string? LOCATION { get; set; }

    public required string? LOCATION_PRECISE { get; set; }

    public required byte[]? SMALL_FLAG { get; set; }
}
