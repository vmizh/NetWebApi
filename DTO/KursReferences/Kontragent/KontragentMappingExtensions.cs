using Data.SqlServer.KursReferences.Entities;
using DTO.KursReferences.Currency;
using DTO.KursReferences.KontragentGroup;

namespace DTO.KursReferences.Kontragent;

public static class KontragentMappingExtensions
{
    public static KontragentDto MapToKontragentDto(this SD_43 entity)
    {
        return new KontragentDto
        {
            DocCode = entity.DOC_CODE,
            Id = entity.Id,
#pragma warning disable CS8601 // Possible null reference assignment.
            Name = entity.NAME,
#pragma warning restore CS8601 // Possible null reference assignment.
            IsDeleted = entity.DELETED == 1,
            Group = entity.EG?.MapToKontragentGroupDto(),
            IsBalans = entity.FLAG_BALANS == 1,
            Currency = entity.VALUTA_DCNavigation?.MapToCurrencyDto(),
            NameFull = entity.NAME_FULL,
            UpdateDate = entity.UpdateDate
        };
    }

    public static KontragentDto MapToKontragentFullDto(this SD_43 entity)
    {
        return new KontragentFullDto
        {
            DocCode = entity.DOC_CODE,
            Id = entity.Id,
#pragma warning disable CS8601 // Possible null reference assignment.
            Name = entity.NAME,
#pragma warning restore CS8601 // Possible null reference assignment.
            IsDeleted = entity.DELETED == 1,
            Group = entity.EG?.MapToKontragentGroupDto(),
            IsBalans = entity.FLAG_BALANS == 1,
            Currency = entity.VALUTA_DCNavigation?.MapToCurrencyDto(),
            NameFull = entity.NAME_FULL,
            UpdateDate = entity.UpdateDate,
            INN = entity.INN,
            KPP = entity.KPP,
            Director = entity.HEADER,
            GlavBuh = entity.GLAVBUH,
            Address = entity.ADDRESS,
            Phone = entity.TEL,
            OKPO = entity.OKPO,
            OKONH = entity.OKONH,
            IsPersona = entity.FLAG_0UR_1PHYS == 1,
            Passport = entity.PASSPORT,
            //IEmployee Employee 
            //IClientCategory ClientCategory 
            //IEmployee ResponsibleEmployee 
            //IRegion Region 

            StartBalans = entity.START_BALANS,
            StartSumma = entity.START_SUMMA,
            EMail = entity.E_MAIL,
            OrderCount = 0
        };
    }

    public static SD_43 MapToSD_43(this KontragentDto dto)
    {
        return new SD_43
        {
            DOC_CODE = dto.DocCode,
            Id = dto.Id,
            NAME = dto.Name,
            DELETED = (short?)(dto.IsDeleted ? 1 : 0),
            EG_ID = dto.GroupId,
            FLAG_BALANS = (short?)(dto.IsBalans ? 1 : 0),
            VALUTA_DC = dto.CurrencyDC
        };
    }

    public static SD_43 MapToSD_43(this KontragentFullDto dto)
    {
        return new SD_43
        {
            DOC_CODE = dto.DocCode,
            Id = dto.Id,
            NAME = dto.Name,
            DELETED = (short?)(dto.IsDeleted ? 1 : 0),
            EG_ID = dto.GroupId,
            FLAG_BALANS = (short?)(dto.IsBalans ? 1 : 0),
            VALUTA_DC = dto.CurrencyDC,
            INN = dto.INN,
            KPP = dto.KPP,
            HEADER = dto.Director,
            GLAVBUH = dto.GlavBuh,
            ADDRESS = dto.Address,
            TEL = dto.Phone,
            OKPO = dto.OKPO,
            OKONH = dto.OKONH,
            FLAG_0UR_1PHYS = (short?)(dto.IsPersona == true ? 1 : 0),
            PASSPORT = dto.Passport,
            START_BALANS = dto.StartBalans,
            START_SUMMA = dto.StartSumma,
            E_MAIL = dto.EMail
        };
    }
}
