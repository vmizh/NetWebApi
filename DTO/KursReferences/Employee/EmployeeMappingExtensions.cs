using Data.SqlServer.KursReferences.Entities;
using DTO.KursReferences.Currency;

namespace Data.SqlServer.KursReferences.Employee;

public static class EmployeeMappingExtensions
{
    public static EmployeeDto MapToEmployeeDto(this SD_2 entity)
    {
        return new EmployeeDto
        {
            DocCode = entity.DOC_CODE,
            TabelNumber = entity.TABELNUMBER,
            Id = entity.Id,
            NameLast = entity.NAME_LAST,
            NameFirst = entity.NAME_FIRST,
            NameSecond = entity.NAME_SECOND,
            IsDeleted = entity.DELETED == 1,
            Currency = entity.crs_dcNavigation.MapToCurrencyDto(),
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_2 MapToSD_2(this EmployeeDto dto)
    {
        return new SD_2
        {
            TABELNUMBER = dto.TabelNumber,
            DOC_CODE = dto.DocCode,
            NAME = dto.Name,
            NAME_FIRST = dto.NameFirst,
            NAME_LAST = dto.NameLast,
            NAME_SECOND = dto.NameSecond,
            DELETED = (short?)(dto.IsDeleted == true ? 1 : 0),
            crs_dc = dto.Currency.DocCode,
            Id = dto.Id,
            UpdateDate = null,
        };
    }
}
