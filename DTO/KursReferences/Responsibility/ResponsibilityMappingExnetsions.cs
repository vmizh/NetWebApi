using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Responsibility;

public static class ResponsibilityMappingExnetsions
{
    public static ResponsibilityDto MapToResponsibilityDto(this SD_40 entity)
    {
        return new ResponsibilityDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.CENT_NAME,
            NameFull = entity.CENT_FULLNAME,
            ParentDC = entity.CENT_PARENT_DC,
            IsDeleted = entity.IS_DELETED == 1,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_40 MapToSD_40(this ResponsibilityDto dto)
    {
        return new SD_40
        {
            DOC_CODE = dto.DocCode,
            CENT_FULLNAME = dto.NameFull,
            CENT_NAME = dto.Name,
            CENT_PARENT_DC = dto.ParentDC,
            IS_DELETED = dto.IsDeleted == true ? 1 : 0,
            UpdateDate = null,
        };

    }
}
