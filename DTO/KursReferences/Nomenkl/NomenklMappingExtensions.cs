using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Nomenkl;

public static class NomenklMappingExtensions
{
    public static NomenklDto MapToNomenklDto(this SD_83 entity)
    {
        return new NomenklDto
        {
            DocCode = entity.DOC_CODE,
            Id = entity.Id,
            Name = entity.NOM_NAME,
            NameFull = entity.NOM_FULL_NAME,
            NomenklNumber = entity.NOM_NOMENKL,
            IsNaklad = entity.NOM_1NAKLRASH_0NO == 1,
            CurrencyDC = (decimal)entity.NOM_SALE_CRS_DC,
            Currency = null,
            IsDeleted = entity.NOM_DELETED == 1,
            UpdateDate = entity.UpdateDate,
            Main = entity.Main.MapToNomenklMainDto(),
            IsUslugaInRent = entity.IsUslugaInRent,
            Note = entity.NOM_NOTES
        };
    }
    
    public static SD_83 MapToSD_83(this NomenklDto dto)
    {
        return new SD_83
        {
            DOC_CODE = dto.DocCode,
            NOM_NOMENKL = dto.NomenklNumber,
            NOM_ED_IZM_DC = dto.Unit.DocCode,
            NOM_CATEG_DC = dto.Group.DocCode,
            NOM_FULL_NAME = dto.NameFull,
            NOM_NAME = dto.Name,
            NOM_0MATER_1USLUGA = dto.IsUsluga ? 1 : 0,
            NOM_1NAKLRASH_0NO = dto.IsNaklad ? 1 : 0,
            NOM_SALE_CRS_DC = dto.CurrencyDC,
            NOM_TYPE_DC = dto.Main.NomenklType.DocCode,
            NOM_DELETED = dto.IsDeleted ? 1 : 0,
            NOM_NOTES = dto.Note,
            UpdateDate = dto.UpdateDate,
            Id = dto.Id,
            MainId = dto.MainId,
            IsUslugaInRent = dto.IsUslugaInRent,
            IsCurrencyTransfer = dto.IsCurrencyTransfer,
        };
    }
}
