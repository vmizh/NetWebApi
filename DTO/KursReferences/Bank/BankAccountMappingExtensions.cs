using Data.SqlServer.KursReferences.Entities;
using DTO.KursReferences.Responsibility;

namespace DTO.KursReferences.Bank;

public static class BankAccountMappingExtensions
{
    public static BankAccountDto MapToBankAccountDto(this SD_114 entity)
    {
        return new BankAccountDto
        {
            DocCode = entity.DOC_CODE,
            RashAccCode = entity.BA_RASH_ACC_CODE,
            RashAcc = entity.BA_RASH_ACC,
            IsCurrency = entity.BA_CURRENCY == 1,
            IsNegativeRest = entity.BA_NEGATIVE_RESTS == 1,
            BankDC = entity.BA_BANKDC,
            BankName = entity.BA_BANK_NAME,
            ShortName = entity.BA_ACC_SHORTNAME,
            Responsibility = entity.BA_CENTR_OTV_DCNavigation.MapToResponsibilityDto(),
            IsDeleted = entity.IsDeleted,
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
            UpdateDate = dto.UpdateDate,
        };
    }

}
