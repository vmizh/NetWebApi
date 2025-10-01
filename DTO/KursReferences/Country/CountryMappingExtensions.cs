using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Country;

public static class CountryMappingExtensions
{
    public static CountryDto MapToCountryDto(this COUNTRY entity)
    {
        return new CountryDto
        {
            Id = Guid.Parse(entity.ID),
            Name = entity.NAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static CountryDto MapToCountryFullDto(this COUNTRY entity)
    {
        return new CountryFullDto
        {
            Id = Guid.Parse(entity.ID),
            Name = entity.NAME,
            UpdateDate = entity.UpdateDate,
            ALPHA2 = entity.ALPHA2,
            ALPHA3 = entity.ALPHA3,
            ISO = entity.ISO,
            FOREIGN_NAME = entity.FOREIGN_NAME,
            RUSSIAN_NAME = entity.RUSSIAN_NAME,
            NOTES = entity.NOTES,
            LOCATION = entity.LOCATION,
            LOCATION_PRECISE = entity.LOCATION_PRECISE,
            SMALL_FLAG = entity.SMALL_FLAG
        };
    }

    public static COUNTRY MapToCountry(this CountryDto dto)
    {
        return new COUNTRY
        {
            ID = dto.Id.ToString(),
            NAME = dto.Name,
            UpdateDate = dto.UpdateDate
        };
    }

    public static COUNTRY MapToCountry(this CountryFullDto dto)
    {
        return new COUNTRY
        {
            ID = dto.Id.ToString(),
            NAME = dto.Name,
            UpdateDate = dto.UpdateDate,

            ALPHA2 = dto.ALPHA2,
            ALPHA3 = dto.ALPHA3,
            ISO = dto.ISO,
            FOREIGN_NAME = dto.FOREIGN_NAME,
            RUSSIAN_NAME = dto.RUSSIAN_NAME,
            NOTES = dto.NOTES,
            LOCATION = dto.LOCATION,
            LOCATION_PRECISE = dto.LOCATION_PRECISE,
            SMALL_FLAG = dto.SMALL_FLAG
        };
    }
}
