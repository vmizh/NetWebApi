using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.ProductType;

public static class ProductMappingExtensions
{
    public static ProductTypeDto MapToProductTypeDto(this SD_50 entity)
    {
        return new ProductTypeDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.PROD_NAME,
            NameFull = entity.PROD_FULL_NAME,
            ParentDC = entity.PROD_PARENT_DC,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_50 MapToSD_50(this ProductTypeDto dto)
    {
        return new SD_50
        {
            DOC_CODE = dto.DocCode,
            PROD_NAME = dto.Name,
            PROD_PARENT_DC = dto.ParentDC,
            PROD_FULL_NAME = dto.NameFull,
            UpdateDate = dto.UpdateDate,
        };
    }
}
