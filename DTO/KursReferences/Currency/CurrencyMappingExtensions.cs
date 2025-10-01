using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Currency;

public static class CurrencyMappingExtensions
{
    public static CurrencyDto MapToCurrencyDto(this SD_301 entity)
    {
        return new CurrencyDto
        {
            Name = entity.CRS_NAME,
            ShortName = entity.CRS_SHORTNAME,
            IsMain = entity.CRS_MAIN_CURRENCY == 1,
            UpdateDate = entity.UpdateDate,
            DocCode = entity.DOC_CODE,
            Id = entity.Id
        };
    }

    public static CurrencyFullDto MaCurrencyFullDto(this SD_301 entity)
    {
        return new CurrencyFullDto
        {
            Code = entity.CRS_CODE,
            Name = entity.CRS_NAME,
            ShortName = entity.CRS_SHORTNAME,
            IsMain = entity.CRS_MAIN_CURRENCY == 1,
            BigSymbol = entity.CRS_BIG_SYMBOL,
            SmallSymbol = entity.CRS_SMALL_SYMBOL,
            IsActive = entity.CRS_ACTIVE == 1,
            OrderOfImportance = entity.ORDER_IMPOTANCE,
            NalogCode = entity.NalogCode,
            NalogName = entity.NalogName,
            UpdateDate = entity.UpdateDate,
            DocCode = entity.DOC_CODE,
            Id = entity.Id
        };
    }

    public static SD_301 MapToSD_301(this CurrencyFullDto dto)
    {
        return new SD_301
        {
            CRS_CODE = dto.Code,
            CRS_NAME = dto.Name,
            CRS_SHORTNAME = dto.ShortName,
            CRS_MAIN_CURRENCY = (short)(dto.IsMain ? 1 : 0),
            CRS_BIG_SYMBOL = dto.BigSymbol,
            CRS_SMALL_SYMBOL = dto.SmallSymbol,
            CRS_ACTIVE = dto.IsActive ? 1 : 0,
            ORDER_IMPOTANCE = dto.OrderOfImportance,
            NalogCode = dto.NalogCode,
            NalogName = dto.NalogName,
            UpdateDate = dto.UpdateDate,
            DOC_CODE = dto.DocCode,
            Id = dto.Id
        };
    }

    public static SD_301 MapToSD_301(this CurrencyDto dto)
    {
        return new SD_301
        {
            CRS_NAME = dto.Name,
            CRS_SHORTNAME = dto.ShortName,
            CRS_MAIN_CURRENCY = (short)(dto.IsMain ? 1 : 0),
            UpdateDate = dto.UpdateDate,
            DOC_CODE = dto.DocCode,
            Id = dto.Id
        };
    }
}
