using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.KontragentGroup;

public static class KontragentGroupMappingExtensions
{
    public static KontragentGroupDto MapToKontragentGroupDto(this UD_43 entity)
    {
        return new KontragentGroupDto
        {
            Id = entity.EG_ID,
            ParentId = entity.EG_PARENT_ID,
            Name = entity.EG_NAME,
            UpdateDate = entity.UpdateDate,
            GuidId = entity.Id
        };
    }

    public static KontragentGroupFullDto MapToKontragentGroupFullDto(this UD_43 entity)
    {
        return new KontragentGroupFullDto
        {
            GuidId = entity.Id,
            Id = entity.EG_ID,
            ParentId = entity.EG_PARENT_ID,
            Name = entity.EG_NAME,
            UpdateDate = entity.UpdateDate,
            IsDeleted = entity.EG_DELETED == 1
        };
    }

    public static UD_43 MapToUD_43(this KontragentGroupDto dto)
    {
        return new UD_43
        {
            EG_ID = dto.Id,
            EG_PARENT_ID = dto.ParentId,
            UpdateDate = dto.UpdateDate,
            EG_NAME = dto.Name
        };
    }

    public static UD_43 MapToUD_43(this KontragentGroupFullDto dto)
    {
        return new UD_43
        {
            EG_ID = dto.Id,
            EG_PARENT_ID = dto.ParentId,
            UpdateDate = dto.UpdateDate,
            EG_NAME = dto.Name,
            EG_DELETED = (short?)(dto.IsDeleted ? 1 : 0)
        };
    }
}
